
namespace Models
{
    public class Category
    {
        public Category()
        {
           // RealStates = new HashSet<RealState>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }


        [Required(ErrorMessage = "Name Is Required"), Display(Name = "Name"), StringLength(50), RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
                      ErrorMessage = "Name must be char only and more than 2 characters")]
        public string Name { get; set; }

      //  public virtual ICollection<RealState> RealStates { get; set; }

    }
}
