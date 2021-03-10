using System;
using System.Collections.Generic;

namespace FootballWorldCup.Implementation.Storages
{
    internal interface IStorage<T>
    {
        T GetById(Guid id);
        ICollection<T> GetAll();
        Guid Add(T item);
        void Delete(Guid id);
    }
}