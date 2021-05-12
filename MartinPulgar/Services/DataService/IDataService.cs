using MartinPulgar.Models;
using System.Net;
using System.Threading.Tasks;

namespace MartinPulgar.Services
{
    public interface IDataService
    {
        Task<HttpStatusCode> UplodData(DataModel dataModel);
    }
}