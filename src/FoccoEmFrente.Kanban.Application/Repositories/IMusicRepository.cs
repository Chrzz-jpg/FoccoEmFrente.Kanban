using FoccoEmFrente.Kanban.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Application.Repositories
{
    public interface IMusicRepository : IRepository<Music> 
    {
        Task<IEnumerable<Music>> GetAllAsync(Guid userId);

        Task<Music> GetByIdAsync(Guid id, Guid userId);

        Task<Music> GetByHumorAsync(string humor, Guid userId);

        Task<bool> ExistsAsync(Guid id, Guid userId);

        Music Add(Music music);

        Music Update(Music music);

        Music Remove(Music music);

    }
}
