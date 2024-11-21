using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleProjectManagement.Data;
using SimpleProjectManagement.Models;
using System;

namespace MySqlAspNetExample.Controllers
{
    public class UsersController : Controller
    {
        private readonly ManagementDbContext _context;

        public UsersController(ManagementDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Запрос на список юзеров
        /// GET: Users
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        /// <summary>
        /// Запрос на отдельного юзера
        /// GET: Users/Details/шв
        /// </summary>
        /// <param name="id"> id юзера </param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        /// <summary>
        /// POST: Users/Create
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }


        /// <summary>
        /// POST: Users/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Email")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Users.Any(u => u.Id == user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        /// <summary>
        /// POST: Users/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
