using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineSchoolSample3.DAL;
using OnlineSchoolSample3.Models;
using PagedList;

namespace OnlineSchoolSample3.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Student
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.sortOrder = sortOrder;
            ViewBag.DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


            if(searchString!=null)
            {
                page = 1;
            }

            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            
            var students = from item in db.Students
                           select item;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString));
            }

            switch(sortOrder)
            {
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;

                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;

                case "name_desc":
                    students = students.OrderByDescending(s => s.Name);
                    break;

                default:
                    students = students.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(students.ToPagedList(pageNumber, pageSize));

        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하세요. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하세요.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,EnrollmentDate")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "데이터 생성에 실패하였습니다. 다시 시도해주세요.");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하세요. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하세요.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var studentToUpdate = db.Students.Find(id);

            if(TryUpdateModel(studentToUpdate,"",new string[] { "Name", "EnrollmentDate" }))
            {
                try
                {
                    db.SaveChanges();
                }
                catch(DataException)
                {
                    ModelState.AddModelError("", "저장할수없습니다. 다시 시도해주세요.");
                }
            }

            return View(studentToUpdate);

        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id, bool? saveChangeError=true)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if(saveChangeError.GetValueOrDefault())
            {
                return ViewBag.ErrorMessage = "삭제실패";
            }

            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Student student = db.Students.Find(id);
                db.Students.Remove(student);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangeError = true });
            }
            return RedirectToAction("Index");
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
