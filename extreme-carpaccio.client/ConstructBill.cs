using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xCarpaccio.client
{
    public class ConstructBill
    {
        private static Decimal tax;
        public static Bill CalculerBill(Order commande)
        {
            Bill facture = new Bill();
            decimal totalTaxe = 0m;
            decimal articleHT = 0m;
            decimal totalHT = 0m;

            for (int i = 0; i < commande.Prices.Length; i++)
            {
                articleHT = commande.Prices[i]*commande.Quantities[i];
                totalHT += articleHT;

                //Calcul des taxes relatives au pays
                commande.Country.ToUpper();
                switch (commande.Country)
                {
                    case "GER":
                        totalTaxe = Math.Round(1.20m,2);
                        break;
                    case "ES":
                        totalTaxe = Math.Round(1.19m, 2);
                        break;
                    case "AT":
                        totalTaxe = Math.Round(1.22m, 2);
                        break;

                };
              }
            facture.total = Math.Round((totalTaxe * totalHT), 2);
            //Applcation des réductions

            if (totalTaxe >= 50000)
            {
                facture.total = Math.Round((facture.total*0.85m), 2);
            }


            return facture;
        }
    }
}
