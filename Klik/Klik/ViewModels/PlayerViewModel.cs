using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Klik.Models;

namespace Klik.ViewModels
{
    public class PlayerViewModel
    {
        public IEnumerable<ApplicationUser> Player { get; set; }
        public IEnumerable<GameSession> GameSession { get; set; }
    }
}