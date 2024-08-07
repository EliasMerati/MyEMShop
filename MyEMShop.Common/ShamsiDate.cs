﻿using System;
using System.Globalization;

namespace MyEMShop.Common
{
    public static class ShamsiDate
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new();
            return pc.GetYear(value) + "/" 
                 + pc.GetMonth(value).ToString("00") + "/" 
                 + pc.GetDayOfMonth(value).ToString("00");
        }
    }
}
