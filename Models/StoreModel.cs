using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SB_Onboarding_1.Models
{
    public class StoreModel
    {
        [DisplayName("id")]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Location")]
        public string Address { get; set; }

        [DisplayName("Annual Revenue")]
        [DataType(DataType.Currency)]
        public decimal Revenue { get; set; }

        [DisplayName("Top Reviews")]
        public required string Description { get; set; }

        // client side validation can be done here
        // regular expression 
    }
}
