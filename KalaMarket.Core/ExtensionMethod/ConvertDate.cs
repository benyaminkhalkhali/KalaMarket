﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ExtensionMethod
{
    public static class ConvertDate
    {
        public static string ToShamsi(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            var date = pc.GetYear(dateTime).ToString("0000") + "/" + pc.GetMonth(dateTime).ToString("00") + "/" + pc.GetDayOfMonth(dateTime).ToString("00");
            return date;
        }

        public static DateTime? ToMiladi(this string persianDate)
        {
            persianDate = persianDate.ToEnglishNumber();
            var day = Convert.ToInt32(persianDate.Substring(0, 2));
            var month = Convert.ToInt32(persianDate.Substring(3, 2));
            var year = Convert.ToInt32(persianDate.Substring(6, 4));
            return new DateTime(year, month, day, new PersianCalendar());

        }


        private static readonly string[] Pn = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
        private static readonly string[] En = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public static string ToEnglishNumber(this string Num)
        {
            if (string.IsNullOrEmpty(Num))
                return null;

            for (var i = 0; i < 10; i++)
                Num = Num.Replace(Pn[i], En[i]);

            return Num;
        }
        public static string UpdateToShamsi(this DateTime? dateTime)
        {
            if (!string.IsNullOrEmpty(dateTime.ToString()))
                return "";

            PersianCalendar pc = new PersianCalendar();
            var date = pc.GetDayOfMonth(dateTime.Value).ToString("00")
                + "/" + pc.GetMonth(dateTime.Value).ToString("00")
                + "/" + pc.GetYear(dateTime.Value).ToString("0000");
            return date;
        }
    }
}
