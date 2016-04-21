using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.IO;
using System.Reflection;
using System.Windows.Resources;
using System.Threading;
using System.Threading.Tasks;
//using System.Media;

namespace HalfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private WaveStream CreateInputStream(Stream fileName)
        {
            WaveChannel32 inputStream;
            WaveStream mp3Reader = new Mp3FileReader(fileName);
            inputStream = new WaveChannel32(mp3Reader);
            return inputStream;
            //return/* volumeStream;*/
        }
        //System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.music);



        //public static void PlayMp3FromUrl(string url)
        //{
        //    using (Stream ms = new MemoryStream())
        //    {
        //        using (Stream stream = GetResourceStream(url))
        //        {
        //            byte[] buffer = new byte[32768];
        //            int read;
        //            while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
        //            {
        //                ms.Write(buffer, 0, read);
        //            }
        //        }

        //        ms.Position = 0;
        //        using (WaveStream blockAlignedStream =
        //            new BlockAlignReductionStream(
        //                WaveFormatConversionStream.CreatePcmStream(
        //                    new Mp3FileReader(ms))))
        //        {
        //            using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
        //            {
        //                waveOut.Init(blockAlignedStream);
        //                waveOut.Play();
        //                while (waveOut.PlaybackState == PlaybackState.Playing)
        //                {
        //                    System.Threading.Thread.Sleep(100);
        //                }
        //            }
        //        }
        //    }
        //}



        //public static Stream GetResourceStream(string filename)
        //{
        //    Assembly asm = Assembly.GetExecutingAssembly();
        //    string resname = asm.GetName().Name + "." + filename;
        //    return asm.GetManifestResourceStream(resname);
        //}
        WaveOut waveOut = new WaveOut();

        public MainWindow()
        {
            InitializeComponent();
            //player.PlayLooping();
            //SoundPlayer m_MySound = new SoundPlayer();
            //m_MySound.Stream = Properties.Resources.music;

            //m_MySound.PlayLooping();

            //Stream mp3file = GetResourceStream("music");

            //PlayMp3FromStream(mp3file);

            //Mp3FileReader mp3reader = new Mp3FileReader(mp3file);

            //mp3reader.

            //PlayMp3FromUrl("music");



            //  StreamResourceInfo resource = Application.GetResourceStream(
            //new Uri("YearBook;component/Resources/Music/1.mp3", UriKind.Relative));


            StreamResourceInfo resource = Application.GetResourceStream(
            new Uri("pack://application:,,,/HalfLife;component/Resources/Valve - Half-Life Theme.mp3", UriKind.Absolute));
            var mainOutputStream = CreateInputStream(resource.Stream);            

            //LoopStream loop = new LoopStream(mainOutputStream);
                       

            
            
            //waveOut.Init(mainOutputStream);
            waveOut.Init(mainOutputStream);


            //Task.Factory.StartNew(PlayInLoop);
            waveOut.Play();

            //waveOutDevice.Init(mainOutputStream);
        }

        //void PlayInLoop()
        //{
        //    for(;;)
        //    {
        //        if (waveOut.PlaybackState == PlaybackState.Paused || waveOut.PlaybackState == PlaybackState.Stopped)
        //            waveOut.Play();

        //        Thread.Sleep(100);
        //    }            
        //}

        private void Calculate_Button_Click(object sender, RoutedEventArgs e)
        {
            double initialMass, expectedMass, halfLife;
            bool is_initialMass, is_expectedMass, is_halfLife;

            is_halfLife = double.TryParse(HalfLife_TextBox.Text, out halfLife);
            is_initialMass = double.TryParse(InitialMass_TextBox.Text, out initialMass);
            is_expectedMass = double.TryParse(ExpectedMass_TextBox.Text, out expectedMass);

            if (is_expectedMass && is_initialMass && is_halfLife)
            {
                if (initialMass > 0 && expectedMass > 0 && halfLife > 0)
                {
                    if (expectedMass == initialMass)
                    {
                        Result_Label.Content = @"Ну равны же, ну :\";
                        return;
                    }
                    else if (expectedMass > initialMass)
                    {
                        Result_Label.Content = @"Конечная масса не может быть больше начальной";
                        return;
                    }
                        
                }
                else
                {
                    Result_Label.Content = @"Значения должны быть больше 0";
                    return;
                }                   
            }
            else
            {
                Result_Label.Content = @"Некорректный ввод данных";
                return;
            }


            var massRelation = initialMass / expectedMass;
            var halfLife_Multiplier = Math.Log(massRelation, 2);
            var time = halfLife_Multiplier * halfLife;

            //if(time % 1 == 0)
            //    Result_Label.Content = String.Format("Распадётся за {0}", time);
            //else
            Result_Label.Content = String.Format("Распадётся за {0}", time);
        }












        //public class LoopStream : WaveStream
        //{
        //    WaveStream sourceStream;

        //    /// <summary>
        //    /// Creates a new Loop stream
        //    /// </summary>
        //    /// <param name="sourceStream">The stream to read from. Note: the Read method of this stream should return 0 when it reaches the end
        //    /// or else we will not loop to the start again.</param>
        //    public LoopStream(WaveStream sourceStream)
        //    {
        //        this.sourceStream = sourceStream;
        //        this.EnableLooping = true;
        //    }

        //    /// <summary>
        //    /// Use this to turn looping on or off
        //    /// </summary>
        //    public bool EnableLooping { get; set; }

        //    /// <summary>
        //    /// Return source stream's wave format
        //    /// </summary>
        //    public override WaveFormat WaveFormat
        //    {
        //        get { return sourceStream.WaveFormat; }
        //    }

        //    /// <summary>
        //    /// LoopStream simply returns
        //    /// </summary>
        //    public override long Length
        //    {
        //        get { return sourceStream.Length; }
        //    }

        //    /// <summary>
        //    /// LoopStream simply passes on positioning to source stream
        //    /// </summary>
        //    public override long Position
        //    {
        //        get { return sourceStream.Position; }
        //        set { sourceStream.Position = value; }
        //    }

        //    public override int Read(byte[] buffer, int offset, int count)
        //    {
        //        int totalBytesRead = 0;

        //        while (totalBytesRead < count)
        //        {
        //            int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
        //            if (bytesRead == 0)
        //            {
        //                if (sourceStream.Position == 0 || !EnableLooping)
        //                {
        //                    // something wrong with the source stream
        //                    break;
        //                }
        //                // loop
        //                sourceStream.Position = 0;
        //            }
        //            totalBytesRead += bytesRead;
        //        }
        //        return totalBytesRead;
        //    }
        //}
    }
}
