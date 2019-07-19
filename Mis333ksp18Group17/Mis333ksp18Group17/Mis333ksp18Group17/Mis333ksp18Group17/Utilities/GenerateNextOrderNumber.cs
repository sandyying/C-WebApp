using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mis333ksp18Group17.DAL;

namespace Mis333ksp18Group17.Utilities
{
    public class GenerateNextOrderNumber
    {
        public static Int32 GetNextOrderNumber()
        {
            AppDbContext db = new AppDbContext();

            Int32 intMaxOrderNumber;
            Int32 intNextOrderNumber;

            if (db.Orders.Count() == 0)
            {
                intMaxOrderNumber = 10000;
            }
            else
            {
                intMaxOrderNumber = db.Orders.Max(c => c.OrderNumber);
            }

            intNextOrderNumber = intMaxOrderNumber + 1;
            return intNextOrderNumber;
        }
    }
}