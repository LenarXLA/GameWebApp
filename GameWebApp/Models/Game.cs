using System.ComponentModel.DataAnnotations.Schema;

namespace GameWebApp.Models
{
    [Table ("GAMES")]
    public class Game
    {
        [Column ("Уид")]
        public Guid Id { get; set; }
        [Column("Прохождение")]
        public string? Walkthrough { get; set; }
        [Column("F2")]
        public string? F2 { get; set; }
        [Column("Название игры")]
        public string? GameTitle { get; set; }
        [Column("Релиз")]
        public string? Release { get; set; }
        [Column("Платформа")]
        public string? Platform { get; set; }
        [Column("Оценка")]
        public string? Rating { get; set; }
    }
}
