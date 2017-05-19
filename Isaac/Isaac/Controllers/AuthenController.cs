using Isaac.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Org.BouncyCastle;
using System.Net.Mail;

namespace Isaac.Controllers
{
    public class AuthenController : Controller
    {

        private DB_9FE202_IsaacDevEntities db = new DB_9FE202_IsaacDevEntities();
        //private DB_9FE202_isaacEntities db = new DB_9FE202_isaacEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string id)
        {
            if (id == null)
            {
                id = "";
            }
            ViewBag.RegisterInfo = id;

                id = id.Replace("%%", ".");
            
            string email = id + "@gmail.com";

            
            ViewBag.email = email;
            return View();
        }

        [HttpPost]
        public ActionResult Login(AspNetUser au)
        {

            if (ModelState.IsValid)
            {
                if (IsValidUser(au.UserName, au.PasswordHash))
                {

                    AspNetRole[] arList = db.AspNetUsers.FirstOrDefault(u => u.UserName == au.UserName).AspNetRoles.ToArray();
                    string role = "";
                    for (int i = 0; i < arList.Length; i++)
                    {
                        role += arList[i].Name;
                        role += ",";
                        if (i + 1 == arList.Length)
                        {
                            role += arList[i].Name;
                        }
                    }

                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                      1,
                      au.UserName,  //user id
                      DateTime.Now,
                      DateTime.Now.AddMinutes(20),  // expiry
                      false,  //do not remember
                      role,
                      "/");
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                                       FormsAuthentication.Encrypt(authTicket));



                    Response.Cookies.Add(cookie);


                    return RedirectToAction("PersonalTemplateBrowsing", "AppConnection");



                }
                return View(au);
            }
            else
            {
                ModelState.AddModelError("", "Login is incorrect");
            }
            return View(au);
        }

        [HttpGet]
        public ActionResult UIOLogin(string id)
        {
            if (id == null)
            {
                id = "";
            }
            ViewBag.RegisterInfo = id;

            id = id.Replace("%%", ".");

            string email = id + "@gmail.com";


            ViewBag.email = email;
            return View();
        }

        [HttpPost]
        public ActionResult UIOLogin(AspNetUser au)
        {

            if (ModelState.IsValid)
            {
                if (IsValidUser(au.UserName, au.PasswordHash))
                {

                    AspNetRole[] arList = db.AspNetUsers.FirstOrDefault(u => u.UserName == au.UserName).AspNetRoles.ToArray();
                    string role = "";
                    for (int i = 0; i < arList.Length; i++)
                    {
                        role += arList[i].Name;
                        role += ",";
                        if (i + 1 == arList.Length)
                        {
                            role += arList[i].Name;
                        }
                    }

                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                      1,
                      au.UserName,  //user id
                      DateTime.Now,
                      DateTime.Now.AddMinutes(20),  // expiry
                      false,  //do not remember
                      role,
                      "/");
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                                       FormsAuthentication.Encrypt(authTicket));



                    Response.Cookies.Add(cookie);


                    return RedirectToAction("Create", "UserInfoes");



                }
                return View(au);
            }
            else
            {
                ModelState.AddModelError("", "Login is incorrect");
            }
            return View(au);
        }

        [HttpGet]
        public ActionResult PTLogin(string id)
        {
            if (id == null)
            {
                id = "";
            }
            ViewBag.RegisterInfo = id;

            id = id.Replace("%%", ".");

            string email = id + "@gmail.com";


            ViewBag.email = email;
            return View();
        }

        [HttpPost]
        public ActionResult PtLogin(AspNetUser au)
        {

            if (ModelState.IsValid)
            {
                if (IsValidUser(au.UserName, au.PasswordHash))
                {

                    AspNetRole[] arList = db.AspNetUsers.FirstOrDefault(u => u.UserName == au.UserName).AspNetRoles.ToArray();
                    string role = "";
                    for (int i = 0; i < arList.Length; i++)
                    {
                        role += arList[i].Name;
                        role += ",";
                        if (i + 1 == arList.Length)
                        {
                            role += arList[i].Name;
                        }
                    }

                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                      1,
                      au.UserName,  //user id
                      DateTime.Now,
                      DateTime.Now.AddMinutes(20),  // expiry
                      false,  //do not remember
                      role,
                      "/");
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                                       FormsAuthentication.Encrypt(authTicket));



                    Response.Cookies.Add(cookie);


                    return RedirectToAction("PersonalTemplateCreater", "TemplateMaker");



                }
                return View(au);
            }
            else
            {
                ModelState.AddModelError("", "Login is incorrect");
            }
            return View(au);
        }

        [HttpGet]
        public ActionResult PTRegister(string id)
        {
            if (id == null)
            {
                id = "";
            }
            id = id.Replace("%%", ".");
            string email = id + "@gmail.com";
            RegisterViewModel ru = new RegisterViewModel();
            ru.Email = email;
            return View(ru);
        }

        [HttpPost]
        public async Task<ActionResult> PTRegister(RegisterViewModel au)
        {
            if (ModelState.IsValid)
            {
                string passwordEncrypt = AES.Encrypt(au.Password);
                string id = DateTime.Now.ToString() + au.Email.ToString();
                AspNetRole ar = await db.AspNetRoles.FindAsync("1");
                AspNetUser aun = new AspNetUser();
                aun.Id = id;
                aun.Email = au.Email;
                aun.AspNetRoles.Add(ar);
                aun.PasswordHash = passwordEncrypt;
                aun.UserName = au.Email;
                db.AspNetUsers.Add(aun);

                try
                {
                    await db.SaveChangesAsync();
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                     1,
                     aun.UserName,  //user id
                     DateTime.Now,
                     DateTime.Now.AddMinutes(20),  // expiry
                     false,  //do not remember
                     ar.Name,
                     "/");
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                                       FormsAuthentication.Encrypt(authTicket));



                    Response.Cookies.Add(cookie);
                    return RedirectToAction("PersonalTemplateCreater", "TemplateMaker");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            return View(au);
        }


        [HttpGet]
        public ActionResult UIORegister(string id)
        {
            if (id == null)
            {
                id = "";
            }
            id = id.Replace("%%", ".");
            string email = id + "@gmail.com";
            RegisterViewModel ru = new RegisterViewModel();
            ru.Email = email;
            return View(ru);
        }

        [HttpPost]
        public async Task<ActionResult> UIORegister(RegisterViewModel au)
        {
            if (ModelState.IsValid)
            {
                string passwordEncrypt = AES.Encrypt(au.Password);
                string id = DateTime.Now.ToString() + au.Email.ToString();
                AspNetRole ar = await db.AspNetRoles.FindAsync("1");
                AspNetUser aun = new AspNetUser();
                aun.Id = id;
                aun.Email = au.Email;
                aun.AspNetRoles.Add(ar);
                aun.PasswordHash = passwordEncrypt;
                aun.UserName = au.Email;
                db.AspNetUsers.Add(aun);

                try
                {
                    await db.SaveChangesAsync();
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                     1,
                     aun.UserName,  //user id
                     DateTime.Now,
                     DateTime.Now.AddMinutes(20),  // expiry
                     false,  //do not remember
                     ar.Name,
                     "/");
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                                       FormsAuthentication.Encrypt(authTicket));



                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Create", "UserInfoes");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            return View(au);
        }

        [HttpGet]
        public ActionResult Register(string id)
        {
            if (id == null)
            {
                id = "";
            }
            id = id.Replace("%%", ".");
            string email = id + "@gmail.com";
            RegisterViewModel ru = new RegisterViewModel();
            ru.Email = email;
            return View(ru);
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel au)
        {
            if (ModelState.IsValid)
            {
                string passwordEncrypt = AES.Encrypt(au.Password);
                string id = DateTime.Now.ToString() + au.Email.ToString();
                AspNetRole ar = await db.AspNetRoles.FindAsync("1");
                AspNetUser aun = new AspNetUser();
                aun.Id = id;
                aun.Email = au.Email;
                aun.AspNetRoles.Add(ar);
                aun.PasswordHash = passwordEncrypt;
                aun.UserName = au.Email;
                db.AspNetUsers.Add(aun);

                try
                {
                    await db.SaveChangesAsync();
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                     1,
                     aun.UserName,  //user id
                     DateTime.Now,
                     DateTime.Now.AddMinutes(20),  // expiry
                     false,  //do not remember
                     ar.Name,
                     "/");
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                                       FormsAuthentication.Encrypt(authTicket));



                    Response.Cookies.Add(cookie);
                    return RedirectToAction("PersonalTemplateBrowsing", "AppConnection");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            return View(au);
        }


        [HttpGet]
        public ActionResult SimpleRegister(string id)
        {
            RegisterViewModel ru = new RegisterViewModel();
            ru.Email = id + "@gmail.com";
            
            return View(ru);
        }

        [HttpPost]
        public async Task<ActionResult> SimpleRegister(RegisterViewModel au)
        {
            if (ModelState.IsValid)
            {
                string passwordEncrypt = AES.Encrypt(au.Password);
                string id = DateTime.Now.ToString() + au.Email.ToString();
                AspNetRole ar = await db.AspNetRoles.FindAsync("1");
                AspNetUser aun = new AspNetUser();
                aun.Id = id;
                aun.Email = au.Email;
                aun.AspNetRoles.Add(ar);
                aun.PasswordHash = passwordEncrypt;
                aun.UserName = au.Email;
                db.AspNetUsers.Add(aun);

                try
                {
                    await db.SaveChangesAsync();
                    return RedirectToAction("Categorybrowsing", "AppConnection");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            return View(au);
        }

        [HttpGet]
        public ActionResult ForgetPassword()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ForgetPassword(ForgotPasswordViewModel FPM)
        {
            if (ModelState.IsValid)
            {
                AspNetUser au = await db.AspNetUsers.Where(o => o.UserName == FPM.Email).FirstOrDefaultAsync();

                if (au == null)
                {
                    Response.Write("The Email Address is invalid");
                    return View(FPM);
                }

                string newPas = AES.Decrypt(au.PasswordHash);

                string link = FPM.Email + "," + newPas;

                var body = "<p>Your password is {0}. Please use the following link to reset your password</p> <a href=\"http://localhost:54238/Authen/ResetPassword\">Reset Your Password</a> ";
                var message = new MailMessage();
                message.To.Add(new MailAddress(FPM.Email));  // replace with valid value 
                message.From = new MailAddress("IsaacTeam@issacemail.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, newPas);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient("mail.issacemail.com"))
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "IsaacTeam@issacemail.com",  // replace with valid value
                        Password = "Developer123@"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    //  smtp.Host = "mail.issacemail.com";
                    smtp.Port = 25;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("ResetPassword");
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> ResetPassword(ResetPasswordModel restpassword)
        {
            AspNetUser ui = await db.AspNetUsers.Where(o => o.UserName == restpassword.email).FirstOrDefaultAsync();
            string pas = AES.Decrypt(ui.PasswordHash);
            if (restpassword.OldPassword == pas)
            {
                string newPas = AES.Encrypt(restpassword.Password);
                db.ResetPassword(newPas, restpassword.email);
                return RedirectToAction("Compose", "AppConnection");
            }
            else
            {
               
                return View(restpassword);
            }
           
        }

        #region helper
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private bool IsValidUser(string account, string password)
        {
           
            bool validation = false;
           
            var user = db.AspNetUsers.FirstOrDefault(u => u.UserName == account);
         
            try
            {
                string passwordDecrypt = AES.Decrypt(user.PasswordHash);
                if (passwordDecrypt == password)
                {
                    validation = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return validation;
            }
            return validation;
        }



        #endregion

    }
}