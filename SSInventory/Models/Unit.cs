
using System.ComponentModel.DataAnnotations;
namespace SSInventory.Models
{
    public class Unit
    {

        public int intSeqId { get; set; }
        [Display(Name = "Unit Name")]
        [Required(ErrorMessage = "Name Must Enter")]
        public string varName { get; set; }
        [Display(Name = "Unit Description")]
        [Required(ErrorMessage = "Description Must Enter")]
        public string varDescription { get; set; }

        public bool isActive { get; set; }

    }
}
