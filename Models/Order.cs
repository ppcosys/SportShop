using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

        [Required(ErrorMessage = "Proszę wpisać imię i nazwisko")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Proszę wpisać adres")]
        public string? Line1 { get; set;}

        public string? Line2 { get; set;}

        public string? Line3 { get; set;}

        [Required(ErrorMessage ="Proszę wpisać miejscowość")]
        public string? City { get; set;}

        [Required(ErrorMessage = "Proszę wpisać kod pocztowy")]

        public string? Zip { get; set;}

        public string? Country { get; set; } = "Polska";

        public bool GiftWrap { get; set;}

    }
}
