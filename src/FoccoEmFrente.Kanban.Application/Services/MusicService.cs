using FoccoEmFrente.Kanban.Application.Entities;
using FoccoEmFrente.Kanban.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Application.Services
{
    public class MusicService : IMusicService
    {
        private readonly IMusicRepository _musicRepository;
        public MusicService(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository;
        }
        public async Task<Music> AddAsync(Music music)
        {
            var newMusic = _musicRepository.Add(music);

            await _musicRepository.UnitOfWork.CommitAsync();

            return newMusic;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<bool> ExistAsync(Guid id, Guid userId)
        {
            return await _musicRepository.ExistsAsync(id, userId);
        }

        public async Task<IEnumerable<Music>> GetAllAsync(Guid userId)
        {
            return await _musicRepository.GetAllAsync(userId);
        }

        public async Task<Music> GetByHumorAsync(string humor, Guid userId)
        {
            return await _musicRepository.GetByHumorAsync(humor, userId);
        }

        public async Task<Music> GetByIdAsync(Guid id, Guid userId)
        {
            return await _musicRepository.GetByIdAsync(id, userId);
        }

        public async Task<Music> RemoveAsync(Music music)
        {
            var musicExists = await ExistAsync(music.Id, music.UserId);

            if (!musicExists)
                throw new Exception("A música não foi encontrada");

            var deletedMusic = _musicRepository.Remove(music);

            await _musicRepository.UnitOfWork.CommitAsync();

            return deletedMusic;
        }

        public async Task<Music> RemoveByIdAsync(Guid id, Guid userId)
        {
            var musicToBeRemoved = await GetByIdAsync(id, userId);

            if (musicToBeRemoved == null)
                throw new Exception("A música não foi encontrada");

            var deletedMusic = _musicRepository.Remove(musicToBeRemoved);

            await _musicRepository.UnitOfWork.CommitAsync();

            return deletedMusic;
        }

        public async Task<Music> UpdateAsync(Music music)
        {
            var musicExists = await ExistAsync(music.Id, music.UserId);

            if (!musicExists)
                throw new Exception("A atividade não foi encontrada");

            //se a musica existir quer dizer que eu sou o dono dela

            var updatedMusic = _musicRepository.Update(music);

            await _musicRepository.UnitOfWork.CommitAsync();

            return updatedMusic;
        }
    }
}
