using FoccoEmFrente.Kanban.Application.Context;
using FoccoEmFrente.Kanban.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Application.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        protected readonly KanbanContext DbContext;
        protected readonly DbSet<Activity> DbSet;

        public IUnitOfWork UnitOfWork => DbContext;

        public ActivityRepository(KanbanContext context) 
        {
            DbContext = context;
            DbSet = DbContext.Set<Activity>();
        }

        public async Task<IEnumerable<Activity>> GetAllAsync(Guid userId)
        {
            return await DbSet
                .Where(activities => activities.UserId == userId)
                .ToListAsync();
        }

        public async Task<Activity> GetByIdAsync(Guid id, Guid userId)
        {
            return await DbSet
                .Where(activities => activities.UserId == userId && activities.Id == id)
                .FirstOrDefaultAsync();
        }
        
        public async Task<bool> ExistsAsync(Guid id, Guid userId)
        {
            return await DbSet
                .Where(activities => activities.UserId == userId && activities.Id == id)
                .AnyAsync();
        }

        public Activity Add(Activity activity)
        {
            var entrada = DbSet.Add(activity);
            
            return entrada.Entity;
        }

        public Activity Update(Activity activity)
        {
            var atualizada = DbSet.Update(activity);
            
            return atualizada.Entity;
        }
        public Activity Remove(Activity activity)
        {
            var removida = DbSet.Remove(activity);
            
            return removida.Entity;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        
    }
}
