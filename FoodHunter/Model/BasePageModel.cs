
namespace FoodHunter.Model
{
    public record BasePageModel : BaseModel
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPage;

    }

}
