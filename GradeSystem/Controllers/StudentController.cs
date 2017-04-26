using GradeSystem.Data;
using GradeSystem.Model;
using GradeSystem.Service;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GradeSystem.ServiceReference1;


namespace GradeSystem.Controllers
{
    public class StudentController : Controller
    {
        private SystemContext db = new SystemContext();
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Student
        public ActionResult Index()
        {
            var students = from s in db.Students select s;
            var student = _studentService.GetAllStudents();

            return View(students.ToList());

            //consuming WCF service
            //HelloworldServiceClient wcf = new HelloworldServiceClient();

            //wcf.GetEmployee(1);

            //var ans = wcf.Multiply(10, 10);

            //var emp = wcf.GetAllEmployees();

            //return View(emp.ToList());
        }

        //public ActionResult Wcf()
        //{
        //    //var students = from s in db.Students select s;
        //    //Student student = _studentService.GetAllStudents();

        //    //return View(students.ToList());

        //    //consuming WCF service
        //    HelloworldServiceClient wcf = new HelloworldServiceClient();

        //    wcf.GetEmployee(1);

        //    var ans = wcf.Multiply(10, 10);

        //    var emp = wcf.GetAllEmployees();

        //    return View(emp.ToList());
        //}

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Student student = db.Students.Find(id);
            Student student = _studentService.GetStudent(id);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName,FirstMidName,EnrollmentDate")] Student student)
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
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, LastName, FirstMidName, EnrollmentDate")]Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(student);
        }

        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                //Student student = db.Students.Find(id);
                //db.Students.Remove(student);
                Student studentToDelete = new Student() { ID = id };
                db.Entry(studentToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
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