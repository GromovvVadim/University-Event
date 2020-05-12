using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Event.Domain
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string ShortTitle { get; set; }
        public string LongTitle { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime Date { get; set; }
    }
}
