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
            double alcoholgram = session.NumberOfUnits * 12;
            double tid = (DateTime.Now.Hour - session.StartTime.Hour) * 0.15;
            double vægt = session.Person.Weight * session.Person.GenderCoef;
            var Bac = (alcoholgram / vægt) - tid;
            return Bac;
        }
    }
}