using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ExceptionKata
{
    public class BookingRequest
    {
        private int? numberOfSeats;
        private string date;

        public BookingRequest(int? numberOfSeats, string date)
        {
            this.numberOfSeats = numberOfSeats;
            this.date = date;
        }

        public void Check()
        {
            List<string> notification = new List<string>();
            Validate(notification);
            if (notification.Count > 0)
            {
                throw new ArgumentException(notification.FirstOrDefault());
            }
        }

        private void Validate(List<string> notification)
        {
            if (date == null)
            {
                notification.Add("date is missing");
            }

            DateTime parsedDate;
            try
            {
                parsedDate = DateTime.Parse(date);
            }
            catch (FormatException e)
            {
                parsedDate = DateTime.MaxValue;
                notification.Add("Invalid format for date");
            }
            if (parsedDate != DateTime.MaxValue)
            {
                if (parsedDate < DateTime.Now)
                {
                    notification.Add("date cannot be before today");
                }
            }
            if (numberOfSeats == null)
            {
                notification.Add("number of seats cannot be null");
            }
            if (numberOfSeats < 1)
            {
                notification.Add("number of seats must be positive");
            }
        }
    }

}
