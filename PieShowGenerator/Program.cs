namespace PieShowGenerator
{
    internal class Program
    {
        public const string OUTFILE = "C:\\Users\\stypl\\source\\repos\\PieShowGenerator\\pieshow.bin";
        static void Main(string[] args)
        {
            /*
            Color[,] test = new Color[,] 
            {
                {new Color(0,0,0), new Color(255,255,255), new Color(0,0,0), new Color(100,100,100) },
                {new Color(255,255,255), new Color(0,0,0), new Color(100,100,100), new Color(0,0,0),},
                {new Color(0,0,0), new Color(0,0,0), new Color(0,0,0), new Color(0,0,0) }
            };

            PieShowFile pieshow = new(0,0,1);
            pieshow.Frames = test;

            File.WriteAllBytes(OUTFILE, pieshow.ConstructBinaryFile());*/

            PieShowFile pieshow = new PieShowFile(0, 0, 24);
            pieshow.FillFromVideo(@"E:\Users\stypl\Videos\daves.mp4");
        }
    }
}
