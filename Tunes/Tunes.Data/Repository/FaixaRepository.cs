﻿using Tunes.Business.Interfaces;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class FaixaRepository : Repository<Faixa>, IFaixaRepository
    {
        public FaixaRepository(TunesContext context) : base(context) { }
    }
}