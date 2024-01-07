using FileRecord.Constants;
using FileRecord.Data;
using FileRecord.Helper;
using FileRecord.Models;
using FileRecord.ValueObject;
using FileRecord.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FileRecord.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new ProductSearchVm();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(ProductSearchVm vm)
        {
            if (vm.Name == null)
            {
                return View(vm);
            }
            vm.products  = _context.products.Where(x => x.Name.ToLower() == vm.Name.ToLower()).ToList();
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var vm = new ProductVm();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductVm vm)
        {
            var file = new FileRecordVo(Documents.ProductDirectory, vm.Document);
            string fileName = vm.Document!=null ? await FileHelper.SavePhysicalFileAsync(file) : string.Empty;

            var product = new Product()
            {
                Name = vm.Name,
                DocumentPath = fileName
            };
            _context.products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Add));
        }

        [HttpGet]
        public async Task<IActionResult> Update(long Id)
        {
            var data = _context.products.Find(Id);
            var vm = new ProductUpdateVm();
            vm.Name = data.Name;
            vm.Doc =  FileHelper.GetFile(Documents.ProductDirectory, data.DocumentPath);
            return View(vm);
            
        }
    }
}
