
namespace Models.viewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First Name Is Required"), Display(Name = "Last Name"), StringLength(50), RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
                                  ErrorMessage = "name must be char only and more than 2 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Is Required"), Display(Name = "Last Name"), StringLength(50), RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
                                  ErrorMessage = "name must be char only and more than 2 characters")]
        public string LastName { get; set; }
        [Required, StringLength(50), RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
                     ErrorMessage = "City must be char only and more than 2 characters")]
        public string Address { get; set; }
        [Required, DataType(DataType.PhoneNumber), RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public int MobileNumber { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Password { get; set; }
    }
}
