using Apps.CardGame.Domain.Enums;
using Apps.CardGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.CardGame.Services.Services.Interfaces
{
    public interface ICardService
    {
        Card GetCard(string type, string suit);
    }
}
