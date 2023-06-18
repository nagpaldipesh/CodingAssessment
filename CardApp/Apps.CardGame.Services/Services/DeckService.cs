using Apps.CardGame.Domain.Enums;
using Apps.CardGame.Domain.Models;
using Apps.CardGame.Services.Extensions;
using Apps.CardGame.Services.Services.Interfaces;

namespace Apps.CardGame.Services.Services {
    public class DeckService : IDeckService {
        private readonly ICardService _cardService;
        private readonly IList<Card> allCards;

        public DeckService(ICardService cardService) {
            _cardService = cardService;
            allCards = new List<Card>();
            SetupDeck();
        }

        public ICollection<Card> GetCards() {
            return allCards;
        }

        public ICollection<Card> ShuffleCards() {
            return allCards.Shuffle().ToList();
        }

        private void SetupDeck() {
            var cardSuits = Enum.GetNames<CardSuit>();
            if (cardSuits == null)
                throw new NullReferenceException(nameof(CardSuit));

            foreach (var cardSuit in cardSuits) {
                Enum.TryParse<CardSuit>(cardSuit, out var suit);
                AddCard(suit);
            }
        }

        private void AddCard(CardSuit suit) {
            var cardTypes = Enum.GetNames<CardType>();
            if (cardTypes == null)
                throw new NullReferenceException(nameof(CardType));

            foreach (var cardType in cardTypes) {
                Enum.TryParse<CardType>(cardType, out var type);
                allCards.Add(_cardService.GetCard(type, suit));
            }
        }

    }
}
