using System.Threading.Tasks;
using DapperDemo.Entities;

namespace DapperDemo.Manager.Interface
{
    public interface IEmployeeManager
    {
        Task<int> Create(Employee employee);
        Task<int> Update(Employee employee);
        Task<int> Remove(long id);
    }
}