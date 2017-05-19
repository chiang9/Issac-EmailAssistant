using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using Isaac.Models;
using System.Threading.Tasks;

namespace Isaac.Controllers
{
  //  [Authorize (Roles ="Administrator")]
    public class HomeController : Controller
    {
   
        public ActionResult Index()
        {
            return View();
        }
 
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("chiangkl81@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("IsaacTeam@issacemail.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
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
                    return RedirectToAction("Sent");
                }
            }
       


            return View(model);
        }

        public ActionResult Sent()
        {
       
            return View();
        }



        public ActionResult DeleteMe (string id)
        {
            ViewBag.delete = id;
            return View();
        }

        public ActionResult Close()
        {
            return View();
        }
    }
}