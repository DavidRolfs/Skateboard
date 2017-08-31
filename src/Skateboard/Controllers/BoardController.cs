using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skateboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Skateboard.Controllers
{
    public class BoardController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public BoardController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Boards.Where(x => x.User.Id == currentUser.Id));
        }
        public IActionResult Details(int id)
        {
            var thisBoard = _db.Boards.FirstOrDefault(boards => boards.Id == id);
            return View(thisBoard);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Board board)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            board.User = currentUser;
            _db.Boards.Add(board);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisBoard = _db.Boards.FirstOrDefault(boards => boards.Id == id);
            return View(thisBoard);
        }

        [HttpPost]
        public IActionResult Edit(Board board)
        {
            _db.Entry(board).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisBoard = _db.Boards.FirstOrDefault(boards => boards.Id == id);
            return View(thisBoard);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisBoard = _db.Boards.FirstOrDefault(boards => boards.Id == id);
            _db.Boards.Remove(thisBoard);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
