using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;

namespace Pikhai_Recorder
{
    public partial class MainForm : Form
    {
        [Serializable]
        private class Recording
        {
            [Serializable]
            public class Note
            {
                public TimeSpan Pressed;
                public TimeSpan Released;
            }

            List<Note> Notes = new List<Note>();

            public double Frequency = 100;
            public double Amplitude = 100;
            public double Phase = 0;

            private void PlayForTime(TimeSpan span)
            {
                DirectSoundOut output = new DirectSoundOut();

                long Milliseconds = (int)Math.Ceiling(span.TotalMilliseconds);

                WaveStream wav = new StaticWavStream(Milliseconds, Frequency, Amplitude, Phase);

                output.Init(wav);
                output.Play();
                while (output.PlaybackState == PlaybackState.Playing);
                output.Dispose();

                wav.Close();
            }

            public void Play()
            {
                if (Notes.Count == 0) return;
                int i = 0;

                DateTime start = DateTime.Now;

                while(i < Notes.Count)
                {
                    if(start.Add(Notes[i].Pressed)<=DateTime.Now)
                    {
                        PlayForTime(Notes[i].Released - Notes[i].Pressed);
                        i++;
                    }
                }
            }

            private DateTime StartDate;

            public Recording()
            {
                StartDate = DateTime.Now;
            }

            public void Tap()
            {
                Note n = new Note();
                n.Pressed = DateTime.Now-StartDate;
                Notes.Add(n);
            }

            public void Release()
            {
                if (Notes.Count == 0) return;
                Notes[Notes.Count - 1].Released = DateTime.Now - StartDate;
            }
        }

        bool IsRecording
        {
            get
            {
                return current != null;
            }
        }

        const string RecordStr = "Record";
        const string StopRecordStr = "Stop";
        const Keys TapKey = Keys.ShiftKey;

        Recording last;
        Recording current = null;

        

        public MainForm()
        {
            InitializeComponent();
            this.KeyDown += MainForm_KeyDown;
            this.KeyUp += MainForm_KeyUp; ;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == TapKey && IsRecording && sender == this)
            {
                current.Release();
                RecordButton.Enabled = true;
                pressedup = true;
            }
        }

        bool pressedup = true;

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == TapKey && IsRecording && sender == this && pressedup)
            {
                current.Tap();
                RecordButton.Enabled = false;
                pressedup = false;
            }
        }

        private void RecordButton_Click(object sender, EventArgs e)
        {
            if(!IsRecording)
            {
                current = new Recording();
                current.Frequency = FreqTrack.Value;
                current.Amplitude = AmpTrack.Value;
                RecordButton.Text = StopRecordStr;

                PlayButton.Enabled = false;
                SaveButton.Enabled = false;
                LoadButton.Enabled = false;
                FreqTrack.Enabled = false;
                AmpTrack.Enabled = false;
            }
            else
            {
                last = current;
                current = null;
                RecordButton.Text = RecordStr;

                PlayButton.Enabled = true;
                SaveButton.Enabled = true;
                LoadButton.Enabled = true;
                FreqTrack.Enabled = true;
                AmpTrack.Enabled = true;
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if(last!=null)
            {
                last.Play();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.InitialDirectory = System.Environment.CurrentDirectory;
            d.Filter = "Pikh Cringe File (*.pikh)|*.pikh";
            d.DefaultExt = "pikh";
            d.AddExtension = true;
            var res = d.ShowDialog();
            if(res == DialogResult.OK)
            {
                FileStream str = new FileStream(d.FileName, FileMode.Create);
                BinaryFormatter f = new BinaryFormatter();
                f.Serialize(str, last);
                str.Close();
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.InitialDirectory = System.Environment.CurrentDirectory;
            d.Filter = "Pikh Cringe File (*.pikh)|*.pikh";
            d.DefaultExt = "pikh";
            d.AddExtension = true;
            var res = d.ShowDialog();
            if (res == DialogResult.OK)
            {
                FileStream str = new FileStream(d.FileName, FileMode.Open);
                BinaryFormatter f = new BinaryFormatter();
                last = (Recording)f.Deserialize(str);
                SaveButton.Enabled = true;
                PlayButton.Enabled = true;

                str.Close();

                AmpTrack.Value = (int)last.Amplitude;
                FreqTrack.Value = (int)last.Frequency;
                Debug.WriteLine("Freq: " + FreqTrack.Value + " Amp: " + AmpTrack.Value);
            }
        }

        private void FreqTrack_Scroll(object sender, EventArgs e)
        {
        }

        private void AmpTrack_Scroll(object sender, EventArgs e)
        {
        }
    }
}
