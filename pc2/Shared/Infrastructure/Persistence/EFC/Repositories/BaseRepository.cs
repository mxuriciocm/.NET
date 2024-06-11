using Microsoft.EntityFrameworkCore;
using pc2.Shared.Domain.Repositories;
using pc2.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace pc2.Shared.Infrastructure.Persistence.EFC.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext Context;
    
    public BaseRepository(AppDbContext context)
    {
        this.Context = context;
    }
    
    public async Task AddAsync(TEntity entity)
    {
        await this.Context.Set<TEntity>().AddAsync(entity);
    }

    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }
}