using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Windows.Forms;
using AviFile;
using DirectX.Capture;
using DShowNET;
using MSR.LST.Net.Rtp;
namespace AudioVideoStreaming
{
    public partial class Form1 : Form
    {
        private Filters filters = new Filters();
        private Capture capture;
        private RtpSender rtpSender;
        private AviPlayer player;
        private EditableVideoStream editableStream;
        private byte[] savedArray;
        DShowNET.VideoInfoHeader videoInfoHeader;
        private DShowNET.ISampleGrabber sampGrabber;
        private IVideoWindow videoWindow;
        private const int WS_CHILD = 0x40000000;	// attributes for video window
        private const int WS_CLIPCHILDREN = 0x02000000;
        private const int WM_GRAPHNOTIFY = 0x00008001;
        private const int WS_CLIPSIBLINGS = 0x04000000;
        private IMediaEventEx mediaEvt;
        private Type comType;
        private object comObj;
        private bool captured=true;
        private int bufferedSize;
        private AMMediaType media;
        private int hr;
        private IBaseFilter baseGrabFlt;
        private RtpSession rtpSession;
        private delegate void CaptureDone();



        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < filters.VideoInputDevices.Count; i++)
            {
                d_cb_video.Items.Add(filters.VideoInputDevices[i].Name);
                d_cb_video.SelectedIndex = i;
            }
            for (int i = 0; i < filters.AudioInputDevices.Count; i++)
            {
                d_cb_audio.Items.Add(filters.AudioInputDevices[i].Name);
                d_cb_audio.SelectedIndex = i;
            }
        }

        private void d_b_strumieniuj_Click(object sender, EventArgs e)
        {
            if (d_cb_video.Items.Count != 0 || d_cb_audio.Items.Count != 0 || !string.IsNullOrEmpty(d_tb_sciezka.Text))
            {
                SetRTPSession();
                if (string.IsNullOrEmpty(d_tb_sciezka.Text))
                {
                    //VideoGrabber videograbber = new VideoGrabber();
                    //videograbber.VideoSource = TVideoSource.vs_VideoCaptureDevice;
                    //videograbber.NetworkStreaming = TNetworkStreaming.ns_ASFDirectNetworkStreaming;
                    //videograbber.NetworkStreamingType = TNetworkStreamingType.nst_AudioVideoStreaming;
                    //videograbber.ASFNetworkPort = 3000;
                    //videograbber.AudioDeviceRendering = true;
                    //videograbber.Size = d_pb_podglad.Size;
                    //videograbber.Parent = this.d_pb_podglad;
                    //videograbber.StartPreview();

                    capture = new Capture(filters.VideoInputDevices[d_cb_video.SelectedIndex], filters.AudioInputDevices[d_cb_audio.SelectedIndex]);
                    capture.PreviewWindow = picPreview;

                    capture.FrameEvent2 += new Capture.HeFrame(CaptureOK);
                    capture.GrapImg();
                    timer1.Enabled = true;
                    
                }
                else
                {






                    //AviManager aviManager = new AviManager(d_tb_sciezka.Text, true);
                    //VideoStream stream = aviManager.GetVideoStream();
                    //editableStream = new EditableVideoStream(stream);
                    //aviManager.Close();
                    //player = new AviPlayer(editableStream, picPreview, lblFrameIndex);
                    //player.Stopped += new System.EventHandler(player_Stopped);
                    //player.Start();




                    //VideoGrabber videograbber = new VideoGrabber();
                    //videograbber.VideoSource= TVideoSource.vs_VideoFileOrURL;
                    //videograbber.VideoSource_FileOrURL = d_tb_sciezka.Text;
                    //videograbber.AudioDeviceRendering = true;
                    //videograbber.NetworkStreaming = TNetworkStreaming.ns_ASFDirectNetworkStreaming;
                    //videograbber.NetworkStreamingType = TNetworkStreamingType.nst_AudioVideoStreaming;
                    //videograbber.ASFNetworkPort = 3000;

                    //videograbber.Parent = this.d_pb_podglad;
                    //videograbber.StartPreview();

                }
            }
        }

        //            DShowNET.IGraphBuilder graphBuilder;
        //            IBasicAudio basicAudio;
        //            IMediaControl mediaControl;

        //            comType = Type.GetTypeFromCLSID(Clsid.FilterGraph);
        //            if (comType == null)
        //                throw new NotImplementedException(@"DirectShow FilterGraph not installed/registered!");
        //            comObj = Activator.CreateInstance(comType);
        //            graphBuilder = (IGraphBuilder)comObj; comObj = null; graphBuilder.RenderFile(d_tb_sciezka.Text, null);
        //            mediaControl = (IMediaControl)graphBuilder;
        //            videoWindow = graphBuilder as IVideoWindow;
        //            mediaEvt = (IMediaEventEx)graphBuilder;
        //            basicAudio = graphBuilder as IBasicAudio;

        //            comType = Type.GetTypeFromCLSID(Clsid.SampleGrabber);
        //            if (comType == null)
        //                throw new NotImplementedException(@"DirectShow SampleGrabber not installed/registered!");
        //            comObj = Activator.CreateInstance(comType);
        //            sampGrabber = (ISampleGrabber)comObj; comObj = null;

        //            mediaEvt = (IMediaEventEx)graphBuilder;
        //            baseGrabFlt = (IBaseFilter)sampGrabber;

        //            AMMediaType media = new AMMediaType();
        //            media.majorType = MediaType.Video;
        //            media.subType = MediaSubType.RGB24;
        //            media.formatType = FormatType.VideoInfo;		// ???
        //            hr = sampGrabber.SetMediaType(media);


        //            videoInfoHeader = (VideoInfoHeader)Marshal.PtrToStructure(media.formatPtr, typeof(VideoInfoHeader));
        //            Marshal.FreeCoTaskMem(media.formatPtr); media.formatPtr = IntPtr.Zero;


        //            videoWindow.put_WindowStyle(WS_CHILD | WS_CLIPCHILDREN);
        //            videoWindow.put_Owner(picPreview.Handle);
        //            videoWindow.SetWindowPosition(0, 0, picPreview.Width, picPreview.Height);


        //            mediaControl.Run();
        //            timer1.Enabled = true;


                    
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Podaj plik do strumieniowania", "Brak ścieżki dostępu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        private void SetRTPSession()
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
            rtpSession = new RtpSession(ep, new RtpParticipant(Dns.GetHostName(), Dns.GetHostName()), true, true);
            rtpSender = rtpSession.CreateRtpSenderFec(Dns.GetHostName(), PayloadType.Chat, null, 0, 10);
        }

        private void CaptureOK(Bitmap e)
        {
            picPreview.Image = e;
        }

        private void Send()
        {

        //    Trace.WriteLine("!!BTN: toolBarBtnGrab");

        //    if (savedArray == null)
        //    {
        //        int size = videoInfoHeader.BmiHeader.ImageSize;
        //        if ((size < 1000) || (size > 16000000))
        //            return;
        //        savedArray = new byte[size + 64000];
        //    }

        //    Image old = pictureBox1.Image;
        //    pictureBox1.Image = null;
        //    if (old != null)
        //        old.Dispose();
        //    captured = false;
        //    sampGrabber.SetCallback(this, 1);
            if (picPreview.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                picPreview.Image.Save(ms, ImageFormat.Jpeg);
                rtpSender.Send(ms.GetBuffer());
            }
        }

        private void d_b_otworz_Click(object sender, EventArgs e)
        {
            String fileName = GetFileName("Videos (*.avi)|*.avi;*.mpe;*.mpeg");
            if (fileName != null)
            {
                d_tb_sciezka.Text = fileName;
            }
        }

        private string GetFileName(string filter)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = filter;
            dlg.RestoreDirectory = true;
            if (d_tb_sciezka.Text.Length > 0)
            {
                dlg.InitialDirectory = d_tb_sciezka.Text.Substring(0, d_tb_sciezka.Text.LastIndexOf("\\") + 1);
            }
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                return dlg.FileName;
            }
            else
            {
                return null;
            }
        }

        //private void d_ofd_otworz_FileOk(object sender, CancelEventArgs e)
        //{
        //    d_tb_sciezka.Text = d_ofd_otworz.FileName;
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            Send();
        }

        private void groupBox2_Resize(object sender, EventArgs e)
        {
            this.videoWindow.SetWindowPosition(0, 0, picPreview.Width, picPreview.Height);
        }




        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM_GRAPHNOTIFY)
        //    {
        //        if (mediaEvt != null)
        //            OnGraphNotify();
        //        return;
        //    }
        //    base.WndProc(ref m);
        //}

        ///// <summary> graph event (WM_GRAPHNOTIFY) handler. </summary>
        //void OnGraphNotify()
        //{
        //    DsEvCode code;
        //    int p1, p2, hr = 0;
        //    do
        //    {
        //        hr = mediaEvt.GetEvent(out code, out p1, out p2, 0);
        //        if (hr < 0)
        //            break;
        //        hr = mediaEvt.FreeEventParams(code, p1, p2);
        //    }
        //    while (hr == 0);
        //}

        ///// <summary> sample callback, NOT USED. </summary>
        //int ISampleGrabberCB.SampleCB(double SampleTime, IMediaSample pSample)
        //{
        //    Trace.WriteLine("!!CB: ISampleGrabberCB.SampleCB");
        //    return 0;
        //}

        ///// <summary> buffer callback, COULD BE FROM FOREIGN THREAD. </summary>
        //int ISampleGrabberCB.BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
        //{
        //    if (captured || (savedArray == null))
        //    {
        //        Trace.WriteLine("!!CB: ISampleGrabberCB.BufferCB");
        //        return 0;
        //    }

        //    captured = true;
        //    bufferedSize = BufferLen;
        //    Trace.WriteLine("!!CB: ISampleGrabberCB.BufferCB  !GRAB! size = " + BufferLen.ToString());
        //    if ((pBuffer != IntPtr.Zero) && (BufferLen > 1000) && (BufferLen <= savedArray.Length))
        //        Marshal.Copy(pBuffer, savedArray, 0, BufferLen);
        //    else
        //        Trace.WriteLine("    !!!GRAB! failed ");
        //    this.BeginInvoke(new CaptureDone(this.OnCaptureDone));
        //    return 0;
        //}
        //void OnCaptureDone()
        //{
        //    Trace.WriteLine("!!DLG: OnCaptureDone");
        //    try
        //    {
        //        int hr;
        //        if (sampGrabber == null)
        //            return;
        //        hr = sampGrabber.SetCallback(null, 0);

        //        int w = videoInfoHeader.BmiHeader.Width;
        //        int h = videoInfoHeader.BmiHeader.Height;
        //        if (((w & 0x03) != 0) || (w < 32) || (w > 4096) || (h < 32) || (h > 4096))
        //            return;
        //        int stride = w * 3;

        //        GCHandle handle = GCHandle.Alloc(savedArray, GCHandleType.Pinned);
        //        int scan0 = (int)handle.AddrOfPinnedObject();
        //        scan0 += (h - 1) * stride;
        //        Bitmap b = new Bitmap(w, h, -stride, PixelFormat.Format24bppRgb, (IntPtr)scan0);
        //        handle.Free();
        //        savedArray = null;
        //        Image old = pictureBox1.Image;
        //        pictureBox1.Image = b;
        //        if (old != null)
        //            old.Dispose();
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(this, "Could not grab picture\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    }
        //}

    }
}
