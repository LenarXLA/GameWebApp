namespace GameWebApp.Models
{
    public class SortViewModel
    {
        public SortState WalkthroughSort { get; set; } 
        public SortState GameTitleSort { get; set; }    
        public SortState ReleaseSort { get; set; }
        public SortState PlatformSort { get; set; }
        public SortState RatingSort { get; set; }
        public SortState Current { get; set; }     // значение свойства, выбранного для сортировки
        public bool Up { get; set; }  // Сортировка по возрастанию или убыванию

        public SortViewModel(SortState sortOrder)
        {
            // значения по умолчанию
            WalkthroughSort = sortOrder == SortState.WalkthroughAsc ? SortState.WalkthroughDesc : SortState.WalkthroughAsc;
            GameTitleSort = sortOrder == SortState.GameTitleAsc ? SortState.GameTitleDesc : SortState.GameTitleAsc;
            ReleaseSort = sortOrder == SortState.ReleaseAsc ? SortState.ReleaseDesc : SortState.ReleaseAsc;
            PlatformSort = sortOrder == SortState.PlatformAsc ? SortState.PlatformDesc : SortState.PlatformAsc;
            RatingSort = sortOrder == SortState.RatingAsc ? SortState.RatingDesc : SortState.RatingAsc;
            Current = sortOrder;
        }
    }
}
