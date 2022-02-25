
namespace Models.viewModel
{
    public class RealStateSearchVM
    {
        public string Status { get; set; }
        public decimal minPrice { get; set; }
        public decimal maxPrice { get; set; }
        public string? BuildingView { get; set; }
       public double minArea { get; set; }
        public double maxArea { get; set; }
        public int? Rooms { get; set; }
        public int? Baths { get; set; }
        public int? Floor { get; set; }
        public int CategoryId { get; set; }
    }
}
