using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain.Domain;
using Agenda.Domain.Domain.Enumerations;

namespace Agenda.Domain
{
    public class Interaction
    {
        public string Message { get; set; }
        public int InteractionTypeId { get; set; }
        public InteractionType InteractionType { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public Interaction(){}

        public Interaction(int userId, int interactionTypeId,string message)
        {
            UserId = userId;
            InteractionTypeId = interactionTypeId;
            Message = message;
        }
    }
}