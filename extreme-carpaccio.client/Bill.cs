using System.CodeDom;

namespace xCarpaccio.client
{
    public class Bill
    {
        public decimal total { get; set; }

        public decimal CalculReduction(decimal somme)
        {
            if (somme >= 1000m)
            {
                return somme*(1.03m);
            }
            else if (somme >= 5000m)
            {
                return somme*(1.05m);

            }
            else if (somme >= 7000m)
            {
                return somme = somme*(1.07m);

            }
            else if (somme >= 10000m)
            {
                return somme = somme*(1.10m);

            }
            else if (somme >= 50000m)
            {
                return somme*(1.15m);
            }
            else
            {
                return somme;
            }
        }
    }
}
