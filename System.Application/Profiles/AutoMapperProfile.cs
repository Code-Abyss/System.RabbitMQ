using System;
using System.Text;
using System.Collections.Generic;
using AutoMapper;
using System.Domain;
using System.Application.Features.Orders.Commands.CreateOrder;

namespace System.Application.Profiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
        }
    }
}

