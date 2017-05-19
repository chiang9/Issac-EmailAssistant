using Isaac.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Isaac.Controllers
{

    public class TemplateMakerController : Controller
    {
        // GET: TemplateMaker
        private DB_9FE202_IsaacDevEntities db = new DB_9FE202_IsaacDevEntities();
        //    private DB_9FE202_isaacEntities db = new DB_9FE202_isaacEntities();

        #region Category
        public async Task<ActionResult> CategoryCreater()
        {
            return View(await db.Categories.ToListAsync());
        }

        public ActionResult CategoryCreate()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CategoryCreate(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("CategoryCreater");
            }

            return View(category);
        }

        public async Task<ActionResult> CategoryEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CategoryEdit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("CategoryCreater");
            }
            return View(category);
        }

        public async Task<ActionResult> CategoryDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("CategoryDelete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CategoryDeleteConfirmed(int id)
        {
            Category category = await db.Categories.FindAsync(id);
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
            return RedirectToAction("CategoryCreater");
        }
        #endregion

        #region Template
        public async Task<ActionResult> TemplateCreater(int id)
        {
            List<Template> template = await db.Templates.Where(t => t.CategoryId == id).ToListAsync();
            ViewBag.CategoryId = id;

            return View(template);
        }

        public ActionResult TemplateCreate(int id)
        {
            ViewBag.AuthorName = new SelectList(db.Authors, "AuthorID", "LastName");
            ViewBag.CategoryId = id;
            return View();
        }

        // POST: Templates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TemplateCreate(Template template)
        {
            if (ModelState.IsValid)
            {

                string str = template.Context.Replace("\r\n", "\\n");
                template.Context = str;
                template.CreateDate = DateTime.Now;
                template.ModfiedDate = DateTime.Now;
                template.UsedTime = 0;
                template.ModifiedTime = 0;
                db.Templates.Add(template);
                await db.SaveChangesAsync();
                return RedirectToAction("TemplateCreater", new { id = template.CategoryId });
            }

            ViewBag.AuthorName = new SelectList(db.Authors, "AuthorID", "LastName", template.AuthorName);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", template.CategoryId);
            return View(template);
        }

        public async Task<ActionResult> TemplateEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Template template = await db.Templates.FindAsync(id);
            if (template == null)
            {
                return HttpNotFound();
            }
            string str = template.Context.Replace("\\n", "\n");
            template.Context = str;
            ViewBag.AuthorName = new SelectList(db.Authors, "AuthorID", "LastName", template.AuthorName);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", template.CategoryId);
            ViewBag.CatID = template.CategoryId;
            ViewBag.TemplateId = id;
            return View(template);
        }

        // POST: Templates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TemplateEdit(Template template)
        {
            if (ModelState.IsValid)
            {
                string str = template.Context.Replace("\r\n", "\\n");
                template.Context = str;
                template.ModfiedDate = DateTime.Now;
                int catid = template.CategoryId;
                template.ModifiedTime += 1;
                db.sp_updateTempate(template.Context, template.TemplateTitle, template.ModifiedTime, template.CategoryId, template.TemplateSubject, template.TemplateID);

                return RedirectToAction("TemplateCreater", new { id = catid });
            }
            ViewBag.AuthorName = new SelectList(db.Authors, "AuthorID", "LastName", template.AuthorName);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", template.CategoryId);
            return View(template);
        }

        public async Task<ActionResult> TemplateDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Template template = await db.Templates.FindAsync(id);
            if (template == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = template.CategoryId;
            return View(template);
        }

        // POST: Templates/Delete/5
        [HttpPost, ActionName("TemplateDelete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Template template = await db.Templates.FindAsync(id);
            int catid = template.CategoryId;
            db.Templates.Remove(template);
            await db.SaveChangesAsync();
            return RedirectToAction("TemplateCreater", new { id = catid });
        }



        #endregion

        #region Template Question 
        [HttpGet]
        public async Task<ActionResult> TemplateQuestionCreater(int id)
        {
            Template template = await db.Templates.FindAsync(id);

            string[] seperater = new string[] { "[question]" };
            string[] contentString;
           

            contentString = template.Context.Split(seperater, StringSplitOptions.RemoveEmptyEntries);
            
            int questionNum = contentString.Length - 1;
          
            string[] questionName = new string[questionNum];
            

            for (int i = 0; i < questionName.Length; i++)
            {
                questionName[i] = "Template Question " + i;
            }


            ViewBag.CatID = template.CategoryId;
            ViewBag.TemplateID = id;
            ViewBag.TemplateQuestion = questionName;
            ViewBag.TemplateQuestionNum = questionNum;


            return View();
        }


        [HttpPost]
        public async Task<ActionResult> TemplateQuestionCreater(IList<QuestionBindingModel> qbm)
        {

            int templateID = qbm[0].TemplateID;
            Template template = await db.Templates.FindAsync(templateID);
            QuestionBindingModel[] qarray = qbm.ToArray();
            db.sp_DeleteTemplateQuestionByTemp(templateID, 0);
            for (int i = 0; i < qarray.Length; i++)
            {
                db.sp_QuestionBindingAndCreateDuplicateQuestions(qarray[i].questionContent, templateID, i + 1);
            }


            return RedirectToAction("TemplateCreater",new { id = template.CategoryId});
        }

        [HttpGet]
        public async Task<ActionResult> SubjectQuestionCreater(int id)
        {
            Template template = await db.Templates.FindAsync(id);

            string[] seperater = new string[] { "[question]" };
           
            string[] subjectString;

           
            subjectString = template.TemplateSubject.Split(seperater, StringSplitOptions.RemoveEmptyEntries);

           
            int subjectQuestionNum = subjectString.Length - 1;
           
            string[] subjectQuestionName = new string[subjectQuestionNum];


            for (int i = 0; i < subjectQuestionName.Length; i++)
            {
                subjectQuestionName[i] = "Subject Question " + i;
            }

            ViewBag.TemplateID = id;

            ViewBag.SubjectQuestion = subjectQuestionName;
        
            ViewBag.SubjectQuestionNum = subjectQuestionNum;
            ViewBag.CatID = template.CategoryId;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SubjectQuestionCreater(IList<QuestionBindingModel> qbm)
        {
            int templateID = qbm[0].TemplateID;
            Template template = await db.Templates.FindAsync(templateID);
            QuestionBindingModel[] qarray = qbm.ToArray();
            db.sp_deleteSubejctByTemplate(templateID);

            for (int i = 0; i < qarray.Length; i++)
            {
                db.sp_SubjectQuestionBindingAndCreateDuplicateQuestions(qarray[i].questionContent, templateID, i + 1);
            }


            return RedirectToAction("TemplateCreater", new { id = template.CategoryId });

        }

        #endregion

        #region Personal Template 
      [AllowAnonymous]
        public async Task<ActionResult> PersonalTemplateCreater()
        {
           if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("PTLogin", "Authen");
            }
            UserInfo ui = await db.UserInfoes.Where(o => o.emailAccount == User.Identity.Name).FirstOrDefaultAsync();
            int id = ui.UserID;
            List<PersonalTemplate> PersonalTemplate = await db.PersonalTemplates.Where(t => t.UserID == id).ToListAsync();

            ViewBag.UserId = id;

            return View(PersonalTemplate);

        }

        public ActionResult AppPersonalTemplateCreate(int id)
        {

            ViewBag.UserID = id;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AppPersonalTemplateCreate(PersonalTemplate personalTemplate)
        {
            if (ModelState.IsValid)
            {
                if (personalTemplate.Context != null) {
                    string str = personalTemplate.Context.Replace("\r\n", "\\n");
                    db.PersonalTemplates.Add(personalTemplate);
                  
                }
                await db.SaveChangesAsync();
                return RedirectToAction("AppPersonalTemplateQuestionCreater", new { id = personalTemplate.PTemplateID });
            }

            ViewBag.UserID = personalTemplate.UserID;
            return View(personalTemplate);
        }


        [HttpGet]
        public async Task<ActionResult> AppPersonalTemplateQuestionCreater(int id)
        {
            PersonalTemplate Personaltemplate = await db.PersonalTemplates.FindAsync(id);

            string[] seperater = new string[] { "[question]" };
            string[] contentString;
            string[] subjectString;
            string templateContent = "";

            contentString = Personaltemplate.Context.Split(seperater, StringSplitOptions.RemoveEmptyEntries);
            subjectString = Personaltemplate.SubjectContent.Split(seperater, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < contentString.Length; i++)
            {
                templateContent += contentString[i];
                if ((i + 1) < contentString.Length)
                    templateContent += "[ Question " + (i + 1) + " ]";
            }

            string tempstr = templateContent.Replace("\\n", "\n");
            templateContent = tempstr;

            int questionNum = contentString.Length - 1;
            int subjectQuestionNum = subjectString.Length - 1;

            string[] questionName = new string[questionNum];
            string[] sep = new string[] { "\n" };
            string[] subjectQuestionName = new string[subjectQuestionNum];
            string[] templateDiv = templateContent.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < questionName.Length; i++)
            {
                questionName[i] = "Template Question " + i;
            }

            for (int i = 0; i < subjectQuestionName.Length; i++)
            {
                subjectQuestionName[i] = "Subject Question " + i;
            }
            ViewBag.Sub = Personaltemplate.SubjectContent;
            ViewBag.Template = templateDiv;
            ViewBag.UserID = Personaltemplate.UserID;
            ViewBag.TemplateID = id;
            ViewBag.TemplateQuestion = questionName;
            ViewBag.TemplateQuestionNum = questionNum;
            ViewBag.SubjectQuestion = subjectQuestionName;
            ViewBag.SubjectQuestionNum = subjectQuestionNum;

            return View();
        }


        [HttpPost]
        public async Task<ActionResult> AppPersonalTemplateQuestionCreater(IList<QuestionBindingModel> qbm)
        {

            try
            {
                int templateID = qbm[0].TemplateID;
                PersonalTemplate personaltemplate = await db.PersonalTemplates.FindAsync(templateID);
                QuestionBindingModel[] qarray = qbm.ToArray();
                db.sp_DeleteUserTemplateQuestionByTemp(templateID);
                db.sp_deletePersonalSubejctByTemplate(templateID);
                for (int i = 0; i < qarray.Length; i++)
                {
                    if (qarray[i].SubjectQuestion != null)
                        db.sp_PersonalSubjectQuestionBindingAndCreateDuplicateQuestions(qarray[i].SubjectQuestion, templateID, i + 1);
                    if (qarray[i].questionContent != null)
                        db.sp_PersonalQuestionBindingAndCreateDuplicateQuestions(qarray[i].questionContent, templateID, i + 1);
                }

                string[] sep = new string[] { "@" };
                string[] res = db.UserInfoes.Where(o => o.UserID == personaltemplate.UserID).FirstOrDefault().emailAccount.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                return RedirectToAction("PersonalTemplateBrowsing", "AppConnection", new { id = res[0] });
            }
            catch(Exception e)
            {
                UserInfo ui = db.UserInfoes.Where(o => o.emailAccount == User.Identity.Name).FirstOrDefault();
                return RedirectToAction("PersonalTemplateBrowsing", "AppConnection", new { id = ui.UserID });
            }
           
          
        }


        public async Task<ActionResult> PersonalTemplateDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalTemplate personalTemplate = await db.PersonalTemplates.FindAsync(id);
            if (personalTemplate == null)
            {
                return HttpNotFound();
            }
            return View(personalTemplate);
        }

        // GET: PersonalTemplates/Create
        public ActionResult PersonalTemplateCreate(int id)
        {

            ViewBag.UserID = id;
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PersonalTemplateCreate(PersonalTemplate personalTemplate)
        {
            if (ModelState.IsValid)
            {
                if (personalTemplate.Context != null)
                {
                    string str = personalTemplate.Context.Replace("\r\n", "\\n");
                }




                db.PersonalTemplates.Add(personalTemplate);
                await db.SaveChangesAsync();
                return RedirectToAction("PersonalTemplateQuestionCreater", new { id = personalTemplate.PTemplateID});
            }

            ViewBag.UserID = personalTemplate.UserID;
            return View(personalTemplate);
        }

        // GET: PersonalTemplates/Edit/5
        [HttpGet]
        public async Task<ActionResult> PersonalTemplateEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalTemplate personalTemplate = await db.PersonalTemplates.FindAsync(id);
            if (personalTemplate == null)
            {
                return HttpNotFound();
            }
            string str = personalTemplate.Context.Replace("\\n", "\n");
            personalTemplate.Context = str;
            ViewBag.TemplateId = personalTemplate.PTemplateID;
            ViewBag.UserID = personalTemplate.UserID;
            return View(personalTemplate);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalTemplateEdit(PersonalTemplate personalTemplate)
        {
            if (ModelState.IsValid)
            {
                string str = personalTemplate.Context.Replace("\r\n", "\\n");
                personalTemplate.Context = str;
                db.sp_updatePersonalTemplate(personalTemplate.Context, personalTemplate.TemplateDescription, personalTemplate.SubjectContent, personalTemplate.TemplateTitle, personalTemplate.PTemplateID);
                return RedirectToAction("PersonalTemplateCreater", new { id = personalTemplate.UserID });
            }
            ViewBag.UserID = personalTemplate.UserID;
            return View(personalTemplate);
        }

        // GET: PersonalTemplates/Delete/5
        public async Task<ActionResult> PersonalTemplateDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalTemplate personalTemplate = await db.PersonalTemplates.FindAsync(id);
            if (personalTemplate == null)
            {
                return HttpNotFound();
            }
            ViewBag.userid = personalTemplate.UserID;
            return View(personalTemplate);
        }

        // POST: PersonalTemplates/Delete/5
        [HttpPost, ActionName("PersonalTemplateDelete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PersonalTemplateDeleteConfirmed(int id)
        {
            PersonalTemplate personalTemplate = await db.PersonalTemplates.FindAsync(id);
            int? userid = personalTemplate.UserID;
            db.PersonalTemplates.Remove(personalTemplate);
            await db.SaveChangesAsync();
            return RedirectToAction("PersonalTemplateCreater", new { id = userid});
        }

        [HttpGet]
        public async Task<ActionResult> PersonalTemplateQuestionCreater(int id)
        {
            PersonalTemplate Personaltemplate = await db.PersonalTemplates.FindAsync(id);

            string[] seperater = new string[] { "[question]" };
            string[] contentString;
            string[] subjectString;
            string templateContent = "";

            contentString = Personaltemplate.Context.Split(seperater, StringSplitOptions.RemoveEmptyEntries);
            subjectString = Personaltemplate.SubjectContent.Split(seperater, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < contentString.Length; i++)
            {
                templateContent += contentString[i];
                if ((i+1) < contentString.Length)
                templateContent += "[ Question " + (i + 1) + " ]";
            }

            string tempstr = templateContent.Replace("\\n", "\n");
            templateContent = tempstr;
            
            int questionNum = contentString.Length - 1;
            int subjectQuestionNum = subjectString.Length - 1;

            string[] questionName = new string[questionNum];
            string[] sep = new string [] { "\n" };
            string[] subjectQuestionName = new string[subjectQuestionNum];
            string[] templateDiv = templateContent.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < questionName.Length; i++)
            {
                questionName[i] = "Template Question " + i;
            }

            for (int i = 0; i < subjectQuestionName.Length; i++)
            {
                subjectQuestionName[i] = "Subject Question " + i;
            }
            ViewBag.Sub = Personaltemplate.SubjectContent;
            ViewBag.Template = templateDiv;
            ViewBag.UserID = Personaltemplate.UserID;
            ViewBag.TemplateID = id;
            ViewBag.TemplateQuestion = questionName;
            ViewBag.TemplateQuestionNum = questionNum;
            ViewBag.SubjectQuestion = subjectQuestionName;
            ViewBag.SubjectQuestionNum = subjectQuestionNum;

            return View();
        }


        [HttpPost]
        public async Task<ActionResult> PersonalTemplateQuestionCreater(IList<QuestionBindingModel> qbm)
        {
            try
            {
                int templateID = qbm[0].TemplateID;
                PersonalTemplate personaltemplate = await db.PersonalTemplates.FindAsync(templateID);
                QuestionBindingModel[] qarray = qbm.ToArray();
                db.sp_DeleteUserTemplateQuestionByTemp(templateID);
                db.sp_deletePersonalSubejctByTemplate(templateID);
                for (int i = 0; i < qarray.Length; i++)
                {
                    if (qarray[i].SubjectQuestion != null)
                        db.sp_PersonalSubjectQuestionBindingAndCreateDuplicateQuestions(qarray[i].SubjectQuestion, templateID, i + 1);
                    if (qarray[i].questionContent != null)
                        db.sp_PersonalQuestionBindingAndCreateDuplicateQuestions(qarray[i].questionContent, templateID, i + 1);
                }

                return RedirectToAction("PersonalTemplateCreater", new { id = personaltemplate.UserID });
            }
            catch (Exception e)
            {
                UserInfo ui = db.UserInfoes.Where(o => o.emailAccount == User.Identity.Name).FirstOrDefault();
                return RedirectToAction("PersonalTemplateCreater", new { id = ui.UserID });
            }
              
        }

        #endregion



        #region Helper
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}