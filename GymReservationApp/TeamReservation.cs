using System;
using System.Collections.Generic;
using System.Text;

namespace GymReservationApp
{
    internal class TeamReservation : GymReservation
    {
        private string contactName;
        private List<string> teamMembers;
        private int reservationTime;

        public string ContactName { get => contactName; private set => contactName = value; }
        public List<string> TeamMembers { get => teamMembers; private set => teamMembers = value; }
        public int ReservationTime { get => reservationTime; private set => reservationTime = value; }

        public TeamReservation(string contactName, List<string> teamMembers, int reservationTime)
        {
            ContactName = contactName;
            TeamMembers = teamMembers;
            ReservationTime = reservationTime;
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
            return 9000 / (TeamMembers.Count + 1);
        }
    }
}
