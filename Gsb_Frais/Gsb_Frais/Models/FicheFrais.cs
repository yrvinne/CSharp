

using System;

namespace Gsb_Frais.Models
{
    public class FicheFrais
    {
        public string IdVisiteur { get; set; }

        public string Mois { get; set; }

        public int NbJustificatif { get; set; }

        public  DateTime MoisToDateTime()
        {

            int y = int.Parse(Mois.Substring(0, 4));
            int m = int.Parse(Mois.Substring(4, 2));
            return new DateTime(y, m, 1);
        }
    }
}
