using System;
using System.Windows.Forms;
namespace Cards
{
    internal class GameManager
    {
        private FormCreator _formCreator;
        private Deck _deck;
        private System.Drawing.Image _image;
        public PictureBox[] PictureBoxes { get; set; }
        public PictureBox[] Covers { get; set; }

        public GameManager( ImageList imageList, int size=10)
        {
            _formCreator = new FormCreator(size);
            _deck = new Deck(size, imageList);
            _image = imageList.Images[imageList.Images.Count - 1];
            Start();
        }

        private void Start()
        {
            PictureBoxes = _formCreator.CreatePictureBox();
            Covers = _formCreator.CreatePictureBox();
            for (int i = 0; i < PictureBoxes.Length; i++)
            {
                PictureBoxes[i].Image = _deck.Cards[i].Cover;
                Covers[i].Image = _image;
                Covers[i].Tag = i;
            }
        }

        public void Visible(int index)
        {
            Covers[index].Visible = !Covers[index].Visible;
        }

        public bool CheckCard(int left, int right)
        {
            if (_deck.Cards[left] == _deck.Cards[right])
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void Reset()
        {
            _deck.Shuffle();
            foreach (var item in Covers)
            {
                item.Visible = true;
            }
            for (int i = 0; i < PictureBoxes.Length; i++)
            {
                PictureBoxes[i].Image = _deck.Cards[i].Cover;
                Covers[i].Image = _image;
                Covers[i].Tag = i;
            }
        }
    }
}
