using System;
namespace Cards
{
    internal class Deck
    {
        private Card[] _cards;
        private System.Windows.Forms.ImageList _imageList;

        public Card[] Cards { get => _cards; }
        public Deck(int size, System.Windows.Forms.ImageList listImage)
        {
            _cards = new Card[size];
            _imageList = listImage;
            CreateDeck();
        }

        private void CreateDeck()
        {
            int id = 0;
            for (int i = 0; i <_cards.Length; i+=2)
            {
                Card card = new Card();
                card.Cover= _imageList.Images[id];
                _cards[i] = card;
                _cards[i + 1] = card;
                id++;
            }
            Shuffle();
        }

        public void Shuffle()
        {
            Random random =new Random();
            for (int i = 0; i < _cards.Length; i++)
            {
                int index=random.Next(0,_cards.Length); 
                Card temp = _cards[i];
                _cards[i] = _cards[index];
                _cards[index] = temp;
            }
        }
    }
}
