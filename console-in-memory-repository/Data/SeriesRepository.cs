using Console_in_memory_repository.Data.Interfaces;
using Console_in_memory_repository.Entities;
using System.Collections.Generic;

namespace Console_in_memory_repository.Data
{
    public class SeriesRepository : IRepository<Series>
    {
        private static SeriesRepository instance;
        private readonly List<Series> series = new List<Series>();

        public static SeriesRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new SeriesRepository();
            }
            return instance;
        }

        public void Delete(int id)
        {
            series[id - 1].Active = false;
        }

        public List<Series> getAll() => series.FindAll(s => s.Active);

        public Series getById(int id) => series.Find(s => s.Id == id);

        public int GetNextId() => series.Count + 1;

        public void Save(Series entity)
        {
            series.Add(entity);
        }

        public void Update(int id, Series entity)
        {
            series[id - 1] = entity;
        }
    }
}
