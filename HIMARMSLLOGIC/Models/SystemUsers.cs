using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMARMSLLOGIC.Models
{
    public class SystemUsers : GenericResponse
    {
        public List<SystemUser> systemUsers { get; set; }
    }
}
