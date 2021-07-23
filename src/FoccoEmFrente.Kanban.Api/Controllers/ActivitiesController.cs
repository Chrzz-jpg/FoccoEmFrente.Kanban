using FoccoEmFrente.Kanban.Api.Controllers.Attributes;
using FoccoEmFrente.Kanban.Application.Entities;
using FoccoEmFrente.Kanban.Application.Repositories;
using FoccoEmFrente.Kanban.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModelState]
    [Authorize]
    public class ActivitiesController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IActivityService _activityService;
        public ActivitiesController(IActivityService activityService, UserManager<IdentityUser> userManager)
        {
            _activityService = activityService;
            _userManager = userManager;
        }

        protected Guid userId => Guid.Parse(_userManager.GetUserId(User));

        [HttpGet]
        public async Task<IActionResult> ListarAsync()
        {
            var activities = await _activityService.GetAllAsync(userId);
            
            if (activities == null)
                throw new Exception("Atividade não encontrada");
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Selecionar(Guid id)
        {
            var activities = await _activityService.GetByIdAsync(id, userId);

            //Caso a pesquisa não encontre o item
            //o retorno será um 404-NotFound sem mais info's
            if (activities == null)
                return NotFound();

            return Ok(activities);
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(Activity activity)
        {
            activity.UserId = userId;

            var newActivity = await _activityService.AddAsync(activity);

            return Ok(newActivity);
        }

        [HttpPut]
        public async Task<IActionResult> Alterar(Activity activity)
        {
            activity.UserId = userId;

            var updated = await _activityService.UpdateAsync(activity);

            return Ok(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar(Activity activity)
        {
            activity.UserId = userId;

            var deleted = await _activityService.RemoveAsync(activity);

            return Ok(deleted);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarById(Guid id)
        {
            
            var deleted = await _activityService.RemoveByIdAsync(id, userId);

            return Ok(deleted);
        }

    }
}