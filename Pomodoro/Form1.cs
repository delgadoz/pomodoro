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

namespace Pomodoro
{
    public partial class Form1 : Form
    {

        public int segundos = 00;
        public int minutos = 00;
        public string segundos2 = "";
        public string minutos2 = "";
        public bool estudando = false;
        public int ciclos = 0;
        public int tempoDeDescanso = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos++;
            if (segundos == 60)
            {
                minutos++;
                segundos = 0;
            }
            if (segundos <= 9)
            {
                segundos2 = "0" + Convert.ToString(segundos);
            }
            else
            {
                segundos2 = segundos.ToString();
            }
            if(minutos <= 9)
            {
                minutos2 = "0" + minutos.ToString();
            }
            else
            {
                minutos2 = minutos.ToString();
            }
            labelTempo.Text = string.Format("{0}:{1}", minutos2, segundos2);

            if(minutos == 25)
            {
                labelTempo.Text = "00:00";
                minutos = 0;
                segundos = 0;
                timerDescanso.Enabled = true;
                timerEstudo.Enabled = false;               
                labelStatus.Text = "Descansando";
                ciclos++;
                labelCiclos.Text = String.Format("{0}/4", ciclos);
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\Delgado\source\repos\Pomodoro\Pomodoro\bin\Debug\pausaPapiro.wav");
                simpleSound.Play();
            }

            if (ciclos < 4)
            {
                tempoDeDescanso = 5;        
            }

            if (ciclos == 4)
            {
                tempoDeDescanso = 25;
                ciclos = 0;
            }
            if(ciclos == 3)
            {
                labelProxDescanso.Text = "25 minutos";
            }
            else
            {
                labelProxDescanso.Text = "5 minutos";
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(estudando == false)
            {
                labelStatus.Text = "Estudando";
                estudando = true;
                timerEstudo.Enabled = true;
                button1.Text = "Recomeçar";
            }
            else
            {
                button1.Text = "Iniciar";
                estudando = false;
                timerEstudo.Enabled = false;
                timerDescanso.Enabled = false;
                labelStatus.Text = "Descansando";
                labelCiclos.Text = "0/4";
                labelProxDescanso.Text = "5 minutos";
                segundos = 0;
                minutos = 0;
                segundos2 = "";
                minutos2 = "";
                ciclos = 0;
                tempoDeDescanso = 5;
                labelTempo.Text = "00:00";

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                base.TopMost = true;
            }
            else
            {
                base.TopMost = false;
            }
        }

        private void timerDescanso_Tick(object sender, EventArgs e)
        {
            segundos++;
            if (segundos == 60)
            {
                minutos++;
                segundos = 0;
            }
            if (segundos <= 9)
            {
                segundos2 = "0" + Convert.ToString(segundos);
            }
            else
            {
                segundos2 = segundos.ToString();
            }
            if (minutos <= 9)
            {
                minutos2 = "0" + minutos.ToString();
            }
            else
            {
                minutos2 = minutos.ToString();
            }
            labelTempo.Text = string.Format("{0}:{1}", minutos2, segundos2);

            if (minutos == tempoDeDescanso)
            {
                labelTempo.Text = "00:00";
                minutos = 0;
                segundos = 0;
                timerDescanso.Enabled = false;
                timerEstudo.Enabled = true;
                labelStatus.Text = "Estudando";
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\Delgado\source\repos\Pomodoro\Pomodoro\bin\Debug\voltaPapiro.wav");
                simpleSound.Play();
            }
            if(ciclos == 0)
            {
                labelCiclos.Text = "0/4";
            }
        }
    }
}
