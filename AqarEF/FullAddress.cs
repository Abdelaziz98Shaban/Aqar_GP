namespace Models
{
 
  public class FullAddress
    {
        [Required, StringLength(50),
            RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
                         ErrorMessage = "State must be char only and more than 2 characters")]
        public string State { get; set; }

        [Required, StringLength(50), RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
                       ErrorMessage = "City must be char only and more than 2 characters")]
        public string City { get; set; }


        [StringLength(50), RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
                       ErrorMessage = "Street must be char only and more than 2 characters")]
        public string Street { get; set; }
    }
}
