﻿using Microsoft.EntityFrameworkCore;

namespace kixBG.Infrastructure.Data.Common.Repository
{
    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

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
    }
}