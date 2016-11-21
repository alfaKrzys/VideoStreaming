using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MSR.LST.Net.Rtp;
using MSR.LST;
using System.Collections;

namespace Odbiornik
{
    struct formy
    {
        public ArrayList naglowki;
        public ArrayList pola;
        public PictureBox obrazy;
    }
    public partial class Form1 : Form
    {
        Hashtable polaczenia = new Hashtable();
        formy FORMY = new formy();
        private RtpSession rtpSession;
        private bool firststream = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void d_b_strumieniuj_Click(object sender, EventArgs e)
        {
            IPEndPoint ep;
            try
            {
                ep = new IPEndPoint(IPAddress.Parse(d_tb_multicastIP.Text), 3000);
            }
            catch
            {
                MessageBox.Show("Błędny adres grupy multicastowej");
                return;
            }
            RtpEvents.RtpStreamAdded += new RtpEvents.RtpStreamAddedEventHandler(RtpStreamAdded);
            RtpEvents.RtpStreamRemoved += new RtpEvents.RtpStreamRemovedEventHandler(RtpStreamRemoved);
            rtpSession = new RtpSession(ep, new RtpParticipant(Dns.GetHostName(), Dns.GetHostName()), true, true);
            RtpSender rtpSender = rtpSession.CreateRtpSenderFec(Dns.GetHostName(), PayloadType.Chat, null, 0, 200);
        }
        private void RtpStreamAdded(object sender, RtpEvents.RtpStreamEventArgs ea)
        {
            if (firststream)
            {
                FORMY.naglowki = new ArrayList();
                FORMY.pola = new ArrayList();

                Label label = new Label();
                label.Text = "Kamera " + (polaczenia.Count + 1).ToString() + ". Położenie strefy:";
                label.AutoSize = true;
                this.Invoke((MethodInvoker)delegate() { d_flp_strefy.Controls.Add(label); });
                this.Invoke((MethodInvoker)delegate() { d_flp_strefy.SetFlowBreak(label,true); });
                FORMY.naglowki.Add(label);

                Label X = new Label();
                X.Text = "X:";
                X.AutoSize = true;
                this.Invoke((MethodInvoker)delegate() { d_flp_strefy.Controls.Add(X); });
                FORMY.naglowki.Add(X);

                NumericUpDown textX = new NumericUpDown();
                this.Invoke((MethodInvoker)delegate() { d_flp_strefy.Controls.Add(textX); });
                this.Invoke((MethodInvoker)delegate() { d_flp_strefy.SetFlowBreak(textX, true); });
                FORMY.pola.Add(textX);

                Label Y = new Label();
                Y.Text = "Y:";
                Y.AutoSize = true;
                this.Invoke((MethodInvoker)delegate() { d_flp_strefy.Controls.Add(Y); });
                FORMY.naglowki.Add(Y);

                NumericUpDown textY = new NumericUpDown();
                this.Invoke((MethodInvoker)delegate() { d_flp_strefy.Controls.Add(textY); });
                this.Invoke((MethodInvoker)delegate() { d_flp_strefy.SetFlowBreak(textY, true); });
                FORMY.pola.Add(textY);


                Label wysokosc = new Label();
                wysokosc.Text = "Wysokość strefy w pikselach";
                wysokosc.AutoSize = true;
                this.Invoke((MethodInvoker)delegate() { d_flp_strefy.Controls.Add(wysokosc); });
                FORMY.naglowki.Add(wysokosc);


                NumericUpDown textH = new NumericUpDown();
                this.Invoke((MethodInvoker)delegate() { d_flp_strefy.Controls.Add(textH); });
                this.Invoke((MethodInvoker)delegate() { d_flp_strefy.SetFlowBreak(textH, true); });
                FORMY.pola.Add(textH);

                Label szerokosc = new Label();
                szerokosc.Text = "Szerokość strefy w pikselach";
                szerokosc.AutoSize = true;
                this.Invoke((MethodInvoker)delegate() { d_flp_strefy.Controls.Add(szerokosc); });
                FORMY.naglowki.Add(szerokosc);

                NumericUpDown textW = new NumericUpDown();
                this.Invoke((MethodInvoker)delegate() { d_flp_strefy.Controls.Add(textW); });
                FORMY.pola.Add(textW);

                PictureBox ol = new PictureBox();
                ol.Dock = DockStyle.Fill;
                this.Invoke((MethodInvoker)delegate() { d_tlp_kamery.Controls.Add(ol); });
                FORMY.obrazy = ol;
                ea.RtpStream.FrameReceived += new RtpStream.FrameReceivedEventHandler(Odbior);
                polaczenia.Add(ea.RtpStream, FORMY);
            }
            else
                firststream = true;
        }

        private void RtpStreamRemoved(object sender, RtpEvents.RtpStreamEventArgs ea)
        {
            ea.RtpStream.FrameReceived -= new RtpStream.FrameReceivedEventHandler(Odbior);
            this.Invoke((MethodInvoker)delegate() {
                d_tlp_kamery.Controls.Remove(((PictureBox)(((formy)(polaczenia[ea.RtpStream])).obrazy)));
                foreach (Label l in ((formy)(polaczenia[ea.RtpStream])).naglowki)
                {
                    d_flp_strefy.Controls.Remove(l);
                }
                foreach (NumericUpDown N in ((formy)(polaczenia[ea.RtpStream])).pola)
                {
                    d_flp_strefy.Controls.Remove(N);
                }

            });
        }

        private void Odbior(object sender, RtpStream.FrameReceivedEventArgs ea)
        {
            NumericUpDown X = (NumericUpDown)(((formy)(polaczenia[ea.RtpStream])).pola[0]);
            NumericUpDown Y = (NumericUpDown)(((formy)(polaczenia[ea.RtpStream])).pola[1]);
            NumericUpDown height = (NumericUpDown)(((formy)(polaczenia[ea.RtpStream])).pola[2]);
            NumericUpDown width = (NumericUpDown)(((formy)(polaczenia[ea.RtpStream])).pola[3]);
            MemoryStream ms = new MemoryStream(ea.Frame.Buffer);
            double d = difference(((PictureBox)(((formy)(polaczenia[ea.RtpStream])).obrazy)).Image, Image.FromStream(ms), ea);
            if (d > 10)
                this.Invoke((MethodInvoker)delegate() { d_komunikat.Text = "Wykryto ruch kamera: " + (1 + d_tlp_kamery.Controls.IndexOf(((PictureBox)(((formy)(polaczenia[ea.RtpStream])).obrazy)))).ToString(); });
            else
                this.Invoke((MethodInvoker)delegate() { d_komunikat.Text = ""; });
            ((PictureBox)(((formy)(polaczenia[ea.RtpStream])).obrazy)).Image = Image.FromStream(ms);
            this.Invoke((MethodInvoker)delegate()
            {
                d_tlp_kamery.Controls[d_tlp_kamery.Controls.IndexOf(((PictureBox)(((formy)(polaczenia[ea.RtpStream])).obrazy)))].Width = Image.FromStream(ms).Width;
                d_tlp_kamery.Controls[d_tlp_kamery.Controls.IndexOf(((PictureBox)(((formy)(polaczenia[ea.RtpStream])).obrazy)))].Height = Image.FromStream(ms).Height;
                X.Maximum = Image.FromStream(ms).Width;
                Y.Maximum = Image.FromStream(ms).Height;
                height.Maximum = Image.FromStream(ms).Height - Y.Value;
                width.Maximum = Image.FromStream(ms).Width - X.Value;
                Graphics g = Graphics.FromImage(((PictureBox)(((formy)(polaczenia[ea.RtpStream])).obrazy)).Image);
                g.DrawRectangle(new Pen(Color.Red), (int)X.Value, (int)Y.Value, (int)width.Value, (int)height.Value);
                ((PictureBox)(((formy)(polaczenia[ea.RtpStream])).obrazy)).Refresh();
            });
        }

        private double difference(Image OrginalImage, Image SecoundImage,RtpStream.FrameReceivedEventArgs ea)
        {
            double percent = 0;
            int X = ((int)((NumericUpDown)(((formy)(polaczenia[ea.RtpStream])).pola[0])).Value);
            int Y = ((int)((NumericUpDown)(((formy)(polaczenia[ea.RtpStream])).pola[1])).Value);
            int height = ((int)((NumericUpDown)(((formy)(polaczenia[ea.RtpStream])).pola[2])).Value);
            int width = ((int)((NumericUpDown)(((formy)(polaczenia[ea.RtpStream])).pola[3])).Value);
            try
            {
                float counter = 0;

                Random rand = new Random();

                Bitmap bt1 = new Bitmap(OrginalImage);
                Bitmap bt2 = new Bitmap(SecoundImage);
                if (((NumericUpDown)(((formy)(polaczenia[ea.RtpStream])).pola[2])).Value != 0 && ((NumericUpDown)(((formy)(polaczenia[ea.RtpStream])).pola[3])).Value != 0)
                {

                    float total = height * width;

                    Color pixel_image1;
                    Color pixel_image2;


                    for (int i = 0; i < Math.Round(total * 0.1); i++)
                    {
                        int x = rand.Next(X, X + width);
                        int y = rand.Next(Y, Y + height);

                        byte srednia1 = (byte)((bt1.GetPixel(x, y).R + bt1.GetPixel(x, y).G + bt1.GetPixel(x, y).B) / 3);
                        pixel_image1 = Color.FromArgb(srednia1, srednia1, srednia1);
                        byte srednia2 = (byte)((bt2.GetPixel(x, y).R + bt2.GetPixel(x, y).G + bt2.GetPixel(x, y).B) / 3);
                        pixel_image2 = Color.FromArgb(srednia2, srednia2, srednia2);

                        if (Math.Abs(pixel_image1.R - pixel_image2.R) > 10)
                        {
                            counter++;
                        }

                    }
                    percent = (counter / Math.Round(total * 0.1)) * 100;
                }
                else
                {
                    int size_H = bt1.Size.Height;
                    int size_W = bt1.Size.Width;

                    float total = size_H * size_W;

                    Color pixel_image1;
                    Color pixel_image2;


                    for (int i = 0; i < Math.Round(total * 0.1); i++)
                    {
                        int x = rand.Next(bt1.Size.Width);
                        int y = rand.Next(bt1.Size.Height);

                        byte srednia1 = (byte)((bt1.GetPixel(x, y).R + bt1.GetPixel(x, y).G + bt1.GetPixel(x, y).B) / 3);
                        pixel_image1 = Color.FromArgb(srednia1, srednia1, srednia1);
                        byte srednia2 = (byte)((bt2.GetPixel(x, y).R + bt2.GetPixel(x, y).G + bt2.GetPixel(x, y).B) / 3);
                        pixel_image2 = Color.FromArgb(srednia2, srednia2, srednia2);

                        if (Math.Abs(pixel_image1.R - pixel_image2.R) > 10)
                        {
                            counter++;
                        }

                    }
                    percent = (counter / Math.Round(total * 0.1)) * 100;

                }
            }
            catch (Exception) { percent = 0; }
            return percent;
        }

    }
}

