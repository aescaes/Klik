using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Klik.Models;

namespace Klik.ViewModels
{
    public class PlayerViewModel
    {
        public IEnumerable<ApplicationUser> Players { get; set; }
        public IEnumerable<GameSession> GameSessions { get; set; }
        public IEnumerable<GameSession> Ranking { get; set; }
        public IEnumerable<Difficulty> Difficulties { get; set; }
    }
}