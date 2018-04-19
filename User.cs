using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkEF
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public int Password { get; set; }
        public string Address { get; set; }
        public bool IsAdmin { get; set; }
    }
}
