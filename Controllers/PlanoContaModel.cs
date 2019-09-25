using Microsoft.AspNetCore.Http;

namespace MyFinance.Controllers
{
    public class PlanoContaModel
    {
        public PlanoContaModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public IHttpContextAccessor HttpContextAccessor { get; internal set; }
    }
}