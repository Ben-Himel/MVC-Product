using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Module4.Models;
using Module4.Services;

namespace Module4.Controllers
{
    public class ProductController : Controller
    {
        private ICRUD cRUD;
        private IFileUpload fileUpload;

        //injection
        public ProductController(ICRUD cRUD)
        {
            this.cRUD = cRUD;
        }

        [Authorize(Roles = "Employee")]
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.ProductList = cRUD.GetProductList();
            return View(model);
        }

        [Authorize(Roles = "Employee")]
        public IActionResult Details(int? id)
        {
            var prod = cRUD.GetProduct(id);
            if (prod == null)
            {
                return NotFound();
            }
            return View(prod);
        }

        //get request
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var newprod = new Product();
            newprod.ProductId = cRUD.GetMaxID();
            return View(newprod);
        }
        [HttpPost]
        public IActionResult Create(Product newprod)
        {
            newprod.ProductImageName = "bodie.jpg";
            cRUD.Create(newprod);
            return RedirectToRoute(new
                    {
                        Action= "Index", Controller="Product" 
                    });
        }
        //post method
        //public async Task<ActionResult> Create(Product prod, IFormFile file)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        if(await fileUpload.UploadFile(file))
        //        {
        //            prod.ProductImageName = fileUpload.FileName;
        //            cRUD.Create(prod);
        //            return RedirectToRoute(new 
        //            {
        //                Action= "Index", Controller="Product" 
        //            });
        //        }
        //        else
        //        {
        //            ViewBag.ErrorMessage = "File Upload Failed";
        //            return View(prod);
        //        }

        //    }
        //    ViewBag.Message = "Error creating Product";
        //    return View(prod);
        //}

        [Authorize(Roles ="Admin")]
        public IActionResult Edit(int id)
        {
            var prod = cRUD.GetProduct(id);
            return View(prod);
        }
        [HttpPost]
        public IActionResult Edit(Product prod)
        {
            if (ModelState.IsValid)
            {
                cRUD.Update(prod);
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Error editting item";
            return View(prod);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            cRUD.DeleteProduct(id);
            return RedirectToAction("Index");
        }

    }
}
