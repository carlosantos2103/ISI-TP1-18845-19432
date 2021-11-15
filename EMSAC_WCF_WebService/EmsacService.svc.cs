using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EMSAC_WCF_WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmsacService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmsacService.svc or EmsacService.svc.cs at the Solution Explorer and start debugging.
    public class EmsacService : IEmsacService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Infected GetDataUsingDataContract(Infected composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            return composite;
        }

        public void RegisterInfected(Infected inf, List<Isolated> iso)
        {
            
        }
    }
}
