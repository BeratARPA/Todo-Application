using ASP.NETCoreUI.Data;
using ASP.NETCoreUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreUI.Controllers
{
    public class TodoController : Controller
    {
        private readonly GenericRepository<Todo> _genericRepository;

        public TodoController(GenericRepository<Todo> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IActionResult Index()
        {
            var todos = _genericRepository.GetAll();
            return View(todos);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _genericRepository.Add(todo);
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var todo = _genericRepository.GetAll(x => x.Id == id).FirstOrDefault();
            return View(todo);
        }

        [HttpPost]
        public IActionResult Update(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _genericRepository.Update(todo);
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        public IActionResult Delete(int id)
        {
            var todo = _genericRepository.GetAll(x => x.Id == id).FirstOrDefault();
            _genericRepository.Delete(todo);
            return RedirectToAction("Index");
        }
    }
}
