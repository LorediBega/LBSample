using AutoMapper;
using LBSample.Domain.Interface;
using LBSample.Entity.DTO;
using LBSample.Entity.Models;
using LBSample.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LBSample.Domain.Concrete
{
    public class TestDomain : ITestDomain
    {
        private readonly IMapper _mapper;
        internal ITestRepository testRepository;
        public TestDomain(IServiceProvider svcProvider, IMapper mapper)
        {
            _mapper = mapper;
            testRepository = svcProvider.GetRequiredService<ITestRepository>();
        }

        public SampleTable GetFirst()
        {
            return testRepository.GetFirst();
        }

        public SampleTableDTO GetbyId(int id)
        {
            return _mapper.Map<SampleTableDTO>(testRepository.GetbyId(id));
        }
    }
}
