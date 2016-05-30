using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PW.Command;
using PW.Web.Command;

namespace PW.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICommandService _commandService;

        public AccountController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordCommand changePasswordCommand)
        {
            _commandService.Excute(changePasswordCommand);
            return new EmptyResult();
        }
    }
}