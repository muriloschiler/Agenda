using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain.Core;

namespace Agenda.Domain.Domain.Enumerations
{
    public class InteractionType: Enumeration
    {
        public static InteractionType CreateContact = new InteractionType(1, "Criar Contato");
        public static InteractionType UpdateContact = new InteractionType(2, "Atualizar Contato");
        public static InteractionType RemoveContact = new InteractionType(3, "Remover Contato");
        public static InteractionType GetContact = new InteractionType(4, "Visualizar Contato");
        public static InteractionType GetPhones = new InteractionType(5, "Visualizar Telefones");
        
        private InteractionType(){}
        public InteractionType(int id, string name) : base(id, name){ }
    }
}