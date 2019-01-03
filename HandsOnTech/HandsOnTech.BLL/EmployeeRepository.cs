using HandsOnTech.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnTech.BLL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IWebApiHelper _webApiHelper;

        public EmployeeRepository(IWebApiHelper webApiHelper)
        {
            _webApiHelper = webApiHelper;
        }

        public async Task<EmployeeDTO> GetEmployeeAsync(int employeeId)
        {
            try
            {
                var list = await _webApiHelper.GetEmployees();

                var employee = list.Where(x => x.id == employeeId).FirstOrDefault();
                if (employee != null)
                {
                    return Map(employee);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<EmployeeDTO>> GetEmployeesAsync()
        {
            try
            {
                var list = await _webApiHelper.GetEmployees();
                if (list != null)
                {
                    return Map(list);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IList<EmployeeDTO> Map(IList<EmployeeModel> employees)
        {
            return employees.Select(Map).ToList();
        }

        private EmployeeDTO Map(EmployeeModel employee)
        {
            return new EmployeeDTO(employee.monthlySalary, employee.hourlySalary)
            {
                id = employee.id,
                name = employee.name,
                roleId = employee.roleId,
                roleName = employee.roleName,
                roleDescription = employee.roleDescription,
                contractTypeName = employee.contractTypeName
            };
        }
    }
}
