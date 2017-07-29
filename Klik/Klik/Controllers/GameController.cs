using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Klik.Models;
using Klik.ViewModels;

namespace Klik.Controllers
{
    public class GameController : Controller
    {
        private ApplicationDbContext _context;

        public GameController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("players")]
        public ActionResult Players()
        {
            var gameSessions = _context.GameSessions.Include(gs => gs.User).ToList();
            var players = _context.Users.ToList();
            var viewModel = new PlayerViewModel
            {
                Player = players,
                GameSession = gameSessions
            };

            return View(viewModel);
        }
    }
}