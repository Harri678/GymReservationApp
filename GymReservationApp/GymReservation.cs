using System;
using System.Collections.Generic;
using System.Text;

namespace GymReservationApp
{
    internal interface GymReservation
    {
        string GetContactName();
        int GetReservationTime();
        int CalculatePriceToPay();
    }
}
