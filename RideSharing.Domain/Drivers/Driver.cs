﻿using RideSharing.Abstractions.Domain;
using RideSharing.Domain.Cars;
using RideSharing.Domain.Common;
using RideSharing.Domain.Trips;

namespace RideSharing.Domain.Drivers
{
    public sealed class Driver : AggregateRoot
    {

        private Driver() { }

        internal Driver(Person person, Car car, string licenseNo)
        {
            if (string.IsNullOrWhiteSpace(licenseNo))
            {
                throw new ArgumentException($"'{nameof(licenseNo)}' cannot be null or empty.", nameof(licenseNo));
            }

            Person = person ?? throw new ArgumentNullException(nameof(person));
            Car = car ?? throw new ArgumentNullException(nameof(car));

            LicenseNo = licenseNo;
            CreatedAt = DateTime.UtcNow;
        }


        public Person Person { get; private set; }
        public string LicenseNo { get; private set; }
        public DateTime CreatedAt { get; }
        public Car Car { get; private set; }


        private readonly List<Trip> _trips = new();
        public IReadOnlyCollection<Trip> Trips => _trips.AsReadOnly();

        public void UpdatePerson(Person person)
        {
            if (person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            Person = person;
        }

        public void UpdateLicenseNo(string licenseNo)
        {
            if (string.IsNullOrWhiteSpace(licenseNo))
            {
                throw new ArgumentException($"'{nameof(licenseNo)}' cannot be null or whitespace.", nameof(licenseNo));
            }


            LicenseNo = licenseNo;
        }

        public void UpdateCar(Car car)
        {
            if (car is null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            Car = car;
        }
        public void AddTrip(Trip trip)
        {
            if (trip is null)
            {
                throw new ArgumentNullException(nameof(trip));
            }

            _trips.Add(trip);
        }

        public void UpdateTripRating(Guid tripId, int rating)
        {
            var trip = _trips.SingleOrDefault(t => t.Id == tripId);

            if (trip is null)
            {
                throw new InvalidOperationException(nameof(trip));
            }

            trip.UpdateDriverRating(rating);
        }

    }
}