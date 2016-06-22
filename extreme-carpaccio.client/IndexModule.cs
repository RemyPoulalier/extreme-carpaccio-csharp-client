using System.IO;
using System.Text;

namespace xCarpaccio.client
{
    using Nancy;
    using System;
    using Nancy.ModelBinding;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => "It works !!! You need to register your server on main server.";

            Post["/order"] = _ =>
            {
                using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Console.WriteLine("Order received: {0}", reader.ReadToEnd());
                }

                

                //Construction de la grille de taxe
                GrilleTaxe grille = new GrilleTaxe();
                String[] pays = new[] {"DE","UK","FR","IT","ES","PL","RO","NL","BE","EL","CZ","PT","HU","SE","AT","BG","DK","FI","SK","IE","HR","LT","SI","LV","EE","CY","LU","MT"};
                Decimal[] reduction = new[] {1.20m, 1.21m, 1.20m, 1.25m, 1.19m, 1.21m, 1.20m};
                

                try
                {
                    var order = this.Bind<Order>();
                    Bill bill = null;
                    bill = ConstructBill.CalculerBill(order);
                    if (bill == null)
                    {
                        return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
                    }
                    //return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
                    //TODO: do something with order and return a bill if possible
                    // If you manage to get the result, return a Bill object (JSON serialization is done automagically)
                    // Else return a HTTP 404 error : return Negotiate.WithStatusCode(HttpStatusCode.NotFound);

                    return bill;
                }
                catch (Exception e )
                {
                  return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
                }

            };

            Post["/feedback"] = _ =>
            {
                var feedback = this.Bind<Feedback>();
                Console.Write("Type: {0}: ", feedback.Type);
                Console.WriteLine(feedback.Content);
                return Negotiate.WithStatusCode(HttpStatusCode.OK);
            };
        }
    }
}