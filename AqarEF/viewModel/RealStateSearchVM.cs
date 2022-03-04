
using System.ComponentModel;


namespace Models.viewModel
{
    public class RealStateSearchVM
    {
        
        public string Status { get; set; }
        [DefaultValue(500)]
        public decimal? minPrice { get; set; }
        [DefaultValue(922337203685477)]
        public decimal? maxPrice { get; set; }
        public string? BuildingView { get; set; }
        [DefaultValue(40)]
        public double? minArea { get; set; }
        [DefaultValue(9999999999)]
        public double? maxArea { get; set; } 
        public int? Rooms { get; set; }
        public int? Baths { get; set; }
        public int? Floor { get; set; }
        public int CategoryId { get; set; }
    }
}
