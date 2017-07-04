using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Pikhai_Recorder
{
    class StaticWavStream : WaveStream
    {
        long len;

        public double Frequency = 1024;
        public double Amplitude = 100;
        public double Phase = 0;

        public StaticWavStream(long MilliSeconds)
        {
            len = MilliSeconds; 
        }
        public StaticWavStream(long MilliSeconds, double Freq, double Amp, double Ph)
        {
            len = MilliSeconds;
            Frequency = Freq;
            Amplitude = Amp;
            Phase = Ph;
        }

        private WaveFormat format = new WaveFormat(44100, 16, 1);

        public override WaveFormat WaveFormat { get { return format; } }

        public override long Length { get { return (long)Math.Round(len/1000.0*format.SampleRate); } }

        public override long Position { get; set; }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int i = offset;
            int read = 0;
            while(i<count && Position<Length)
            {
                float sample = (float)Amplitude * (float)Math.Sin(2*Math.PI*Frequency*((double)Position / format.SampleRate) + Phase);
                var bytes = BitConverter.GetBytes(sample*Int16.MaxValue);
                buffer[i] = bytes[0];
                if (i + 1 < count)
                {
                    buffer[i + 1] = bytes[1];
                    read += 2;
                }
                else read++;

                Position++;
                i += 2;
            }

            return read;
        }
    }
}
