using HandsOnTech.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTech.BLL.Tests.Helpers
{
    public class FakeWebApiHelper : IWebApiHelper
    {
        public async Task<IList<EmployeeModel>> GetEmployees()
        {
            var list = new List<EmployeeModel>
            {
                new EmployeeModel()
                {
                    id = 10,
                    name = "Ayaz",
                    contractTypeName = "MonthlySalaryEmployee",
                    hourlySalary = 75000,
                    monthlySalary = 12000000,
                    roleId = 5,
                    roleDescription = "Sr. Developer",
                    roleName = "Sr. Developer"
                },
                 new EmployeeModel()
                {
                    id = 12,
                    name = "Diana",
                    contractTypeName = "HourlySalaryEmployee",
                    hourlySalary = 80000,
                    monthlySalary = 12800000,
                    roleId = 5,
                    roleDescription = "Sr. Developer",
                    roleName = "Sr. Developer"
                }
            };

            return await Task.FromResult(list);
        }
    }
}
