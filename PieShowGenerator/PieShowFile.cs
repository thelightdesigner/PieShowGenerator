using Emgu.CV;
using Emgu.CV.Ocl;
using Emgu.CV.Structure;

namespace PieShowGenerator
{
    class PieShowFile(uint songID, uint songStartTimeMillis, uint bpm, uint fps, PieShowFile.ScalingMethod scalingMethod)
    {
        public Color[,]? Frames { get; set; } = null;
        public uint SongID { get; } = songID;
        public uint SongStartTime { get; } = songStartTimeMillis;
        public uint BPM { get; } = bpm;
        public uint FPS { get; } = fps;
        public ScalingMethod ScaleMethod { get; } = scalingMethod;

        /// <summary>
        /// PieShowFile v1
        /// 
        /// <code>
        /// [][][][] #file format version = 1
        /// [][][][] #LED Start IDX = 40
        /// [][][][] #strip length
        /// [][][][] #total frames
        /// [][][][] #frames per second
        /// [][][][] #song id
        /// [][][][] #song start time (milliseconds)
        /// [][][][] #scaling method
        /// [][][][] #unused
        /// [][][][] #unused
        /// [R][G][B][R][G][B]... #frame 1
        /// [R][G][B][R][G][B]... #frame 2
        /// [R][G][B][R][G][B]... #frame 3
        /// ...
        /// </code>
        /// 
        /// </summary>
        /// <param name="ledFrames"></param>
        /// <param name="FPS"></param>
        /// <param name="songID"></param>
        /// <param name="scalingMethod"></param>
        /// <returns></returns>
        public byte[] ConstructBinaryFile()
        {
            if (Frames is null) throw new Exception("Unassigned Frames.");

            uint framesLen = (uint)Frames.GetLength(0);
            uint stripLen = (uint)Frames.GetLength(1);
            uint preambleBytes = 10 * sizeof(int);

            byte[] b_show = new byte[Frames.Length * 3 + preambleBytes];
            uint preambleIdx = 0;
            void pushPreamble(uint number) => Array.Copy(BitConverter.GetBytes(number), 0, b_show, sizeof(uint) * preambleIdx++, sizeof(uint));
            pushPreamble(1);
            pushPreamble(preambleBytes);
            pushPreamble(stripLen);
            pushPreamble(framesLen);
            pushPreamble(FPS);
            pushPreamble(SongID);
            pushPreamble(SongStartTime);
            pushPreamble((uint)(int)ScaleMethod);

            for (uint f = 0; f < framesLen; f++)
            {
                for (uint i = 0; i < stripLen; i++)
                {
                    uint redByteIdx = preambleBytes + i * 3 + f * 3 * stripLen;
                    b_show[redByteIdx] = Frames[f, i].R;
                    b_show[redByteIdx + 1] = Frames[f, i].G;
                    b_show[redByteIdx + 2] = Frames[f, i].B;
                }
            }
            return b_show;
        }
        public void FillFromVideo(string path)
        {
            using (var capture = new VideoCapture(path))
            {
                Mat mat = new();
                while (capture.Grab())
                {
                    capture.Retrieve(mat);
                    Image<Rgb, byte> frame = mat.ToImage<Rgb, byte>();
                    frame[2,2]
                }
            }
        }

        public enum ScalingMethod
        {
            NotAllowed
        }
    }
}
