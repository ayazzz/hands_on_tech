using HandsOnTech.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTech.BLL
{
    public interface IEmployeeRepository
    {
        Task<IList<EmployeeDTO>> GetEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeAsync(int employeeId);
    }
}
