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
            decimal[] totalPrices = new decimal[commande.Prices.Length];

            for (int i = 0; i < commande.Prices.Length; i++)
            {
                //Calcul des taxes relatives au pays

                switch (commande.Country)
                {
                    case "GER":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.20m;
                        break;
                    case "ES":
                        totalPrices[i] = (commande.Prices[i] * commande.Quantities[i]) * 1.19m;
                        break;
                    case "AT":
                        totalPrices[i] = (commande.Prices[i] * commande.Quantities[i]) * 1.22m;
                        break;

                };
                

            }
            decimal total = totalPrices.Sum();
            //Applcation des réductions
            if (total >= 1000)
            {
                decimal reduction = total * 0.03m;
                total = total - reduction;
            }
            else if (total >= 5000)
            {
                decimal reduction = total * 0.05m;
                total = total - reduction;
            }
            else if (total >= 7000)
            {
                decimal reduction = total * 0.07m;
                total = total - reduction;
            }
            else if (total >= 10000)
            {
                decimal reduction = total * 0.10m;
                total = total - reduction;
            }
            else if (total >= 50000)
            {
                decimal reduction = total * 0.15m;
                total = total - reduction;
            }

            total = Math.Round(total, 2);
            Bill bill = new Bill();
            bill.total = total;
            return bill;
        }
    }
}
