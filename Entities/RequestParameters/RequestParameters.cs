using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParameters
{
    public abstract class RequestParameters //abstract classlar newlenemez ama kalıtımla alındığı sınıf new lenebilir.
    {
        public String? SearchTerm { get; set; }
    }
}
