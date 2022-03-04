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
                MessageResult = "�������� ������������ ������. ��������� ����";
                return;
            }
            decimal? result = Product.Price * (decimal?)0.18;
            MessageResult = $"��� ������ {Product.Name} � ����� {Product.Price} ������ ��������� {result}";
            //Product.Price = price;
            //Product.Name = name;
        }

        public void OnPostDiscount(double discount)
        {
            decimal? result = Product.Price * (decimal?)discount / 100;
            MessageResult = $"��� ������ {Product.Name} � ����� {Product.Price} ������ ��������� {result}";
            //Product.Price = price;
            //Product.Name = name;
        }

        public void OnPostBuyWithoutDiscount()
        {
            MessageResult = $"�� ������ ����� {Product.Name} �� {Product.Price}";
            //Product.Price = price;
            //Product.Name = name;
        }

        public void OnGet()
        {
            MessageResult = "��� ������ ����� ���������� ������";
        }
    }
}
