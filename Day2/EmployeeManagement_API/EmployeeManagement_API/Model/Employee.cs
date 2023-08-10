namespace EmployeeManagement_API.Model
{
    public class Employee
    {
        #region Properties
        public int empNo { get; set; }
        public string empName { get; set; }
        public string empDesignation { get; set; }
        public double empSalary { get; set; }
        public bool empIsPermenant { get; set; }
        #endregion


        #region StaticData
        static List<Employee> eList = new List<Employee>()
        {
            new Employee(){ empNo=101, empName="Sachin", empDesignation="Sales", empIsPermenant=true, empSalary=4000},
            new Employee(){ empNo=102, empName="Manish", empDesignation="HR", empIsPermenant=false, empSalary=5000},
            new Employee(){ empNo=103, empName="Mohan", empDesignation="Sales", empIsPermenant=true, empSalary=8000},
            new Employee(){ empNo=104, empName="Rohit", empDesignation="Account", empIsPermenant=true, empSalary=2000},
            new Employee(){ empNo=105, empName="Rohan", empDesignation="Sales", empIsPermenant=false, empSalary=3000},
            new Employee(){ empNo=106, empName="Mike", empDesignation="Sales", empIsPermenant=true, empSalary=1200},
            new Employee(){ empNo=107, empName="Manisha", empDesignation="HR", empIsPermenant=true, empSalary=2500}
        };
        #endregion

        #region Public Methods
        public List<Employee> GetAllEmployees()
        {
            return eList;
        }

        public Employee GetEmpById(int id)
        {
            var emp = eList.Find(em => em.empNo == id);
            if (emp != null)
            {
                return emp;
            }
            throw new Exception("Employee Not found");
        }

        public List<Employee> GetEmpByDesigantion(string designation)
        {
            var emps = eList.FindAll(em => em.empDesignation == designation);
            if (emps.Count > 0)
            {
                return emps;
            }
            else
            {
                throw new Exception("0 employees found working as  " + designation);
            }
        }

        public int GetTotalEmployees()
        {
            return eList.Count;
        }

        public string AddNewEmployee(Employee newEmpObj)
        {
            //we can perform validations and throw error if data is not accepted
            if (newEmpObj.empName.Length < 3)
            {
                throw new Exception("Please enter a valid name of more than 3 characters");
            }
            eList.Add(newEmpObj);
            return "Employee Added Successfully";
        }

        public string DeleteEmployee(int id)
        {
            var emp = eList.Find(em => em.empNo == id);
            if (emp != null)
            {
                eList.Remove(emp);
                return "Employee Deleted !!";
            }
            throw new Exception("Employee not found");

        }
        public string UpdateEmployee(Employee changes)
        {
            var emp = eList.Find(em => em.empNo == changes.empNo);
            if (emp != null)
            {
                emp.empName = changes.empName;
                emp.empDesignation = changes.empDesignation;
                emp.empSalary = changes.empSalary;
                emp.empIsPermenant = changes.empIsPermenant;
                return "Employee Updated";
            }
            throw new Exception("Employee not found");
        }


        #endregion

    }
}
