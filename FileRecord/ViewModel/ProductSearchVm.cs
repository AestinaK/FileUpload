using FileRecord.Constants;
using FileRecord.Models;
using System.ComponentModel.DataAnnotations;

namespace FileRecord.ViewModel
{
    public class ProductSearchVm
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        public string DocumentUrl = $"~/userfiles/{Documents.ProductDirectory}";

        public List<Product> products { get;set; } 

    }
}
