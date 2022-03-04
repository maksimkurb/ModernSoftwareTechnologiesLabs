using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class ProductModel : PageModel
    {
        public string? MessageResult { get; set; }

        [BindProperty]
        public Product Product { get; set; } = new Product();
        public void OnPost()
        {
            if (!Product.Price.HasValue || Product.Price < 0 || string.IsNullOrEmpty(Product.Name))
            {
                MessageResult = "Переданы некорректные данные. Повторите ввод";
                return;
            }
            decimal? result = Product.Price * (decimal?)0.18;
            MessageResult = $"Для товара {Product.Name} с ценой {Product.Price} скидка получится {result}";
            //Product.Price = price;
            //Product.Name = name;
        }

        public void OnPostDiscount(double discount)
        {
            decimal? result = Product.Price * (decimal?)discount / 100;
            MessageResult = $"Для товара {Product.Name} с ценой {Product.Price} скидка получится {result}";
            //Product.Price = price;
            //Product.Name = name;
        }

        public void OnPostBuyWithoutDiscount()
        {
            MessageResult = $"Вы купили товар {Product.Name} за {Product.Price}";
            //Product.Price = price;
            //Product.Name = name;
        }

        public void OnGet()
        {
            MessageResult = "Для товара можно определить скидку";
        }
    }
}
