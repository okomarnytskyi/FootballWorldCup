using FootballWorldCup.Implementation.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace FootballWorldCup.Implementation.Storages
{
    internal abstract class BaseStorage<T> : IStorage<T> where T : class
    {
        private readonly IDictionary<Guid, T> _storage;

        protected BaseStorage()
        {
            _storage = new ConcurrentDictionary<Guid, T>();
        }

        public T GetById(Guid id)
        {
            if (!_storage.TryGetValue(id, out var value))
            {
                throw new FootballWorldCupException("Record doesn't exist");
            }

            return value;
        }

        public ICollection<T> GetAll()
        {
            return _storage.Values;
        }

        public Guid Add(T item)
        {
            var id = Guid.NewGuid();
            _storage.Add(id, item);
            return id;
        }

        public void Delete(Guid id)
        {
            _storage.Remove(id);
        }
    }
}
