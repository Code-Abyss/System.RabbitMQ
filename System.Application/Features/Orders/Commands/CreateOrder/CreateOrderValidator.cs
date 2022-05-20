using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
namespace System.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOredrValidator:AbstractValidator<CreateOrderCommand>
    {
        public CreateOredrValidator()
        {
            RuleFor(p => p.Type).IsInEnum();
        }
    }
}
