using System;
using NUnit.Framework;

namespace ExceptionKata
{
    [TestFixture]
    class TestBookingRequest
    {
        private class checking_a_booking_request_with_a_null_date
        {
            [Test]
            [ExpectedException]
            public void throws_an_exception()
            {
                new BookingRequest(1, null).Check();
            }
        }

        private class checking_a_booking_request_with_an_invalid_date
        {
            [Test]
            [ExpectedException]
            public void throws_an_exception()
            {
                new BookingRequest(1, "wibble").Check();
            }
        }

        private class checking_a_booking_request_with_an_old_date
        {
            [Test]
            [ExpectedException]
            public void throws_an_exception()
            {
                new BookingRequest(1, DateTime.Now.Subtract(new TimeSpan(1,0,0)).ToString()).Check();
            }
        }

        private class checking_a_booking_request_with_a_null_number_of_seats
        {
            [Test]
            [ExpectedException]
            public void throws_an_exception()
            {
                new BookingRequest(null, DateTime.Now.Add(new TimeSpan(1, 0, 0)).ToString()).Check();
            }
        }

        private class checking_a_booking_request_with_zero_seats
        {
            [Test]
            [ExpectedException]
            public void throws_an_exception()
            {
                new BookingRequest(0, DateTime.Now.Add(new TimeSpan(1, 0, 0)).ToString()).Check();
            }
        }
    }
}
