using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MyController : Controller
    {
        private readonly ILogger<MyController> _logger;

        public MyController(ILogger<MyController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "%username%";
            }

            int hour = DateTime.Now.Hour;
            ViewData["greeting"] = (hour < 12 ? "Доброе утро" : "Добрый день");
            ViewBag.Name = name;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
        
        public string ExeEnum()
        {
            AccountType goldAccount = AccountType.Checking;
            AccountType platinumAccount = AccountType.Deposit;

            string res1 = $"Тип банковского счета {goldAccount}";
            string res2 = $"Тип банковского счета {platinumAccount}";
            string res = res1 + "\n" + res2;
            return res;
        }

        public string ExeStruct()
        {
            BankAccount goldBankAccount;
            goldBankAccount.accType = AccountType.Checking;
            goldBankAccount.accBal = (decimal)3200.00;
            goldBankAccount.accNo = 123;
            return $"Номер счета {goldBankAccount.accNo}, баланс {goldBankAccount.accBal}, тип {goldBankAccount.accType}";
        }

        public string ExeFactorial(int x)
        {
            bool ok = StudyCsharp.Factorial(x, out int f);
            return ok ? $"Факториал числа {x} равен {f}" : "Невозможно вычислить факториал";
        }

        public string ExeTriangle()
        {
            Triangle triangle = new Triangle(3, 5, 6);
            return $"Площадь фигуры {triangle.Name} равна {triangle.Area: 0.##}";
        }

        public string ExeCircle()
        {
            Circle circle = new Circle(3);
            return $"Площадь фигуры {circle.Name} равна {circle.Area: 0.##}";
        }

        public string ExePolim()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Shape[] shapes =
            {
                new Triangle(1, 2, 3),
                new Circle(5),
                new Triangle(5, 6, 8)
            };

            foreach (Shape shape in shapes)
            {
                stringBuilder.Append($"Это фигура {shape.Name}\n");
            }

            return stringBuilder.ToString();
        }

        public string ExeCollection()
        {
            List<Circle> circles = new List<Circle>
            {
                new Circle(12),
                new Circle(5),
                new Circle(15),
                new Circle(6)
            };

            circles.Add(new Circle(7));
            circles.Sort();

            StringBuilder str = new StringBuilder();
            foreach (Shape shape in circles)
            {
                str.AppendFormat($"Это фигура {shape.Name}\n");
            }
            return str.ToString();
        }

        public string ExeCollectionTriangles()
        {
            List<Triangle> triangles = new List<Triangle>
            {
                new Triangle(100, 100, 100),
                new Triangle(2, 4, 8),
                new Triangle(15, 10, 11),
                new Triangle(2, 1, 1)
            };

            triangles.Add(new Triangle(7, 8, 8));
            triangles.Sort();

            StringBuilder str = new StringBuilder();
            foreach (Shape shape in triangles)
            {
                str.AppendFormat($"Это фигура {shape.Name}\n");
            }
            return str.ToString();
        }


    }
}