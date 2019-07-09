using System;
using System.Collections.Generic;

namespace Key2Pokemons.Domain
{
    public interface ITrainerRepository
    {
        IReadOnlyCollection<Trainer> GetAll();

        Trainer GetById(Guid id);

        void Add(Trainer trainer);

        void Update(Trainer trainer);

        void Remove(Trainer trainer);

        void Save();
    }
}