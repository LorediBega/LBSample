using AutoMapper;
using LBSample.Entity.DTO;
using LBSample.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBSample.Entity.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SampleTable, SampleTableDTO>().ReverseMap(); 
        }
    }
}
