using ASP_NET.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_Kurganskiy.Data
{
    public class ASP_NET_KurganskiyContextInitializer
    {
        private readonly ASP_NET_Context _db;

        public ASP_NET_KurganskiyContextInitializer(ASP_NET_Context db) => _db = db;
    }
}
