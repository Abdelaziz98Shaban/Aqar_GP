using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("RealState")]
        public int RealstateId { get; set; }
        public RealState RealState { get; set; }




    }
}
