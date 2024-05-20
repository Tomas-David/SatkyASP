using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_satky.Data;
using web_satky.Data.Migrations;
using web_satky.Models;

namespace web_satky.Controllers
{
    public class productController : Controller
    {
        ApplicationDbContext context;
        IWebHostEnvironment env;
        public productController(ApplicationDbContext my, IWebHostEnvironment hc)
        {
            context = my;
            env = hc;
        }
        public IActionResult Index()
        {
            return View(context.Product.ToList());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Product.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await context.Product.FindAsync(id);
            if (product != null)
            {
                context.Product.Remove(product);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult addProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addProduct(productViewsModel product1)
        {
            String filename = "";
            if(product1.ProductPhoto != null)
            {
                String uploadFolder = Path.Combine(env.WebRootPath, "images");
                filename = Guid.NewGuid().ToString() +"_"+ product1.ProductPhoto.FileName;
                String filepath=Path.Combine(uploadFolder,filename);
                product1.ProductPhoto.CopyTo(new FileStream(filepath, FileMode.Create));
            }

            Product p = new Product { Name = product1.Name,Description = product1.Description,Genders = product1.Genders ,Price= product1.Price, Image = filename, Dryer = product1.Dryer, Ironing = product1.Ironing, Washing = product1.Washing };   
            context.Product.Add(p);
            context.SaveChanges();
            ViewBag.success = "Záznam přidán";
            return View();
        }


        public async Task<IActionResult> Man()
        {  
            return View(await context.Product.ToListAsync());   
        }


        public IActionResult Woman()
        {
            return View(context.Product.ToList());
        }

        public IActionResult Kids()
        {
            return View(context.Product.ToList());
        }

        public IActionResult Others()
        {
            return View(context.Product.ToList());
        }


    }
}
