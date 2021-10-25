using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notificaciones
{

    public class NotificationWF
    {

        //comentario
        public static NotificationWF instance = null;
        private const int wdt = 332;
        private const int hgt = 86;
        private int screenH = 0;
        private int screenW = 0;
        private string Defaultstr = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        private Form notiform { get; set; }
        private Timer tmnf { get; set; }
        public NotificationWF() { }
        public string Title { internal get; set; } = "Titulo del mensaje";
        public string Text { internal get; set; } = "texto del mensaje";
        public Color BackColor { internal get; set; } = Color.FromArgb(24, 24, 24); // color de fondo del formulario de notificacion 
        public Color DivColor { internal get; set; } = Color.FromArgb(182, 7, 82);// Color de fondo del panel que fivide el titulo del texto del cuerpo del mensaje
        public Color TextColor { internal get; set; } = Color.White; //Color del texto del cuerpo del mensaje
        public Color TitleColor { internal get; set; } = Color.White; //Color del texto del titulo del mensaje       
        public int TimeToClose { internal get; set; } = 5; // tiempo que le tomara al mensaje en cerrarse (Sec)

        //Instancia de la clase
        public static NotificationWF Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NotificationWF();
                }
                return instance;
            }
        }
        /// <summary>
        /// mostrar mensaje 
        /// </summary>
        public void ShowMessge()
        {
            List<Form> frms = Application.OpenForms.OfType<Form>().Where(x => x.Name.Contains("ntfyFrm")).ToList();
            if (frms != null)
            {
                // en caso de que haya mas de un formulario que estos vayan haci la parte de ariba
                //y el nuevo mensaje se mantenga siempre abajo
                if (frms.Count > 0)
                {
                    foreach (Form f in frms)
                    {
                        int n = Convert.ToInt32(f.Name.Replace("ntfyFrm", ""));
                        f.Location = new Point(f.Location.X, f.Location.Y - (hgt + 1));
                    }
                }
            }

            screenH = Screen.PrimaryScreen.Bounds.Height;
            screenW = Screen.PrimaryScreen.Bounds.Width;
            Form frm = InitFmr();
            frm.Location = new Point(screenW, screenH - (hgt + 41));
            frm.Show();
            frm.BringToFront();
            int lx = screenW - (wdt + 1);
            int LY = screenH - (hgt + 41);
            // para cambiar la velocidad en que se despliegan los mensajes se debe cambiar el numero 10 de este for
            for (int x = screenW; x > lx; x -= 13)
            {
                frm.Location = new Point(x, LY);
                //Application.DoEvents();
                frm.Refresh();
                System.Threading.Thread.Sleep(5);
            }
        }
        /// <summary>
        /// Inicializar formulario
        /// </summary>
        /// <returns>formulario de notificacion</returns>
        private Form InitFmr()
        {
            var randomNumber = new Random().Next(0, 10000);
            //-----------------------------------
            // title label
            //-----------------------------------
            Label lbl = new Label();
            lbl.ForeColor = TitleColor;
            lbl.Dock = DockStyle.Top;
            lbl.AutoSize = false;
            lbl.Size = new Size(332, 23);
            lbl.Text = "    " + Title;// + " "+ randomNumber;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //-----------------------------------
            // Div Panel
            //-----------------------------------
            Panel Div = new Panel();
            Div.Size = new Size(332, 3);
            Div.BackColor = DivColor;
            Div.Dock = DockStyle.Top;
            //-----------------------------------
            // Close Button
            //-----------------------------------
            Button CBtn = new Button();
            CBtn.Text = "X";
            CBtn.Name = randomNumber.ToString();
            CBtn.Size = new Size(27, 23);
            CBtn.Location = new Point(305, 0);
            CBtn.FlatStyle = FlatStyle.Flat;
            CBtn.FlatAppearance.BorderSize = 0;
            CBtn.FlatAppearance.MouseOverBackColor = Color.Red;
            CBtn.ForeColor = Color.White;
            CBtn.BringToFront();
            CBtn.Click += new System.EventHandler(CloseBtn_Click);
            //-----------------------------------
            // Text label
            //-----------------------------------
            Label lblT = new Label();
            lblT.AutoSize = false;
            lblT.ForeColor = TextColor;
            lblT.Size = new Size(316, 48);
            lblT.Location = new Point(8, 31);
            if (Text != "texto del mensaje") { lblT.Text = Text; }
            else { lblT.Text =  Defaultstr; }
            lblT.Click += new System.EventHandler(lbltext_Click);
            //-----------------------------------
            // Closefrm Timer
            //-----------------------------------
            Timer Tm = new Timer();
            Tm.Interval = 1000 * TimeToClose;
            Tm.Tag = randomNumber.ToString();
            Tm.Tick += CloseTimer_Tick;
            Tm.Start();
            //-----------------------------------
            // notify Form
            //-----------------------------------
            notiform = new Form();
            notiform.Name = "ntfyFrm" + randomNumber.ToString();
            notiform.Width = wdt;
            notiform.Height = hgt;
            notiform.FormBorderStyle = FormBorderStyle.None;
            notiform.BackColor = BackColor;
            notiform.Opacity = .90;
            //------------------------------------
            // Agregar controles a formulario
            //------------------------------------
            notiform.Controls.Add(Div);
            notiform.Controls.Add(CBtn);
            notiform.Controls.Add(lbl);
            notiform.Controls.Add(lblT);
            //------------------------------------
            notiform.ShowInTaskbar = false;
            notiform.StartPosition = FormStartPosition.Manual;
            return notiform;
        }
        /// <summary>
        /// Evento click del boton Cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Button cbtn = (Button)sender;
            Form frm = Application.OpenForms.OfType<Form>().Where(x => x.Name == "ntfyFrm" + cbtn.Name).SingleOrDefault();
            if (frm != null) { frm.Close(); }
        }
        /// <summary>
        /// Evento Tick del timer CloseTimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            Timer tm = (Timer)sender;
            Form frm = Application.OpenForms.OfType<Form>().Where(x => x.Name == "ntfyFrm" + tm.Tag).SingleOrDefault();
            if (frm != null) { frm.Close(); }
            tm.Dispose();
        }
        /// <summary>
        /// Evento Cick del label lbltext
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbltext_Click(object sender, EventArgs e)
        {
            MessageBox.Show("mensaje de prueba");
        }
    }
}
