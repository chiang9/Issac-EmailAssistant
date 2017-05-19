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

namespace Isaac.Controllers
{
    [Authorize(Roles = "General User")]
    public class UserInfoesController : Controller
    {
        private DB_9FE202_IsaacDevEntities db = new DB_9FE202_IsaacDevEntities();

        // GET: UserInfoes
     

        // GET: UserInfoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = await db.UserInfoes.FindAsync(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // GET: UserInfoes/Create
        [AllowAnonymous]
        public async Task<ActionResult> Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
              return  RedirectToAction("UIOLogin", "Authen");
            }
           
            UserInfo userInfo = await db.UserInfoes.Where(o => o.emailAccount == User.Identity.Name).FirstOrDefaultAsync();
            IEnumerable<Gender> g = await db.Genders.ToListAsync();

           
          
            ViewBag.emailAccount = new SelectList(db.AspNetUsers, "Id", "Email");
         //   ViewBag.Country = new SelectList(db.Countries, "id", "CountryName");

            if (userInfo != null){
                ViewBag.Gender = new SelectList(g, "GenderID", "GenderName", userInfo.Gender);
                ViewBag.UserTitle = new SelectList(db.UserTitles, "TitleID", "TitleName", userInfo.UserTitle);
                ViewBag.Country = new SelectList(db.Countries, "id","CountryName", userInfo.Country);
            }
            else
            {
                ViewBag.Gender = new SelectList(g, "GenderID", "GenderName");
                ViewBag.UserTitle = new SelectList(db.UserTitles, "TitleID", "TitleName");
                ViewBag.Country = new SelectList(db.Countries, "id", "CountryName");
            }

            if (userInfo != null)
            {
                return View(userInfo);
            }
            return View();
        }

        // POST: UserInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Create(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                userInfo.emailAccount = User.Identity.Name;
                AspNetUser au = await db.AspNetUsers.Where(o => o.UserName == User.Identity.Name).FirstOrDefaultAsync();
                UserInfo userInfoID = await db.UserInfoes.Where(o => o.emailAccount == User.Identity.Name).FirstOrDefaultAsync();
                if (userInfoID != null)
                {
                    db.sp_UPdateUserInfobyID(userInfoID.UserID, userInfo.Country, userInfo.Industry, userInfo.Company, userInfo.JobTitle, userInfo.Tel, userInfo.Fax, userInfo.LastName, userInfo.FirstName, userInfo.Gender, userInfo.UserTitle);
                    return RedirectToAction("Close", "Home");
                }
                db.UserInfoes.Add(userInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Close","Home");

            }
            

            ViewBag.emailAccount = new SelectList(db.AspNetUsers, "Id", "Email", userInfo.emailAccount);
            ViewBag.Country = new SelectList(db.Countries, "id", "CountryName", userInfo.Country);
            ViewBag.Gender = new SelectList(db.Genders, "GenderID", "GenderName", userInfo.Gender);
            ViewBag.UserTitle = new SelectList(db.UserTitles, "TitleID", "TitleName", userInfo.UserTitle);

            return View(userInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
