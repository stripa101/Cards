using System;
using System.Windows.Forms;
namespace Cards
{
    internal class FormCreator
    {
        private int _size;
        private const int _width = 105;
        private const int _height = 105;
        private const int _lineBreak = 4;
        public FormCreator(int size=10)
        {
            this._size = size;
        }

        public PictureBox[] CreatePictureBox()
        {
            PictureBox[] pictureBoxes = new PictureBox[_size];
            int index = 0;
            int heightRow = 0;
            int widthRow = 0;
            for (int i = 0; i < pictureBoxes.Length; i++, index++)
            {
                pictureBoxes[i] = new PictureBox();
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxes[i].Size = new System.Drawing.Size(_width-5, _height-5);
                if (index == _lineBreak)
                {
                    index = 0;
                    widthRow = 0;
                    heightRow += _height;
                }
                pictureBoxes[i].Location = new System.Drawing.Point(widthRow, heightRow);
                widthRow += _width;
            }
            return pictureBoxes;
        }

    }
}
