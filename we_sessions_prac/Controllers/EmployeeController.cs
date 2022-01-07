using we_sessions_prac.DAL;
using we_sessions_prac.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.IO;

namespace we_sessions_prac.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            if(Session["login"] != null)
            {
                EmployeeEntity employee = new EmployeeEntity();
                List<Employee> employeeList = employee.GetEmployees();
                return View(employeeList);
            }
            return RedirectToAction("Login","User");
        }
        public ActionResult AddEmp()
        {
            if (Session["login"] != null)
            {
                ViewBag.departmentList = getDepartmentList(0, 0);
                return View();
            }
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        public ActionResult AddEmp(Employee employee)
        {
            if (Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    int rowsAffected;
                    EmployeeEntity employeeEntity = new EmployeeEntity();
                    rowsAffected = employeeEntity.AddEmployee(employee);
                    if (rowsAffected > 0)
                    {
                        ViewBag.successMsg = "Values added";
                    }

                }
                ViewBag.departmentList = getDepartmentList(0, 0);
                return View();
            }
            return RedirectToAction("Login", "User");

        }
        public ActionResult Details(int id)
        {
            if(Session["login"] != null)
            {
                Employee employee = new Employee();
                EmployeeEntity employeeEntity = new EmployeeEntity();
                employee = employeeEntity.GetEmployeeById(id);
                return View(employee);
            }
            return RedirectToAction("Login", "User");
            
        }
        public ActionResult Update(int id)
        {
            if (Session["login"] != null)
            {
                ViewBag.departmentList = getDepartmentList(1, id);
                Employee employee = new Employee();
                EmployeeEntity employeeEntity = new EmployeeEntity();
                employee = employeeEntity.GetEmployeeById(id);
                return View(employee);
            }
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            if(Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    int rowsAffected;
                    EmployeeEntity employeeEntity = new EmployeeEntity();
                    rowsAffected = employeeEntity.UpdateEmployee(employee);
                    var ImgPath = Path.Combine(Server.MapPath("\\Images\\"), employee.Img.FileName);
                    employee.Img.SaveAs(ImgPath);
                    if (rowsAffected > 0)
                    {
                        ViewBag.successMsg = "Values Updated";
                    }

                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login","User");

        }
        public ActionResult Delete(int id)
        {
            if(Session["login"] != null)
            {
                EmployeeEntity employeeEntity = new EmployeeEntity();
                employeeEntity.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "User");
        }
        private List<SelectListItem> getDepartmentList(int choice, int id)
        {
            Department department = new Department();
            switch (choice)
            {
                case 1:
                    return department.getDepartmentListById(id);
                default:
                    return department.getDepartmentList();
            }
        }
        
    }
}