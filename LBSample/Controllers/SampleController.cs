using LBSample.Domain.Interface;
using LBSample.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LBSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private ITestDomain testDomain;

        public SampleController(IServiceProvider serviceProvider)
        {
            testDomain = serviceProvider.GetRequiredService<ITestDomain>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var test = testDomain.GetFirst();//Entity framework
            var test1 = testDomain.GetbyId(Constants.sampleId);//Dapper

            return Ok();
        }
    }
}
