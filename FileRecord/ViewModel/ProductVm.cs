using System.ComponentModel.DataAnnotations;

namespace FileRecord.ViewModel
{
    public class ProductVm
    {
        [Display (Name= "Name")]
        public string Name { get; set; }

        [Display(Name= "Upload your file here")]
        public IFormFile Document { get; set; }
    }
}
