using GameWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameWebApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index(Guid game, int page = 1,
                    SortState sortOrder = SortState.GameTitleAsc)
        {
            int pageSize = 10;

            //фильтрация
            IQueryable<Game> games = db.Games;

            if (game != Guid.Empty)
            {
                games = games.Where(p => p.Id == game);
            }

            // сортировка
            switch (sortOrder)
            {
                case SortState.GameTitleDesc:
                    games = games.OrderByDescending(s => s.GameTitle);
                    break;
                case SortState.WalkthroughAsc:
                    games = games.OrderBy(s => s.Walkthrough);
                    break;
                case SortState.WalkthroughDesc:
                    games = games.OrderByDescending(s => s.Walkthrough);
                    break;
                case SortState.RatingAsc:
                    games = games.OrderBy(s => s.Rating);
                    break;
                case SortState.RatingDesc:
                    games = games.OrderByDescending(s => s.Rating);
                    break;
                case SortState.PlatformAsc:
                    games = games.OrderBy(s => s.Platform);
                    break;
                case SortState.PlatformDesc:
                    games = games.OrderByDescending(s => s.Platform);
                    break;
                case SortState.ReleaseAsc:
                    games = games.OrderBy(s => s.Release);
                    break;
                case SortState.ReleaseDesc:
                    games = games.OrderByDescending(s => s.Release);
                    break;
                default:
                    games = games.OrderBy(s => s.GameTitle);
                    break;
            }

            // пагинация
            var count = await games.CountAsync();
            var items = await games.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel(db.Games.ToList(), game),
                new SortViewModel(sortOrder)
            );
            return View(viewModel);
        }

        // создание
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Game game)
        {
            db.Games.Add(game);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // удаление
        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id != null)
            {
                Game game = new Game { Id = id.Value };
                db.Entry(game).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        // редактирование
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id != null)
            {
                Game? game = await db.Games.FirstOrDefaultAsync(p => p.Id == id);
                if (game != null) return View(game);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Game game)
        {
            db.Games.Update(game);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}