using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGames.Models;

namespace BoardGames.Service
{
    public class GameService : IGameService
    {
        private GameContext _context;
        private IMemoryCache _cache;

        public GameService(GameContext context, IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            _context = context;
        }

        public void AddBoardGame(BoardGame game)
        {
            _context.Games.Add(game);
            int key = _context.SaveChanges();

            if (key > 0)
            {
                _cache.Set(game.Id, game, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
            }
        }

        public async Task<BoardGame> GetBoardGameByIdAsync(int id)
        {
            BoardGame game = null;
            if (!_cache.TryGetValue(id, out game))
            {
                game = await _context.Games.FindAsync(id);
                if (game != null)
                {
                    _cache.Set(game.Id, game,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }
            return game;
        }

        public async Task<IEnumerable<BoardGame>> GetAllBoardGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }
    }
}
