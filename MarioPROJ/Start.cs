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
    public partial class Start : Form
    {
        private SoundPlayer _soundPlayer;
        public Start()
        {
            InitializeComponent();
           // _soundPlayer = new SoundPlayer(@"C:\Users\anant\Desktop\.NET\MarioPROJ\MarioPROJ\Resources\Audio_Start.wav");
            //_soundPlayer.Play();
            
        }
        
        private void Start_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newWindow = new Form1();
            this.Hide();
            newWindow.Show();
        }

        private void txtHighScore_Click(object sender, EventArgs e)
        {

        }

        private void CloseGame(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
