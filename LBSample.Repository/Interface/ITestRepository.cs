using LBSample.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBSample.Repository.Interface
{
    public interface ITestRepository : IRepository<SampleTable, int>
    {
        SampleTable GetFirst();
        SampleTable GetbyId(int id);
    }
}
