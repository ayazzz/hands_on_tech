using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTech.DAL
{
    public interface IWebApiHelper
    {
        Task<IList<EmployeeModel>> GetEmployees();
    }
}
