using System;


namespace Gsb_Frais
{
    public abstract class DateManager
    {

        public static string GetMoisPrecedent()
        {
            return GetMoisPrecedent(DateTime.Now);
        }

        public static string GetMoisPrecedent(DateTime date)
        {
            int month = date.AddMonths(-1).Month;
          
            if(month > 10)
            {
                return "0" + month.ToString();

            }
            return month.ToString();
        }


        public static string GetMoisSuivant()
        {
            return GetMoisSuivant(DateTime.Now);
        }


        public static string GetMoisSuivant(DateTime date)
        {
            int month = date.AddMonths(1).Month;

            if (month > 10)
            {
                return "0" + month.ToString();
            }
            return month.ToString();
        }

 
        public static bool Entre(int jourDebut, int jourFin, DateTime date)
        {
            int jour = date.Day;

            return jour >= jourDebut && jour <= jourFin;
        }

        public static bool Entre(int jourDebut, int jourFin)
        {

            return Entre(jourDebut, jourFin, DateTime.Now);
        }

    }

}
