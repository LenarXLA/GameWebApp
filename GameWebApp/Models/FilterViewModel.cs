using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameWebApp.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Game> games, Guid game)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            games.Insert(0, new Game { GameTitle = "Все", Id = Guid.Empty });

            Games = new SelectList(games, "Id", "GameTitle", game);
            SelectedGame = game;
        }
        public SelectList Games { get; } // список игр
        public Guid SelectedGame { get; } // выбранная игра
    }
}
