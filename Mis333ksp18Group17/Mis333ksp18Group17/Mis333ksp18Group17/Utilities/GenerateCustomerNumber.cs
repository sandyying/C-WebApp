using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mis333ksp18Group17.DAL;

namespace Mis333ksp18Group17.Utilities
{
    public class GenerateCustomerNumber
    {
        public static Int32 GetNextCustomerNumber()
        {
            AppDbContext db = new AppDbContext();

            Int32 intMaxCustomerNumber;
            Int32 intNextCustomerNumber;

            if (db.Users.Where(c => c.Number != 0).ToList().Count() == 0)
            {
                intMaxCustomerNumber = 5000;
            }
            else
            {
                intMaxCustomerNumber = db.Users.Max(c => c.Number);
            }

            intNextCustomerNumber = intMaxCustomerNumber + 1;
            return intNextCustomerNumber;
        }
    }
}
