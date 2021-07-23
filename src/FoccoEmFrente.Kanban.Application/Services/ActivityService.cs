using FoccoEmFrente.Kanban.Application.Context;
using FoccoEmFrente.Kanban.Application.Entities;
using FoccoEmFrente.Kanban.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<IEnumerable<Activity>> GetAllAsync(Guid userId)
        {
            return await _activityRepository.GetAllAsync(userId);
        }

        public async Task<Activity> GetByIdAsync(Guid id, Guid userId)
        {
            return await _activityRepository.GetByIdAsync(id, userId);
        }
        public async Task<bool> ExistAsync(Guid id, Guid userId)
        {
            return await _activityRepository.ExistsAsync(id, userId);
        }
        public async Task<Activity> AddAsync(Activity activity)
        {
            var newActivity = _activityRepository.Add(activity);

            await _activityRepository.UnitOfWork.CommitAsync();
         
            return  newActivity;
        }
        public async Task<Activity> UpdateAsync(Activity activity)
        {
            var activityExists = await ExistAsync(activity.Id, activity.UserId);

            if (!activityExists)
                throw new Exception("A atividade não foi encontrada");
           
            //se a atividade existir quer dizer que eu sou o dono dela
            var updatedActivity = _activityRepository.Update(activity);

            await _activityRepository.UnitOfWork.CommitAsync();

            return updatedActivity;
        }
        public async Task<Activity> RemoveAsync(Activity activity)
        {
            var activityExists = await ExistAsync(activity.Id, activity.UserId);

            if (!activityExists)
                throw new Exception("A atividade não foi encontrada");

            var deletedActivity = _activityRepository.Remove(activity);

            await _activityRepository.UnitOfWork.CommitAsync();

            return deletedActivity;
        }
        public async Task<Activity> RemoveByIdAsync(Guid id, Guid userId)
        {
            var activityToBeRemoved = await GetByIdAsync(id, userId);

            if (activityToBeRemoved == null)
                throw new Exception("A atividade não foi encontrada");

            var deletedActivity = _activityRepository.Remove(activityToBeRemoved);

            await _activityRepository.UnitOfWork.CommitAsync();

            return deletedActivity;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        

    }
}
