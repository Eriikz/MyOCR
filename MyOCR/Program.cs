using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace MyOCR
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string Pathrr = "C:\\Users\\019268631\\Desktop\\2.png";


           // Email.EnviarEmail();

            var contents = System.IO.File.ReadAllBytes(Pathrr);
            var result = Convert.ToBase64String(contents);


            OcrActions.ImageToText(Pathrr);
        }
    }
}