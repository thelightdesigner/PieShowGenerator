namespace PieShowGenerator
{
    internal class Program
    {
        public const string OUTFILE = "C:\\Users\\stypl\\source\\repos\\PieShow\\pieshow.bin";
        static void Main(string[] args)
        {
            Color[,] ledFrames = VideoConverter.FromVideo(@"");
            File.WriteAllBytes(OUTFILE, PieShowFile.ConstructPieShowBinary(ledFrames, 60));
        }
    }
}
