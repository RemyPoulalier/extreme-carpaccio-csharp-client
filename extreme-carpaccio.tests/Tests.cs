using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using xCarpaccio.client;

namespace extreme_carpaccio.tests
    
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void calculer_la_note()
        {
            Assert.IsFalse(false);
            Assert.That(true,Is.True);
        }

        [Test]
        public void calcul_facture_1_article()
        {
            Order commande = new Order();
            commande.Prices = new[] { 15.99m };
            commande.Quantities = new[] {1};
            commande.Country = "ES";
            commande.Reduction = "STANDARD";

            Bill facture = ConstructBill.CalculerBill(commande);

            Assert.That(facture.total,Is.EqualTo(19.03m));
        }

        [Test]
        public void calcul_facture()
        {
            Order commande = new Order();
            commande.Prices = new[] {4.1m, 8.03m, 86.83m, 65.62m, 44.82m};
            commande.Quantities = new[] {10, 3, 5, 4, 5};
            commande.Country = "AT";
            commande.Reduction = "STANDARD";
            Bill facture = ConstructBill.CalculerBill(commande);
            Assert.That(facture.total, Is.EqualTo(1166.62m));
        }
    }
}
