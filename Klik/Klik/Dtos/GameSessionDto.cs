using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Klik.Models;

namespace Klik.Dtos
{
    public class GameSessionDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public byte Score { get; set; }

        public Difficulty Difficulty { get; set; }

        public byte DifficultyId { get; set; }

        public DateTime DatePlayed { get; set; }
    }
}