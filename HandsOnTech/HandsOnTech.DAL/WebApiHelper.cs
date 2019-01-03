using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HandsOnTech.DAL
{
    public class WebApiHelper : IWebApiHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public WebApiHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<EmployeeModel>> GetEmployees()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("masglobal");
                string result = await client.GetStringAsync("/api/employees");

                var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EmployeeModel>>(result);

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
