using Bulkyweb.Data;
using Bulkyweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulkyweb.Controllers
{
    public class CagetoryController : Controller
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _db;

        public CagetoryController(ILogger<CagetoryController> logger,
            ApplicationDbContext db
        )
        {
               _logger = logger ?? throw new ArgumentNullException(nameof( logger)); 
               _db = db ?? throw new ArgumentNullException(nameof( db)); 
        }
        public IActionResult Index()
        {
             List<Category> categories  = _db.categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
            _db.categories.Add(category);
            _db.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
            return RedirectToAction(nameof(Index));               
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var category = _db.categories.FirstOrDefault(x => x.Id == Id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            _db.categories.Update(category);
            _db.SaveChanges();
            TempData["Success"] = "Category Updated Successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? Id)
        {
            var category = _db.categories.Find(Id);
            return View(category);
        }

        [HttpPost, ActionName(nameof(Delete))]
        public IActionResult DeletePost(int? Id)
        {
            if(Id==null || Id == 0)
            {
                return NotFound();
            }
            var category = _db.categories.Find(Id);
            if(category==null)
            {
                return NotFound(nameof(Category));
            }
            _db.categories.Remove(category);
            _db.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
