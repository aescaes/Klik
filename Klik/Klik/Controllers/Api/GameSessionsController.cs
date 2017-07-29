using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Klik.Dtos;
using Klik.Models;

namespace Klik.Controllers.Api
{
    public class GameSessionsController : ApiController
    {
        private ApplicationDbContext _context;

        public GameSessionsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/gamesessions
        public IEnumerable<GameSessionDto> GetGameSessions()
        {
            return _context.GameSessions.ToList().Select(Mapper.Map<GameSession, GameSessionDto>);
        }

        // POST /api/gamesessions
        [HttpPost]
        public IHttpActionResult SaveGameSession(GameSessionDto gameSessionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var gameSession = Mapper.Map<GameSessionDto, GameSession>(gameSessionDto);
            _context.GameSessions.Add(gameSession);
            _context.SaveChanges();

            gameSessionDto.Id = gameSession.Id;

            return Created(new Uri(Request.RequestUri + "/" + gameSession.Id), gameSessionDto);
        }
    }
}
