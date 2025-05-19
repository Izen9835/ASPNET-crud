using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SB_Onboarding_1.Models
{
    public class StoreModel
    {
        [DisplayName("id")]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(5, ErrorMessage = "Name cannot exceed 100 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9'\s]*$")]
        public string Name { get; set; }

        [DisplayName("Location")]
        [Required(ErrorMessage = "Location is required.")]
        [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
        public string Address { get; set; }

        [DisplayName("Annual Revenue")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Revenue is required.")]
        [Range(0.01, 12.00, ErrorMessage = "Price must be between 0.01 and 10000.")]
        public decimal Revenue { get; set; }

        [DisplayName("Top Reviews")]
        [Required(ErrorMessage = "Review is required.")]
        public required string Description { get; set; }

        // client side validation can be done here
        // regular expression 
    }
}
