using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MarioPROJ
{
    public partial class End : Form
    {
        private SoundPlayer _gameplay;
        public End( string point1,string score1)
        {
            InitializeComponent();
            _gameplay = new SoundPlayer(@"C:\Users\anant\Desktop\.NET\MarioPROJ\MarioPROJ\Resources\Audio_WIN.wav");
            _gameplay.Play();
            txtPoints.Text = point1;
            txtScore.Text = score1;

        }

        private void txtPoints_Click(object sender, EventArgs e)
        {
                    
        }

        private void txtScore_Click(object sender, EventArgs e)
        {
            
        }

        private void GameClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
