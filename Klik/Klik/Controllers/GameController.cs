using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Klik.Migrations;
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
        [Route("ranking")]
        public ActionResult Ranking()
        {
            var gameSessions = _context.GameSessions.Include(gs => gs.User).ToList();
            var players = _context.Users.ToList();
            var ranking = _context.GameSessions.OrderByDescending(gs => gs.Score).ToList();
            var difficulties = _context.Difficulties.ToList();
            var viewModel = new PlayerViewModel
            {
                Players = players,
                GameSessions = gameSessions,
                Ranking = ranking,
                Difficulties = difficulties
            };

            return View(viewModel);
        }

        [Route("profile")]
        public ActionResult PlayerProfile()
        {
            var gameSessions = _context.GameSessions
                .Include(gs => gs.User)
                .Include(gs => gs.Difficulty).ToList();

            return View(gameSessions);
        }
    }
}