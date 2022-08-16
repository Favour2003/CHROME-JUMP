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
    public partial class InGameScreen : Form
    {
        private SoundPlayer jmp, Hundred, Song;
        private SoundPlayer Fail;
        int y = 0;
        bool jump = false;
        int g = 18, force = 0;
        string a;
        Random rndCacti = new Random();
        int num1, num2, Score, num = 6, value = 100;
        PictureBox[] Cloud = new PictureBox[3], Cacti = new PictureBox[6], Dino = new PictureBox[4], Screen = new PictureBox[8];
        

        public InGameScreen()
        {
            InitializeComponent();
            jmp = new SoundPlayer("jump.wav");
            Hundred = new SoundPlayer("100.wav");
            Fail = new SoundPlayer("Over.wav");
            Song = new SoundPlayer("Menusong.wav");

            Screen[0] = picboxDefault;
            Screen[1] = picboxNoir;
            Screen[2] = picboxAquaMarine;
            Screen[3] = picboxAqua;
            Screen[4] = picboxAzure;
            Screen[5] = picboxSapphire;
            Screen[6] = picboxTomato;
            Screen[7] = picboxVulcano;

            Dino[0] = picboxIdle1;
            Dino[1] = picboxDinoRun1;
            Dino[2] = picboxDinoRun2;
            Dino[3] = picboxDinoFail1;

            

            num1 = rndCacti.Next(0, 3);
            num2 = rndCacti.Next(3, 6);

            Cloud[0] = picboxCloud1;
            Cloud[1] = picboxCloud2;
            Cloud[2] = picboxCloud3;

            Cacti[0] = picboxCacti1a;
            Cacti[1] = picboxCacti2a;
            Cacti[2] = picboxCacti3a;
            Cacti[3] = picboxCacti2b;
            Cacti[4] = picboxCacti3b;
            Cacti[5] = picboxCacti2c;

            

        }

        private void tmrBG_Tick(object sender, EventArgs e)
        {
            PicboxBG_1.Left -= num;
            PicboxBG_2.Left -= num;
        }

        private void tmrBG_2_Tick(object sender, EventArgs e)
        {
            if (PicboxBG_1.Left <= -525)
            {
                PicboxBG_1.Left = 490;
            }
            else if (PicboxBG_2.Left <= -525)
            {
                PicboxBG_2.Left = 490;
            }
        }

        private void tmrDinoRun_1_Tick(object sender, EventArgs e)
        {
            

            if (Dino[1].Visible == true)
            {
                Dino[1].Visible = false;
                Dino[2].Visible = true;
            }
            else if (Dino[2].Visible == true)
            {
                Dino[2].Visible = false;
                Dino[1].Visible = true;
            }
        }

        private void tmrCacti1b_Tick(object sender, EventArgs e)
        {
            Cacti[num2].Visible = true;
            Cacti[num2].Left -= num;
            if (Cacti[num2].Left < -100)
            {
                Cacti[num2].Left = rndCacti.Next(Cacti[num1].Left + 350, Cacti[num1].Left + 351);
                Cacti[num2].Visible = false;
                num2 = rndCacti.Next(3, 6);
            }
        }
        private void tmrCacti_Tick(object sender, EventArgs e)
        {
            Cacti[num1].Visible = true;
            Cacti[num1].Left -= num;
            if (Cacti[num1].Left <= 400)
            {
                tmrCacti1b.Enabled = true;
            }
            if (Cacti[num1].Left < -100)
            {
                Cacti[num1].Left = 750;
                Cacti[num1].Visible = false;
                num1 = rndCacti.Next(0, 3);
            }

        }

        private void tmrJump1_Tick(object sender, EventArgs e)
        {
            if (jump == true)
            {
                Dino[1].Top -= force;
                Dino[2].Top -= force;
                Dino[3].Top -= force;
                force -= 2;
            }
            if (Dino[1].Top + Dino[1].Height >= 236)
            {
                Dino[1].Top = 236 - Dino[1].Height;
                Dino[2].Top = 236 - Dino[2].Height;
                Dino[3].Top = 236 - Dino[3].Height;
                jump = false;
            }
        }

        private void tmrCloud_Tick(object sender, EventArgs e)
        {
            Cloud[0].Left -= 1;
            Cloud[1].Left -= 1;
            Cloud[2].Left -= 1;
            if (Cloud[0].Left < -75)
            {
                Cloud[0].Left = 700;
            }
            else if (Cloud[1].Left < -75)
            {
                Cloud[1].Left = 700;
                Cloud[1].Visible = true;
            }
            else if (Cloud[2].Left < -75)
            {
                Cloud[2].Left = 700;
                Cloud[2].Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetCacti();
            ResetDino();
            lblGameOver.Visible = false ;
            btnRestart.Visible = false; btnRestart.Enabled = false;
            btnMenu.Visible = false; btnMenu.Enabled = false;
            if (Convert.ToInt32(lblHI.Text)  < Convert.ToInt32(lblScore1.Text))
            {
                lblHI.Text = lblScore1.Text;
            }
            lblScore1.Text = "0";
            Score = 0;
            jump = false;
            value = 100;
            g = 18;
            num = 5;
            tmrJump1.Interval = 35;
            force = 0;
        }

        private void tmrSpeed_Tick(object sender, EventArgs e)
        {
            //for (int i = 0; i <= 10; i++)
            //{
            //    num += 1;
            //    if (num == 6)
            //    {
            //        tmrJump1.Interval = 32;
            //    }
            //    else if (num == 7)
            //    {
            //        tmrJump1.Interval = 27;
            //    }
            //    else if (num == 8)
            //    {
            //        tmrJump1.Interval = 20;
            //    }
            //    else if (num == 9 || num == 10)
            //    {
            //        tmrJump1.Interval = 17;
            //    }
            //}
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            y++;
            if (y < 8)
            {
                if (y > 0)
                {
                    btnPrevious.Enabled = true;
                }
                Screen[y - 1].Visible = false;
                Screen[y].Visible = true;
            }
        }

        private void tmrScreenName_Tick(object sender, EventArgs e)
        {
            if (y == 0)
            {
                btnPrevious.Enabled = false;
            }
            else if (y == 7)
            {
                btnNext.Enabled = false;
            }

            if (Screen[0].Visible == true)
            {
                lblScreenName.Text = "Default";
            }
            else if (Screen[1].Visible == true)
            {
                lblScreenName.Text = "Noir";
            }
            else if (Screen[2].Visible == true)
            {
                lblScreenName.Text = "AquaMarine";
            }
            else if (Screen[3].Visible == true)
            {
                lblScreenName.Text = "Aqua";
            }
            else if (Screen[4].Visible == true)
            {
                lblScreenName.Text = "Azure";
            }
            else if (Screen[5].Visible == true)
            {
                lblScreenName.Text = "Sapphire";
            }
            else if (Screen[6].Visible == true)
            {
                lblScreenName.Text = "Tomato";
            }
            else if (Screen[7].Visible == true)
            {
                lblScreenName.Text = "Vulcano";
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            y--;
            if (y < 8)
            {
                if (y > 0)
                {
                    btnNext.Enabled = true;
                }
                Screen[y + 1].Visible = false;
                Screen[y].Visible = true;
            }
        }

        private void btnOkay1_Click(object sender, EventArgs e)
        {
            Song.Stop();
            tmrFailSound.Enabled = true;
            for (int y = 0; y < Screen.Length; y++)
            {
                if (Screen[y].Visible ==true)
                {
                    a = y.ToString();
                }
            }

            pnlShop.Visible = false; pnlShop.Enabled = false;

            if (a == "0")
            {
                this.BackColor = Color.WhiteSmoke;
            }
            else if (a == "1")
            {
                this.BackColor = Color.Black;
            }
            else if (a == "2")
            {
                this.BackColor = Color.Aquamarine;
            }
            else if (a == "3")
            {
                this.BackColor = Color.Aqua;
            }
            else if (a == "4")
            {
                this.BackColor = Color.CornflowerBlue;
            }
            else if (a == "5")
            {
                this.BackColor = Color.Blue;
            }
            else if (a == "6")
            {
                this.BackColor = Color.Tomato;
            }
            else if (a == "7")
            {
                this.BackColor = Color.Red;
            }
        }

        private void tmrFailSound_Tick(object sender, EventArgs e)
        {
            //Song.Stop();
        }

        private void tmrScore_Tick(object sender, EventArgs e)
        {
            lblScore1.Text = Convert.ToString(Score);
            Score += 1;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void InGameScreen_Load(object sender, EventArgs e)
        {
            if (pnlShop.Visible == false)
            {
                Song.Stop();
            }
        }

        private void tmrFail_Tick(object sender, EventArgs e)
        {
            if (Cacti[0].Bounds.IntersectsWith(Dino[1].Bounds) || Cacti[0].Bounds.IntersectsWith(Dino[2].Bounds) ||
                Cacti[1].Bounds.IntersectsWith(Dino[1].Bounds) || Cacti[1].Bounds.IntersectsWith(Dino[2].Bounds) ||
                Cacti[2].Bounds.IntersectsWith(Dino[1].Bounds) || Cacti[2].Bounds.IntersectsWith(Dino[2].Bounds) ||
                Cacti[3].Bounds.IntersectsWith(Dino[1].Bounds) || Cacti[3].Bounds.IntersectsWith(Dino[2].Bounds) ||
                Cacti[4].Bounds.IntersectsWith(Dino[1].Bounds) || Cacti[4].Bounds.IntersectsWith(Dino[2].Bounds) ||
                Cacti[5].Bounds.IntersectsWith(Dino[1].Bounds) || Cacti[5].Bounds.IntersectsWith(Dino[2].Bounds))
            {
                Fail.Play();
                tmrBG_1.Enabled = false;
                tmrBG_2.Enabled = false;
                tmrJump1.Enabled = false;
                tmrCloud1.Enabled = false;
                tmrStars.Enabled = false;
                tmrCacti1a.Enabled = false;
                tmrCacti1b.Enabled = false;
                tmrSpeed.Enabled = false;
                tmrScore.Enabled = false;
                //tmr100.Enabled = false;
                Dino[1].Visible = false;
                Dino[3].Visible = true;
                jump = true;
                lblGameOver.Visible = true;
                btnRestart.Visible = true; btnRestart.Enabled = true;
                btnMenu.Visible = true; btnMenu.Enabled = true;
            }
        }

        private void tmr100_Tick(object sender, EventArgs e)
        {
            if (Score == value)
            {
                Hundred.Play();
                value += 100;
            }
        }

        private void tmrStars_Tick(object sender, EventArgs e)
        {
            picboxStar1.Left -= 1;
            picboxStar2.Left -= 1;
            if (picboxStar1.Left < -5)
            {
                picboxStar1.Left = 600;
            }
            else if (picboxStar2.Left < -5)
            {
                picboxStar2.Left = 600;
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (jump != true)
            {
                if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Up)
                {
                    jmp.Play();
                    tmrBG_1.Enabled = true;
                    tmrBG_2.Enabled = true;
                    tmrDinoRun_1.Enabled = true;
                    tmrJump1.Enabled = true;
                    tmrCloud1.Enabled = true;
                    tmrStars.Enabled = true;
                    tmrCacti1a.Enabled = true;
                    tmrFail.Enabled = true;
                    tmrScore.Enabled = true;
                    tmrSpeed.Enabled = true;
                    Dino[0].Visible = false;
                    Dino[1].Visible = true;
                    force = g;
                    jump = true;
                }

            }
        }

        public void ResetCacti()
        {
            for (int i = 0; i < Cacti.Length; i++)
            {
                Cacti[i].Left = 700;
            }
        }

        public void ResetDino()
        {
            for (int i = 0; i < Dino.Length; i++)
            {
                Dino[i].Top = 188;
                if (i != 0)
                {
                    Dino[i].Visible = false;
                }
                Dino[0].Visible = true;
            }
        }


       

    }
}
