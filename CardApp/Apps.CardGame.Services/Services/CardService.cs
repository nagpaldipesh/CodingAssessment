using Apps.CardGame.Domain.Enums;
using Apps.CardGame.Domain.Models;
using Apps.CardGame.Services.Services.Interfaces;

namespace Apps.CardGame.Services.Services
{
    public class CardService : ICardService {
        public Card GetCard(CardType cardType, CardSuit cardSuit) {
            return new Card(cardType, cardSuit);
        }
    }
}