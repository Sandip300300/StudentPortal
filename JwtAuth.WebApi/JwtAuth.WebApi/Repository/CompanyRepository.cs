using JwtAuth.WebApi.Models;

namespace JwtAuth.WebApi.Repository
{
    public class CompanyRepository :ICompany
    {
        

        public string GetCompanyById(int id)
        {
            return "Hawar It Limited"+id;
        }
    }
}
