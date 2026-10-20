using System;
using System.Collections.Generic;
using System.Text;

namespace GymReservationApp
{
    internal class Gym
    {
        public List<GymReservation> Reservations = new List<GymReservation>();

        public bool addReservation(GymReservation reservation)
        {
            if(reservation == null) return false;

            if(reservation is TeamReservation)
            {
                bool booked = false;
                foreach (var item in Reservations)
                {
                    if(item is TeamReservation && item.GetReservationTime() == reservation.GetReservationTime())
                    {
                        booked = true;
                    }

                    if(booked )
                    {
                        return false;
                    }
                }
            }
            Reservations.Add(reservation);
            return true;
        }
    }
}
