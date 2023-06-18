using Apps.CardGame.Domain.Enums;
using Apps.CardGame.Domain.Models;

namespace Apps.CardGame.Services.Services.Interfaces
{
    public interface ICardService
    {
        Card GetCard(CardType cardType, CardSuit cardSuit);
    }
}
