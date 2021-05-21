using System.Linq;
using System.Web.Mvc;
using Login.Context;
using System.Web.Security;
namespace Login.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Context.Membership model) 
        {
            using (var context = new office_dbEntities())
            {
                bool isValid = context.Users.Any(x => x.Username == model.UserName && x.Password == model.Password);
                if (isValid == true)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Name");
                    return View();
                }
            }
            return View();
        }

        //Signup
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User model)
        {
            using (var context = new office_dbEntities())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }
                return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
    }
}