using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class PersonController : Controller
    {
        static List<Person> people = new List<Person>();

        // GET: PersonController
        public ActionResult Index()
        {
            return View(people);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View(people.Find(p => p.Id == id));
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person p)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", p);
                }
                people.Add(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(people.Find(p => p.Id == id));
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person p, IFormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", p);
            }
            var person = people.Find(x => x.Id == p.Id);
            if (person != null)
            {
                person.Name = p.Name;
                person.Age = p.Age;
                person.Phone = p.Phone;
                person.Email = p.Email;
            }

            return RedirectToAction("Index");
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(people.Find(p => p.Id == id));
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Person p, IFormCollection collection)
        {
            try
            {
                people.RemoveAt(people.FindIndex(x => x.Id == p.Id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View(p);
            }

        }
    }
}
