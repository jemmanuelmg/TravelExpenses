using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpenses.Web.Data.Entities;
using TravelExpenses.Common.Models;

namespace TravelExpenses.Web.Helpers
{
    interface IConverterHelper
    {
        TravelResponse ToTravelResponse(TravelEntity travelEntity);
    }
}
