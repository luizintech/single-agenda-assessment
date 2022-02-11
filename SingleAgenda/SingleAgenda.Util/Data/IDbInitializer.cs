using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.Infra.IoC.Data
{
    public interface IDbInitializer
    {
        void Initialize();
        void SeedData();
    }
}
