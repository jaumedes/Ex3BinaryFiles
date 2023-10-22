using System.Security.Cryptography;

internal class Program
{
    private static void Main(string[] args)
    {
        using (FileStream fS = new FileStream("pinguFoca.bmp", FileMode.Open, FileAccess.Read))
        using (BinaryReader bR = new BinaryReader(fS))
        {
            fS.Seek(0, SeekOrigin.Begin);


            char[] header = bR.ReadChars(2);

            if (header[0] == 'B' && header[1] == 'M')
            {                
                int fileSize = bR.ReadInt32();

                fS.Seek(12, SeekOrigin.Current);

                int width = bR.ReadInt32();
                int height = bR.ReadInt32();

                fS.Seek(2, SeekOrigin.Current);

                int bitsPixel = bR.ReadInt16();

                Console.WriteLine($"Mida de l'arxiu: {fileSize} bytes");
                Console.WriteLine($"Amplada: {width} píxels");
                Console.WriteLine($"Alçada: {height} píxels");
                Console.WriteLine($"Bits per píxel: {bitsPixel} bits");
            }       
            else
            {
                Console.WriteLine("No és un arxiu BMP");
            }
        }
    }
}