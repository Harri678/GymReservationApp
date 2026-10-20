using System;
using System.Collections.Generic;
using System.Text;

namespace GymReservationApp
{
    internal class SingleReservation : GymReservation
    {
        public string ContactName { get; private set; }
        public int ReservationTime { get; private set; }
        public bool HasSeasonTicket { get; private set; } = false;

        public SingleReservation(string contactName, int reservationTime)
        {
            ContactName = contactName;
            ReservationTime = reservationTime;
        }

        public void buySeasonTicket()
        {
            HasSeasonTicket = true;
        }

        public string GetContactName()
        {
            return ContactName;
        }

        public int GetReservationTime()
        {
            return ReservationTime;
        }

        public int CalculatePriceToPay()
        {
            return HasSeasonTicket ? 2250 : 4500;
        }
    }
}
