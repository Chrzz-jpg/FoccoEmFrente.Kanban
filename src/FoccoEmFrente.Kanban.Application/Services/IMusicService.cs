using FoccoEmFrente.Kanban.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Application.Services
{
    public interface IMusicService : IDisposable
    {
        Task<IEnumerable<Music>> GetAllAsync(Guid userId);
        Task<Music> GetByIdAsync(Guid id, Guid userId);
        Task<Music> GetByHumorAsync(string humor, Guid userId);
        Task<bool> ExistAsync(Guid id, Guid userId);
        Task<Music> AddAsync(Music music);
        Task<Music> UpdateAsync(Music music);
        Task<Music> RemoveAsync(Music music);
        Task<Music> RemoveByIdAsync(Guid id, Guid userId);
    }
}
