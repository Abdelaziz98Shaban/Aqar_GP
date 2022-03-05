namespace Models
{
    public class RealState
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Name Is Required"), 
            Display(Name = "Name"), 
            MaxLength(100)]
        public string Title { get; set; }

        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Description Is Required"),
            Display(Name = "Description"),
            StringLength(800)]
        public string Description { get; set;}
        
        [Required(ErrorMessage = "Price Is Required"),
            Display(Name = "Price"),
            Column(TypeName = "money"),
            Range(minimum:500,maximum:Double.MaxValue)]
        public decimal Price { get; set; }

        [Display(Name = "Video Link"), StringLength(200)]
        public string? VideoLink { get; set; }

        [Display(Name = "BuildingView"), StringLength(200)]
        public string? BuildingView { get; set; }
        [Display(Name = "Area"),
            Required,
            Range(40, 300000000)]
        public double Area { get; set; }

        [Required]
        public FullAddress Address { get; set; }


        [ Display(Name = "Floor"), Range(1, 300)]
        public int? Floor { get; set; } 
        
        [Display(Name = "Building Number"), Range(1, 1000)]
        public int? BuildingNumber { get; set; }


        [ Display(Name = "Appartment Number"), Range(1, 100)]
        public int? AppartmentNumber { get; set; }

        [ Range(1, 100)]
        public int? Rooms { get; set; }

        [ Range(1, 30)]
        public int? Baths { get; set; }

        [Required, StringLength(50), RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
                          ErrorMessage = "Status must be char only and more than 2 characters")]
        // rent or sale
        public string Status { get; set; }

        [Display(Name = "Swimming Pool"), Required(ErrorMessage = "Swimming Pool Is Required")]
        public bool SwimmingPool { get; set; }

        [Display(Name = "Laundry Room"), Required(ErrorMessage = "Laundry Room Is Required")]

        public bool LaundryRoom { get; set; }

        [Display(Name = "Emergency Exit"), Required(ErrorMessage = "Emergency Exit Is Required")]

        public bool EmergencyExit { get; set; }

        [Display(Name = "Fire Place"), Required(ErrorMessage = "Fire Place Is Required")]
        public bool FirePlace { get; set; }

        [ForeignKey("Category")]

        public string CategoryId { get; set; }
        public virtual Category? Category { get; set; }


            [ForeignKey("ApplicationUser")]

            public string UserId { get; set; }
            public virtual ApplicationUser? ApplicationUser { get; set; }


    }
}
