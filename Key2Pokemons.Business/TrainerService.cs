using System;
using System.Collections.Generic;
using Key2Pokemons.Domain;

namespace Key2Pokemons.Business
{
    public sealed class TrainerService
    {
        private readonly ITrainerRepository repository;

        public TrainerService(ITrainerRepository repository)
        {
            this.repository = repository;
        }

        public IReadOnlyCollection<Trainer> GetAll()
        {
            return repository.GetAll();
        }

        public Trainer GetTrainer(Guid trainerId)
        {
            return repository.GetById(trainerId);
        }

        public Guid Create(string name)
        {
            var trainer = new Trainer(name);
            repository.Add(trainer);
            repository.Save();

            return trainer.Id;
        }

        public void Update(Guid id, string name)
        {
            var trainer = repository.GetById(id);
            trainer.ChangeName(name);

            repository.Update(trainer);
            repository.Save();
        }

        public void LevelUp(Guid trainerId)
        {
            var trainer = repository.GetById(trainerId);
            trainer.LevelUp();

            repository.Update(trainer);
            repository.Save();
        }

        public void Disqualify(Guid trainerId)
        {
            var trainer = repository.GetById(trainerId);
            repository.Remove(trainer);
            repository.Save();
        }
    }
}
