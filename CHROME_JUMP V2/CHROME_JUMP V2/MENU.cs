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

namespace CHROME_JUMP_V2
{
    public partial class MENU : Form
    {
        bool on = true;
        bool Togglelight = true;
        Timer t = new Timer();

        private SoundPlayer Song;
        InGameScreen GameScreen = new InGameScreen();
        
        public MENU()
        {
            InitializeComponent();
            Song = new SoundPlayer("Menusong.wav");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrSong.Enabled = false;
            this.Hide();
            InGameScreen sistema = new InGameScreen();
            sistema.ShowDialog();
            this.Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void tmrSong_Tick(object sender, EventArgs e)
        {
            tmrSong.Interval = 11010;
            Song.Play();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (on)
            {
                btnStartStop.Text = ">";
                Song.Stop();
                t.Start();
                on = false;
            }
            else
            {
                btnStartStop.Text = "||";
                Song.Play();
                
                t.Stop();
                on = true;
            }
        }

        private void MENU_Load(object sender, EventArgs e)
        {
            btnStartStop.Text = "||";
            t.Interval = 100;
            t.Tick += new EventHandler(t_Tick);
        }

        private void t_Tick(object sender, EventArgs e)
        {
            if (Togglelight)
            {
                Togglelight = false;
            }
            else
            {
                Togglelight = true;
            }
        }
    }

    
}
