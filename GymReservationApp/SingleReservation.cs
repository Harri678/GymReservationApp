using System;
using System.Collections.Generic;
using System.Text;

namespace GymReservationApp
{
    internal class SingleReservation : GymReservation
    {
        private string contactName;
        private int reservationTime;
        private bool hasSeasonTicket;

        public string ContactName { get => contactName; private set => contactName = value; }
        public int ReservationTime { get => reservationTime; private set => reservationTime = value; }
        public bool HasSeasonTicket { get => hasSeasonTicket; private set => hasSeasonTicket = value; }

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
