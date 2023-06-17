
namespace Apps.CardGame.Services.Extensions {
    public static class DeckExtensions {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) {
            if (source == null) {
                throw new ArgumentNullException(nameof(source));
            }
            var random = new Random();
            var array = source.ToArray();
            var n = array.Length;
            for (var i = 0; i < n; i++) {
                // Exchange a[i] with random element in a[i..n-1]
                var r = i + random.Next(0, n - i);
                var temp = array[i];
                array[i] = array[r];
                array[r] = temp;
            }

            return array;
        }
    }
}
