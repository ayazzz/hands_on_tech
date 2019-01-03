namespace HandsOnTech.BLL
{
    public class EmployeeDTO
    {
        private double _hourly_salary;
        private readonly double _monthly_salary;

        public EmployeeDTO(double monthly_salary, double hourly_salary)
        {
            _hourly_salary = hourly_salary;
            _monthly_salary = monthly_salary;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string contractTypeName { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }

        public double AnnualSalary
        {
            get
            {
                double annualSalary = 0;

                switch (contractTypeName)
                {
                    case "HourlySalaryEmployee":
                        annualSalary = 120 * _hourly_salary * 12;
                        break;
                    default:
                        annualSalary = _monthly_salary * 12;
                        break;
                }

                return annualSalary;
            }
        }
    }
}
