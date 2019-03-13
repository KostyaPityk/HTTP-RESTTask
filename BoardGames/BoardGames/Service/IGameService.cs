using BoardGames.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardGames.Service
{
    public interface IGameService
    {
        Task<BoardGame> GetBoardGameByIdAsync(int id);
        Task<IEnumerable<BoardGame>> GetAllBoardGamesAsync();
        void AddBoardGame(BoardGame game); 
    }
}
