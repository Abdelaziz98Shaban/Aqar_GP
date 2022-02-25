﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.viewModel
{
    public class RealStateVModel
    {
        [Required(ErrorMessage = "Name Is Required"),
          MaxLength(100),
          RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
          ErrorMessage = "Name must be char only and more than 2 characters")]
        public string Title { get; set; }

        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Description Is Required"),
            
            StringLength(300),
            RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
            ErrorMessage = "Description must be char only and more than 5 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price Is Required"),
           
            Range(minimum: 500, maximum: Double.MaxValue)]
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


        [Display(Name = "Floor"), Range(1, 300)]
        public int? Floor { get; set; }

        [Display(Name = "Building Number"), Range(1, 1000)]
        public int? BuildingNumber { get; set; }


        [Display(Name = "Appartment Number"), Range(1, 100)]
        public int? AppartmentNumber { get; set; }

        [Range(1, 100)]
        public int? Rooms { get; set; }

        [Range(1, 30)]
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

        [Required]
        public int CategoryId { get; set; }
    }
}