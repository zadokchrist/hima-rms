using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMARMSLLOGIC.Models
{
    public class SystemUser
    {
        public string RecordId { get; set; }
        public string fullname { get; set; }
        public string address { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string department { get; set; }
        public string password { get; set; }
        public bool Active { get; set; }
    }
}
