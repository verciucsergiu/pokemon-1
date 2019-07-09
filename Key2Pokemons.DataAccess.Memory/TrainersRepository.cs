using System;
using System.Collections.Generic;
using System.Linq;
using Key2Pokemons.Domain;

namespace Key2Pokemons.DataAccess.Memory
{
    public class TrainersRepository : ITrainerRepository
    {
        private static readonly ICollection<Trainer> trainers = new List<Trainer>()
        {
            new Trainer("Alex")
        };

        public IReadOnlyCollection<Trainer> GetAll() => trainers.ToList().AsReadOnly();

        public Trainer GetById(Guid id) => trainers.FirstOrDefault(x => x.Id == id);
        public void Add(Trainer trainer)
        {
            trainers.Add(trainer);
        }

        public void Update(Trainer trainer)
        {
        }

        public void Remove(Trainer trainer)
        {
            trainers.Remove(trainer);
        }

        public void Save()
        {
        }
    }
}
