using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xCarpaccio.client
{
    public class ConstructBill
    {

        public static Bill CalculerBill(Order commande)
        {
            Bill facture = new Bill();
            if (commande.Reduction!="STANDARD")
                return null;

            decimal[] totalPrices = new decimal[commande.Prices.Length];

            for (int i = 0; i < commande.Prices.Length; i++)
            {
                //Calcul des taxes relatives au pays

                switch (commande.Country)
                {
                    //case "GER":
                    //    totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.20m;
                    //    break;
                    //case "ES":
                    //    totalPrices[i] = (commande.Prices[i] * commande.Quantities[i]) * 1.19m;
                    //    break;
                    //case "AT":
                    //    totalPrices[i] = (commande.Prices[i] * commande.Quantities[i]) * 1.22m;
                    //    break;
                    //case "UK":
                    //    totalPrices[i] = (commande.Prices[i] * commande.Quantities[i]) * 1.22m;
                    //    break;
                    //totalPrices[i] = (commande.Prices[i] * commande.Quantities[i]) *
                    case "ES":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.19m;
                        break;
                    case "AT":
                        totalPrices[i] = (commande.Prices[i] * commande.Quantities[i]) * 1.22m;
                        break;
                    case "DE":
                        totalPrices[i] = (commande.Prices[i] * commande.Quantities[i]) * 1.20m;
                        break;
                    case "UK":
                        totalPrices[i] = (commande.Prices[i] * commande.Quantities[i]) * 1.21m;
                        break;
                    case "FR":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.20m;
                        break;
                    case "IT":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.25m;
                        break;
                    case "PL":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.21m;
                        break;
                    case "RO":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.20m;
                        break;
                    case "NL":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.20m;
                        break;
                    case "BE":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.24m;
                        break;
                    case "EL":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.20m;
                        break;
                    case "CZ":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.19m;
                        break;
                    case "PT":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.23m;
                        break;
                    case "HU":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.27m;
                        break;
                    case "SE":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.23m;
                        break;
                    case "BG":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.21m;
                        break;
                    case "DK":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.21m;
                        break;
                    case "FI":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.17m;
                        break;
                    case "SK":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.18m;
                        break;
                    case "IE":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.21m;
                        break;
                    case "HR":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.23m;
                        break;
                    case "LT":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.23m;
                        break;
                    case "SI":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.24m;
                        break;
                    case "LV":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.20m;
                        break;
                    case "EE":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.22m;
                        break;
                    case "CY":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.21m;
                        break;
                    case "LU":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.25m;
                        break;
                    case "MT":
                        totalPrices[i] = (commande.Prices[i]*commande.Quantities[i])*1.20m;
                        break;
                    default:
                        return null;
                 
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
