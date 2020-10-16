using Notificaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotificacionesWinF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                //NotificationWF.Instance.Title = "Notificacion tipo windows " + i.ToString();
                //NotificationWF.Instance.Text = "Esta es na notificacion tipo windows";
                //NotificationWF.Instance.BackColor = Color.Orange;
                //NotificationWF.Instance.TextColor = Color.Black;
                //NotificationWF.Instance.TitleColor = Color.Black;
                //NotificationWF.Instance.DivColor = Color.GreenYellow;
                NotificationWF.Instance.TimeToClose = 10;
                NotificationWF.Instance.ShowMessge();
            }
        }
    }
}
