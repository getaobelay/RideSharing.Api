﻿using MediatR;
using RideSharing.Abstractions.Commands;
using RideSharing.Shared;
using RideSharing.Shared.Enums;

namespace RideSharing.Application.Customers.CreateCustomer
{
    public record CreateCustomerCommand : ICommandRequest<Result<CustomerDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}