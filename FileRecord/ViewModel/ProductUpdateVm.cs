using System.ComponentModel.DataAnnotations;

namespace FileRecord.ViewModel
{
    public class ProductUpdateVm
    {
        public long Id { get; set; }

        [Display(Name="Name")]
        public string  Name { get; set; }

        [Display(Name = "Upload Your Documents")]
        public IFormFile Document { get; set; }
        public string Doc { get; set; }
    }
}
