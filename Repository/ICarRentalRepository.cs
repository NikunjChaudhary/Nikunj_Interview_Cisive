using Nikunj_Interview_Cisive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nikunj_Interview_Cisive.Repository
{
    public interface ICarRentalRepository
    {
        string CarResigtration(CarDetails oDetails);
        string CarRentingRequest(CarRentingRequest oDetails);
        string CarReturnRequest(Car_Base oDetails);

        string CarDeRegistration(Car_Base oDetails);
    }
}