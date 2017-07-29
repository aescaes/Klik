using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Klik.Models
{
    public class GameSession
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public byte Score { get; set; }

        public Difficulty Difficulty { get; set; }

        public byte DifficultyId { get; set; }

        public DateTime DatePlayed { get; set; }
    }
}