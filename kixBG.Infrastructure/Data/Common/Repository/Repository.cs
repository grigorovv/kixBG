﻿using kixBG.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace kixBG.Infrastructure.Data.Common.Repository
{
    public class Repository : IRepository
    {
        private readonly MainDbContext dbContext;

        public Repository(MainDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public IQueryable<int> FindCityByName(string name)
        {
            return  dbContext.Cities
                .Where(c => c.Name == name)
                .Select(c => c.Id);
        }

        public void DeleteItem<T>(T entity) where T : class
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
