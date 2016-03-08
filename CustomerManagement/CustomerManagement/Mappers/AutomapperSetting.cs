using AutoMapper;
using CustomerManagement.DAL.Models;
using CustomerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagement.Mappers
{
    public class AutomapperSetting
    {
        public IMapper CreateMapper()
        {
            MapperConfiguration config = new MapperConfiguration((c) =>
            {
                c.CreateMap<Customer, CustomerModel>();
                c.CreateMap<CustomerModel, Customer>();
            });

            return config.CreateMapper();
        }
    }
}