
using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    public class FavoriteList
    {
        public DateTime Date { get; set; }

        [ForeignKey("RealState")]
        public string RealstateId { get; set; }
        public RealState RealState { get; set; }


        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
