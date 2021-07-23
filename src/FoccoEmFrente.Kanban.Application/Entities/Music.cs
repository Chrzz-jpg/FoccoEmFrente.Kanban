using FoccoEmFrente.Kanban.Application.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace FoccoEmFrente.Kanban.Application.Entities
{
    public class Music : Entity, IAggregateRoot
    {
        public string Tittle { get; set; }
        
        public string Author { get; set; }

        public string Style  { get; set; }

        public string HumorPrincipal { get; set; }

        public string HumorSecundary { get; set; }

        public Guid UserId { get; set; }
    }
}
