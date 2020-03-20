﻿using System;
using System.Transactions;

namespace OelApp
{
    //For kvinder:
    //Alkohol i gram / (kropsvægten i kg x 60 %) - (0,15 x timer fra drikkestart) = promille
    //For mænd:
    //Alkohol i gram / (kropsvægten i kg x 70 %) - (0,15 x timer fra drikkestart) = promille
    public static class UnitConversionUtility
    {
        public static double CalculateBac(Session session)
        {
            double genderCoef = session.Person.Gender == "m" ? 0.7 : 0.6;
            double alcoholgram = session.NumberOfUnits * 12;
            double tid = (DateTime.Now.Hour - session.StartTime.Hour) * 0.15;
            double vægt = session.Person.Weight * genderCoef;
            var Bac = (alcoholgram / vægt) - tid;
            return Math.Round(Bac, 2);
        }
    }
}