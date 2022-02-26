
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ApplicationUser:IdentityUser
    {

        public ApplicationUser()
        {
            RealStates = new HashSet<RealState>();
            
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        [DataType(DataType.PhoneNumber) , RegularExpression(pattern: @"^01[0-2,5]{1}[0-9]{8}$")]
        public int MobileNumber { get; set; }
        public virtual ICollection<RealState> RealStates { get; set; }
    }
}
