using Apps.CardGame.Domain.Models;

namespace Apps.CardGame.Services.Services.Interfaces {
    public interface IDeckService {
        ICollection<Card> GetCards();
        ICollection<Card> ShuffleCards();
    }
}
