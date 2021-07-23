using FoccoEmFrente.Kanban.Api.Controllers.Attributes;
using FoccoEmFrente.Kanban.Application.Entities;
using FoccoEmFrente.Kanban.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Api.Controllers
{
    [Route("api/[controller]")] //pega o nome prefixo do controller e define como rota
    [ApiController]
    [ValidateModelState]
    [Authorize]
    public class MusicController : ControllerBase
    {
        /** 
         Criar um objeto musica com:
                NOME ESTILO HUMOR1 HUMOR2
        Preciso criar metodos de:
                INSERÇÃO BUSCA E DELETAR
        Estas musicas são buscadas por chamada de navegador onde voce poem seu humor
        e o programa te cita musicas deste humor
                talvez playlist
                talvez searchs com youtube
         */
        /// preciso criar Controller -> Entidade ->
        /// 
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMusicService _musicService;
        public MusicController(IMusicService musicService, UserManager<IdentityUser> userManager)
        {
            _musicService = musicService;
            _userManager = userManager;
        }
        protected Guid userId => Guid.Parse(_userManager.GetUserId(User));


        //Listar todas as musicas

        [HttpGet]
        public async Task<IActionResult> Listar(string humor, string nome, string author, string style)
        {

            var musics = await _musicService.GetAllAsync(userId);

                //Filtragem de keys por API
                if (!string.IsNullOrEmpty(humor))
                    musics = musics
                        .Where(music => music.HumorPrincipal.ToLower() == humor.ToLower() || music.HumorSecundary.ToLower() == humor.ToLower());

                if (!string.IsNullOrEmpty(nome))
                    musics = musics
                        .Where(music => music.Tittle.ToLower() == nome.ToLower());

                if (!string.IsNullOrEmpty(author))
                    musics = musics
                        .Where(music => music.Author.ToLower() == author.ToLower());

                if (!string.IsNullOrEmpty(style))
                    musics = musics
                        .Where(music => music.Style.ToLower() == style.ToLower());

            return Ok(musics);
        }
        

        //Listar musica especifica 
        [HttpGet("{id}")]
        public async Task<IActionResult> Selecionar(Guid id)
        {
            var musics = await _musicService.GetByIdAsync(id, userId);

            //Caso a pesquisa não encontre o item
            //o retorno será um 404-NotFound sem mais info's
            if (musics == null)
                return NotFound();

            return Ok(musics);
        }
      

        //Adicionar uma musica
        [HttpPost]
        public async Task<IActionResult> Inserir(Music music)
        {
            music.UserId = userId;

            var newMusic = await _musicService.AddAsync(music);

            return Ok(newMusic);
        }
  
        [HttpPut]
        public async Task<IActionResult> Alterar(Music music)
        {
            music.UserId = userId;

            var updated = await _musicService.UpdateAsync(music);

            return Ok(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar(Music music)
        {
            music.UserId = userId;

            var deleted = await _musicService.RemoveAsync(music);

            return Ok(deleted);
        }

    }
}