using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace extreme_carpaccio.tests
    
{
    public class Tests
    {
        [Test]
        public void calculer_la_note()
        {
            Assert.IsFalse(false);
            Assert.That(true,Is.True);
        }

        [Test]
        public void ajouter_un_produit()
        {
            var toto = 3;
            Assert.That(toto,Is.EqualTo(3));
        }
    }
}
