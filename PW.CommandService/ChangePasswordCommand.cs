using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PW.Web.Command
{
    public class ChangePasswordCommand:ICommand
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string RepeatNewPassword { get; set; }
    }
}