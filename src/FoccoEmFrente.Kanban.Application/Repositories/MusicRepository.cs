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
    public class MusicRepository : IMusicRepository
    {
        protected readonly KanbanContext DbContext;
        protected readonly DbSet<Music> DbSet;
        public IUnitOfWork UnitOfWork => DbContext;

        public MusicRepository(KanbanContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<Music>();
        }

        public Music Add(Music music)
        {
            var entrada = DbSet.Add(music);

            return entrada.Entity;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public async Task<bool> ExistsAsync(Guid id, Guid userId)
        {
            return await DbSet
                .Where(activities => activities.UserId == userId && activities.Id == id)
                .AnyAsync();
        }

        public async Task<IEnumerable<Music>> GetAllAsync(Guid userId)
        {
            return await DbSet
                           .Where(activities => activities.UserId == userId)
                           .ToListAsync();
        }

        public async Task<Music> GetByHumorAsync(string humor, Guid userId)
        {
            return await DbSet
                .Where(activities =>activities.HumorPrincipal == humor && activities.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<Music> GetByIdAsync(Guid id, Guid userId)
        {
            return await DbSet
                           .Where(activities => activities.UserId == userId && activities.Id == id)
                           .FirstOrDefaultAsync();
        }

        public Music Remove(Music music)
        {
            var removida = DbSet.Remove(music);

            return removida.Entity;
        }

        public Music Update(Music music)
        {
            var atualizada = DbSet.Update(music);

            return atualizada.Entity;
        }

    }
}
