using LBSample.Entity.DTO;
using LBSample.Entity.Models;

namespace LBSample.Domain.Interface
{
    public interface ITestDomain
    {
        SampleTable GetFirst();
        SampleTableDTO GetbyId(int id);
    }
}
