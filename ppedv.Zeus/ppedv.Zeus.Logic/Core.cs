using ppedv.Zeus.Model.Contracts;
using System;

namespace ppedv.Zeus.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repository)
        {
            this.Repository = repository;
        }

        public Core() : this(new Data.EF.EfRepository())
        { }

    }
}
