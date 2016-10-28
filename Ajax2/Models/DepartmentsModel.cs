using System.Collections.Generic;

namespace Ajax2.Models
{
    public class DepartmentsModel
    {
        public bool Filtered { get; set; }
        public IEnumerable<DepartmentModel> Departments { get; set; }

        public DepartmentsModel()
        {
            Departments = new List<DepartmentModel>();
        }
    }
}