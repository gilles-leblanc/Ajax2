using Ajax2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ajax2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new DepartmentsModel
            {
                Filtered = true,
                Departments = GetDepartments(filtered: true),
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult FilterDepartmentsAjax(DepartmentsModel model)
        {
            var updatedModel = new DepartmentsModel
            {
                Filtered = model.Filtered,
                Departments = GetDepartments(filtered: model.Filtered),
            };

            if (Request.IsAjaxRequest())
                return PartialView("DepartmentsTablePartial", updatedModel);

            return View("Index", updatedModel);
        }

        private IEnumerable<DepartmentModel> GetDepartments(bool filtered)
        {
            var departments = new List<DepartmentModel>
            {
                new DepartmentModel { Id = 1, Name = "Sales" },
                new DepartmentModel { Id = 2, Name = "Accounting" },
                new DepartmentModel { Id = 3, Name = "Marketing" },
                new DepartmentModel { Id = 4, Name = "HR" },
                new DepartmentModel { Id = 5, Name = "IT" },
                new DepartmentModel { Id = 6, Name = "Customer Support" },
            };

            if (filtered)
                return departments.Where(x => x.Id < 4);

            return departments;
        }
    }
}