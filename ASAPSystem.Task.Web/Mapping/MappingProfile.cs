using ASAPSystem.Assignment.Core.Models;
using ASAPSystem.Assignment.Web.Models.Address;
using ASAPSystem.Assignment.Web.Models.Person;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAPSystem.Assignment.Web.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressModel, Address>().ReverseMap();
            CreateMap<PersonModel, Person>().ReverseMap();
        }
    }
}
