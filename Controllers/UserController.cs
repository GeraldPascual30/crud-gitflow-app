using Microsoft.AspNetCore.Mvc;
using CrudGitFlowApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace CrudGitFlowApp.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>();

        public IActionResult Index()
        {
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            var existing = users.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                existing.Name = user.Name;
                existing.Email = user.Email;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
			{
				users.Remove(user);
			}	
            return RedirectToAction("Index");
        }
    }
}