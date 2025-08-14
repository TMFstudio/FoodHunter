
namespace FoodHunter.Model
{
    public record BasePageModel : BaseModel
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPage;

    }

}
