using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riode.DAL;
using Riode.Models;
using Riode.Utilities.Extensions;
using Z.EntityFramework.Plus;
using Riode.Utilities.Extensions;

namespace Riode.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles ="SuperAdmin,Admin")]
    public class ProductController : Controller
    {
        RiodeDbContext _context { get; }

        public ProductController(RiodeDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View(_context.Products.IncludeOptimized(p => p.ProductImages.Take(1)).IncludeOptimized(p => p.Category));
        }
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.Where(c => c.IsDeleted == false).ToList();
            ViewBag.Badges = _context.Badges;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product prod)
        {
            ViewBag.Categories = _context.Categories.Where(c => c.IsDeleted == false).ToList();
            ViewBag.Badges = _context.Badges;
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (prod.MainImage is null)
            {
                ModelState.AddModelError("MainImage", "Zəhmət olmasa şəkil seçin");
                return View();
            }

            #region Images
            var productImgs = prod.Images;
            List<ProductImage> images = new List<ProductImage>();
            if (productImgs != null)
            {
                foreach (var img in productImgs)
                {
                    if (!img.CheckFileExtension("image/"))
                    {
                        ModelState.AddModelError("MainImage", "Yüklədiyiniz fayl şəkil deyil");
                        return View();
                    }
                    if (img.CheckFileSize(2))
                    {
                        ModelState.AddModelError("MainImage", "Yüklədiyiniz şəkil 2mb-dan artıq olmamalıdır");
                        return View();
                    }
                }


                foreach (var img in productImgs)
                {
                    string imgUrl = Guid.NewGuid() + img.CutFileName();
                    img.SaveFile(Path.Combine("imgs", "shop", imgUrl));
                    images.Add(new() {
                        ImageUrl = imgUrl,
                        Status = null,
                        Product = prod
                    });
                }
            }
            #endregion

            #region Main Image
            var mainImg = prod.MainImage;
            if (!mainImg.CheckFileExtension("image/"))
            {
                ModelState.AddModelError("MainImage", "Yüklədiyiniz fayl şəkil deyil");
                return View();
            }
            if (mainImg.CheckFileSize(2))
            {
                ModelState.AddModelError("MainImage", "Yüklədiyiniz şəkil 2mb-dan artıq olmamalıdır");
                return View();
            }
            string mainImgName = Guid.NewGuid() + mainImg.CutFileName();
            mainImg.SaveFile(Path.Combine("imgs", "shop", mainImgName));
            images.Add(new()
            {
                ImageUrl = mainImgName,
                Status = true,
                Product = prod
            });
            #endregion

            #region Hover Image
            var hoverImg = prod.HoverImage;
            if (hoverImg != null)
            {
                if (!hoverImg.CheckFileExtension("image/"))
                {
                    ModelState.AddModelError("HoverImage", "Yüklədiyiniz fayl şəkil deyil");
                    return View();
                }
                if (hoverImg.CheckFileSize(2))
                {
                    ModelState.AddModelError("HoverImage", "Yüklədiyiniz şəkil 2mb-dan artıq olmamalıdır");
                    return View();
                }
                string hoverImgName = Guid.NewGuid() + hoverImg.CutFileName();
                hoverImg.SaveFile(Path.Combine("imgs", "shop", hoverImgName));
                images.Add(new()
                {
                    ImageUrl = hoverImgName,
                    Status = false,
                    Product = prod
                });
            }
            #endregion
            
            prod.ProductImages = images;
            
            prod.IsDeleted = false;
            _context.Products.Add(prod);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id is null) return BadRequest();
            Product prod = _context.Products.IncludeOptimized(p => p.ProductImages).FirstOrDefault(p => p.Id == id);
            if (prod is null) return NotFound();
            ViewBag.Categories = _context.Categories.Where(c => c.IsDeleted == false).ToList();
            ViewBag.Badges = _context.Badges;
            return View(prod);
        }
        [HttpPost]
        public IActionResult Update(int? id, Product product)
        {
            ViewBag.Categories = _context.Categories.Where(c => c.IsDeleted == false).ToList();
            ViewBag.Badges = _context.Badges;
            if (id != product.Id) return BadRequest();
            Product exist = _context.Products.Include(p => p.ProductImages).FirstOrDefault(p=>p.Id == id);
            if (exist is null) return BadRequest();
            List<int> willDelete = new List<int>();
            foreach (var imgId in exist.ProductImages.Where(pi=> pi.Status == null))
            {
                if (!product.ImageIds.Exists(i=>i == imgId.Id))
                {
                    willDelete.Add(imgId.Id);
                }
            }
            product.ImageIds = willDelete;
            return Ok(product);
        }
    }
}
