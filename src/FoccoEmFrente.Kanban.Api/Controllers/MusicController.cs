using FoccoEmFrente.Kanban.Api.Controllers.Attributes;
using FoccoEmFrente.Kanban.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> Listar(Guid userId)
        {
            var musics = await _musicService.GetAllAsync(userId);

            if (musics == null)
                throw new Exception("Música não encontrada");

            return Ok(musics);
        }


        /*
        
        //Listar musica especifica 
        [HttpGet("{id}")]
        public Selecionar(Guid id)
        {
           
        }

        //Adicionar uma musica
        [HttpPost]
        public Inserir(Activity activity)
        {

        }

        //Atualizar uma musica ou estilo ou humores
        [HttpPut]
        public Atualizar(Activity activity)
        {
         
        }
        
        //deletar uma musica        
        [HttpDelete("{id}")]
        public DeletarById(Guid id)
        {
            
        }
        */

    }
}