using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cards
{
    public partial class Form1 : Form
    {
        GameManager _gameManager;
        Statistic _statistic;
        public Form1()
        {
            InitializeComponent();
            _statistic = new Statistic();
            _gameManager = new GameManager(imageList1,20);
            for (int i = 0; i < _gameManager.PictureBoxes.Length; i++)
            {
                Controls.Add(_gameManager.Covers[i]);
                Controls.Add(_gameManager.PictureBoxes[i]);
                _gameManager.Covers[i].Click += Form1_Click;
            }
            
        }

        int _indexLeft = -1;
        int _indexRight = -1;

        private void Form1_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pictureBox = sender as PictureBox;
                if (_indexLeft == -1)
                {
                    _indexLeft = (int)pictureBox.Tag;
                    _gameManager.Visible(_indexLeft);
                }
                else if (_indexRight == -1)
                {
                    _indexRight = (int)pictureBox.Tag;
                    _gameManager.Visible(_indexRight);
                    timer1.Interval = 1000;
                    timer1.Start();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = $"Result={_statistic.Counter}";
            if (!_gameManager.CheckCard(_indexLeft, _indexRight))
            {
                _gameManager.Visible(_indexLeft);
                _gameManager.Visible(_indexRight);
            }
            _indexLeft = -1;
            _indexRight = -1;
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _gameManager.Reset();
            _indexLeft = -1;
            _indexRight = -1;
        }
    }
}
