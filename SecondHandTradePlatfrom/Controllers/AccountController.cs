using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandTradePlatfrom.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandTradePlatfrom.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext db;
        private readonly string accountIconPath;
        public AccountController(IHostingEnvironment env, DatabaseContext dbContext)
        {
            db = dbContext;
            accountIconPath = Path.Combine(env.WebRootPath, "Images", "AccountIcons");
        }

        public IActionResult CreateAccount(string name, string password, Sex sex, School school, string phoneNumber, string wechat, IList<IFormFile> userIcon)
        {
            if ((name == null || name.Length <= 0) ||
                (password == null || password.Length != 32) ||
                (school == null) ||
                (sex == null) ||
                (phoneNumber == null || phoneNumber.Length != 11) ||
                (userIcon.Count <= 0))
                return new JsonResult(new { result = false, reason = "信息不完整" });

            School sch = (from s in db.Schools where s.name == school.name select s).FirstOrDefault();
            if (sch == null)
            {
                return new JsonResult(new { result = false, reason = "暂不支持的学校" });
            }

            Account accCheck = (from a in db.Accounts where a.name == name && a.passwordMD5 == password && a.phoneNumber == phoneNumber select a).FirstOrDefault();
            if (accCheck != null)
            {
                return new JsonResult(new { result = false, reason = "已存在的用户，请直接登陆" });
            }


            Account accCreate = new Account()
            {
                name = name,
                passwordMD5 = password,
                phoneNumber = phoneNumber,
                wechat = wechat,
                school = school,
                sex = sex
            };

            db.Accounts.Add(accCreate);
            db.SaveChanges();
            return new JsonResult(new { result = true });
        }
    }
}
