using Gsb_Frais.Gateways;

namespace Gsb_Frais
{
    public class Program
    {
        public static int Main()
        {


            var gateway = new FicheFraisGateway(DatabaseHelpers.ConnectionString);


            gateway.UpdateToRB();
          
          return 0;
        }
    }
}
