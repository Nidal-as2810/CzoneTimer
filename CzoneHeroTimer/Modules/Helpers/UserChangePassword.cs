using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzoneHeroTimer.Modules.Helpers
{
    public class UserChangePassword : User
    {
        public string NewPassword { get; set; }
        public string RetypePassword { get; set; }
    }
}
