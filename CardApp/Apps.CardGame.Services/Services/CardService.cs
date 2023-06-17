using Apps.CardGame.Domain.Enums;
using Apps.CardGame.Domain.Models;
using Apps.CardGame.Services.Services.Interfaces;

namespace Apps.CardGame.Services.Services
{
    public class CardService : ICardService {
        public Card GetCard(string type, string suit) {
            CardType cardType;
            CardSuit cardSuit;

            Enum.TryParse<CardType>(type, out cardType);
            Enum.TryParse<CardSuit>(suit, out cardSuit);
            
            return new Card(cardType, cardSuit);
        }
    }
}