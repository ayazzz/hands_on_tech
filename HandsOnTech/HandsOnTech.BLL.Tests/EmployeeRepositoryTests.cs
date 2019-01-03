using HandsOnTech.BLL;
using HandsOnTech.BLL.Tests.Helpers;
using HandsOnTech.DAL;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class EmployeeRepositoryTests
    {
        private IWebApiHelper _webApiHelper;
        private EmployeeRepository _employeesRepo;

        [SetUp]
        public void Setup()
        {
            _webApiHelper = new FakeWebApiHelper();
            _employeesRepo = new EmployeeRepository(_webApiHelper);
        }

        [Test]
        public async Task ShouldHave2Employees()
        {
            var employees = await _employeesRepo.GetEmployeesAsync();

            Assert.IsNotNull(employees);
            Assert.AreEqual(2, employees.Count);
        }

        [Test]
        public async Task ShouldEmployeeExist()
        {
            var employeeId = 10;

            var employee = await _employeesRepo.GetEmployeeAsync(employeeId);

            Assert.IsNotNull(employee);
            Assert.AreEqual(employeeId, employee.id);
            Assert.AreEqual(144000000, employee.AnnualSalary);
        }
    }
}