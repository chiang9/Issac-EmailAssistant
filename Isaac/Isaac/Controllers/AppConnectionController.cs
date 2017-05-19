using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Isaac.Models;
using System.Text;
using System.Web.Services;
using System.IO;
using System.Threading;
using System.Web.Security;

namespace Isaac.Controllers
{

    [Authorize(Roles = "General User, Simple Authen")]
    public class AppConnectionController : Controller
    {
        private DB_9FE202_IsaacDevEntities db = new DB_9FE202_IsaacDevEntities();
        //  private DB_9FE202_isaacEntities db = new DB_9FE202_isaacEntities();

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> CategoryBrowsing(string id)
        {

            id = id.Replace("{dot}", ".");
            string email = id + "@gmail.com";
            bool IsInDB = InDB(email);

            if (!IsInDB)
            {
                return RedirectToAction("SimpleRegister", "Authen", new { id = id });
            }

            Category[] cat = await db.Categories.ToArrayAsync();
            List<string> Title = new List<string>();
            List<int> ID = new List<int>();
            List<string> Description = new List<string>();

            foreach (var c in cat)
            {
                Description.Add(c.CategoryDescription);
                Title.Add(c.CategoryName);
                ID.Add(c.CategoryId);
            }
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                  1,
                  email,  //user id
                  DateTime.Now,
                  DateTime.Now.AddMinutes(20),  // expiry
                  false,  //do not remember
                  "Simple Authen",
                  "/");
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                               FormsAuthentication.Encrypt(authTicket));



            Response.Cookies.Add(cookie);
            ViewBag.ID = ID;
            ViewBag.Title = Title;
            ViewBag.Description = Description;



            return View();

        }

        [HttpGet]
        public async Task<ActionResult> TemplateBrowsing(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var templates = db.Templates.Where(o => o.CategoryId == id);
            Template[] tempArray = await templates.ToArrayAsync();
            List<string> Title = new List<string>();
            List<string> Content = new List<string>();
            List<int> UseTime = new List<int>();
            List<int> ID = new List<int>();

            foreach (var x in tempArray)
            {
                UseTime.Add(x.UsedTime);
                Content.Add(x.TemplateDescription);
                Title.Add(x.TemplateTitle);
                ID.Add(x.TemplateID);
            }

            ViewBag.Title = Title;
            ViewBag.Content = Content;
            ViewBag.UseTime = UseTime;
            ViewBag.ID = ID;



            return View(await templates.ToListAsync());

        }

        [HttpGet]
        public async Task<ActionResult> CustomDialog(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Template template = await db.Templates.FindAsync(id);
            template.UsedTime += 1;

            db.Entry(template).State = EntityState.Modified;
            await db.SaveChangesAsync();


            if (template == null)
            {
                return HttpNotFound();
            }


            int templateID = template.TemplateID;
            var QueryResult = db.SP_QuestionByTemplateAndType(templateID).ToList();
            var Subjectquery = db.sp_SubjectQuestionContentbyTemplateID(templateID).ToList();


            List<string> questionContent = new List<string>();
            List<string> questionType = new List<string>();
            List<string> subjectQuestion = new List<string>();

            foreach (var q in Subjectquery)
            {
                subjectQuestion.Add(q);
            }

            foreach (var q in QueryResult)
            {
                questionContent.Add(q.QUestionContent);
                questionType.Add(q.typename);
            }

            string subjectstring = template.TemplateSubject;
            string content = template.Context;
            content = content.Replace("\\n", "\\n");
            string[] seperater = new string[] { "[question]" };
            string[] contentString;
            string[] subjectString;
            contentString = content.Split(seperater, StringSplitOptions.None);
            subjectString = subjectstring.Split(seperater, StringSplitOptions.RemoveEmptyEntries);
           



            // viewbag declare
            ViewBag.Subject = subjectString;
            ViewBag.SubjectQuestion = subjectQuestion;
            ViewBag.QuestionContent = questionContent;
            ViewBag.QuestionType = questionType;
            ViewBag.Content = contentString;
            return View(template);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> PersonalTemplateBrowsing(string id)
        {
           

            if(!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Authen", new { id = id });
            }

            UserInfo ui = await db.UserInfoes.Where(o => o.emailAccount == User.Identity.Name).FirstOrDefaultAsync();

            if (ui == null)
            {
                return RedirectToAction("UIOCreate", "AppConnection");
            }

            int? uid = ui.UserID;

            if (uid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Personaltemplates = db.PersonalTemplates.Where(o => o.UserID == uid);
            PersonalTemplate[] tempArray = await Personaltemplates.ToArrayAsync();

            List<string> Title = new List<string>();
            List<string> Content = new List<string>();
            List<string> Context = new List<string>();
            List<string> Subject = new List<string>();
            List<int> ID = new List<int>();
            int uiid = ui.UserID;

            foreach (var x in tempArray)
            {
                Content.Add(x.TemplateDescription);
                Title.Add(x.TemplateTitle);
                Context.Add(x.Context);
                Subject.Add(x.SubjectContent);
                ID.Add(x.PTemplateID);

            }

            ViewBag.Title = Title;
            ViewBag.Content = Content;
            ViewBag.Context = Context;
            ViewBag.Subject = Subject;
            ViewBag.ID = ID;
            ViewBag.UserID = uiid;


            return View(await Personaltemplates.ToListAsync());
        }

        [HttpGet]
        [Authorize(Roles = "General User, Administrator")]
        public async Task<ActionResult> PersonalCustomDialog(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PersonalTemplate template = await db.PersonalTemplates.FindAsync(id);

            if (template == null)
            {
                return HttpNotFound();
            }


            int templateID = template.PTemplateID;
            var QueryResult = db.SP_PersonalQuestionByTemplateAndType(templateID).ToList();
            var Subjectquery = db.sp_PersonalSubjectQuestionContentbyTemplateID(templateID).ToList();


            List<string> questionContent = new List<string>();
            List<string> questionType = new List<string>();
            List<string> subjectQuestion = new List<string>();

            foreach (var q in Subjectquery)
            {
                subjectQuestion.Add(q);
            }

            foreach (var q in QueryResult)
            {
                questionContent.Add(q.PQuestionContent);
            }

            string subjectstring = template.SubjectContent;
            string content = template.Context;
            content = content.Replace("\\n", "\\n");
            string[] seperater = new string[] { "[question]" };
            string[] contentString;
            string[] subjectString;
            contentString = content.Split(seperater, StringSplitOptions.RemoveEmptyEntries);
            subjectString = subjectstring.Split(seperater, StringSplitOptions.RemoveEmptyEntries);


          
            // viewbag declare
            ViewBag.Subject = subjectString;
            ViewBag.SubjectQuestion = subjectQuestion;
            ViewBag.QuestionContent = questionContent;
            ViewBag.QuestionType = questionType;
            ViewBag.Content = contentString;
            return View(template);
        }

        public ActionResult CompressData(string model)
        {
            return RedirectToAction("Index", "HOme");
            //   return Json(model, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Inbox()
        {
           
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Compose()
        {
            
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Draft()
        {
            return View();
        }

        public async Task<ActionResult> UIOCreate()
        {
            AspNetUser au = await db.AspNetUsers.Where(o => o.UserName == User.Identity.Name).FirstOrDefaultAsync();
            string x = au.Id;
            ViewBag.EA = au.Id;
            ViewBag.emailAccount = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Country = new SelectList(db.Countries, "id", "CountryName");
            ViewBag.Gender = new SelectList(db.Genders, "GenderID", "GenderName");
            ViewBag.UserTitle = new SelectList(db.UserTitles, "TitleID", "TitleName");
            return View();
        }


        // POST: UserInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UIOCreate(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                userInfo.emailAccount = User.Identity.Name;
                db.UserInfoes.Add(userInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("PersonalTemplateBrowsing", "AppConnection");
            }

            ViewBag.emailAccount = new SelectList(db.AspNetUsers, "Id", "Email", userInfo.emailAccount);
            ViewBag.Country = new SelectList(db.Countries, "id", "CountryName", userInfo.Country);
            ViewBag.Gender = new SelectList(db.Genders, "GenderID", "GenderName", userInfo.Gender);
            ViewBag.UserTitle = new SelectList(db.UserTitles, "TitleID", "TitleName", userInfo.UserTitle);

            return View(userInfo);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult SignitureInfo(string id)
        {
            id = id.Replace("{dot}", ".");

            string email = id + "@gmail.com";
            UserInfo ui =  db.UserInfoes.Where(o => o.emailAccount == email).FirstOrDefault();
           string [] strList = new string [6];
            if (ui != null)
            {
                strList[0] = ui.UserTitle1.TitleName;
                strList[1] = ui.FirstName + " " + ui.LastName;
                strList[2] = ui.Tel;
                strList[3] = ui.Company;
                strList[4] = ui.JobTitle;
                strList[5] = ui.Fax;
            }
      
          return  Json(strList, JsonRequestBehavior.AllowGet);
        }

        #region Helper
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InDB(string email)
        {
            List<AspNetUser> aspuser = db.AspNetUsers.ToList();
            foreach (var a in aspuser)
            {
                if (a.UserName.ToLower().Equals(email.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }

}