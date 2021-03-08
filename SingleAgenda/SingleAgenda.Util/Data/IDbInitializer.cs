using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.Util.Data
{
    public interface IDbInitializer
    {
        void Initialize();
        void SeedData();
    }
}
