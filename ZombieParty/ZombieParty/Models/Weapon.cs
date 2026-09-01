using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace ZombieParty.Models
{
    public class Weapon : IValidatableObject
    {
        [StringLength(250, MinimumLength = 2)]
        [Display(Name="Weapon's Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(2500)]
        [Display(Name = "Weapon's Description")]
        public string? Description { get; set; }

        [Range(0, 500)]
        public decimal Force { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, 100000, ErrorMessage = "The {0} as to be between {1} and {2}")]
        public decimal Price { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Weapon's Image")]
        public string? Image { get; set; }

        [Display(Name = "Quantity")]
        public int Qty { get; set; }

        [Display(Name = "Quantity Bought")]
        public int QtyBought { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var item = validationContext.ObjectInstance as Weapon;
            if (item == null) yield break;
            if (string.IsNullOrWhiteSpace(item.Description)) yield break;
            if (item.Description.Split(" ").Length <= 3)
                yield return new ValidationResult("Description needs to have more than 3 words please.", new[] { "Description" });
        }


    }



}
