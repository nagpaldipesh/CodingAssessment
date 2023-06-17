using Apps.CardGame.Domain.Enums;

namespace Apps.CardGame.Domain.Models {
    public class Card {
        private CardType _type;
        private CardSuit _suit;

        public CardSuit CardSuit {
            get {
                return _suit;
            }
        }
        public CardType CardType {
            get {
                return _type;
            }
        }

        public Card(CardType cardType, CardSuit cardSuit) 
        {
            _suit = cardSuit;
            _type = cardType;
        }
    }
}
