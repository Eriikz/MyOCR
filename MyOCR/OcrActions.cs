using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tesseract;

namespace MyOCR
{
    internal class OcrActions
    {
        public static bool ValidatorExtension(string ImagePath)
        {
            var ImageExtensions = new List<string>()
            {
                {".jpg"},
                {".jpeg"},
                {".gif"},
                {".bmp"},
                {".png"},
                {".tif"},
                {".tiff"},
            };

            return ImageExtensions.Contains(ImagePath);
        }

        public static void ImageToText(string ImagePath, string language = "por", bool iterator = false)
        {

            if (!string.IsNullOrEmpty(ImagePath))
            {
                try
                {
                    using (var engine = new TesseractEngine(@"./tessdata", language, EngineMode.Default))
                    {

                        if (ValidatorExtension(Path.GetExtension(ImagePath)))
                        {
                            //ver se são 1 ou varios arquivos

                            using (var img = Pix.LoadFromFile(ImagePath))
                            {
                                using (var page = engine.Process(img))
                                {
                                    var text = page.GetText();

                                    Console.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());

                                    Console.WriteLine("Text (GetText): \r\n{0}", text);

                                    if (iterator)
                                    {
                                        Console.WriteLine("Text (iterator):");
                                        using (var iter = page.GetIterator())
                                        {
                                            iter.Begin();

                                            do
                                            {
                                                do
                                                {
                                                    do
                                                    {
                                                        do
                                                        {
                                                            if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
                                                            {
                                                                Console.WriteLine("<BLOCK>");
                                                            }

                                                            Console.Write(iter.GetText(PageIteratorLevel.Word));
                                                            Console.Write(" ");

                                                            if (iter.IsAtFinalOf(PageIteratorLevel.TextLine, PageIteratorLevel.Word))
                                                            {
                                                                Console.WriteLine();
                                                            }
                                                        } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));

                                                        if (iter.IsAtFinalOf(PageIteratorLevel.Para, PageIteratorLevel.TextLine))
                                                        {
                                                            Console.WriteLine();
                                                        }
                                                    } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                                } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                                            } while (iter.Next(PageIteratorLevel.Block));
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Informe um arquivo de imagem valido!");
                        }
                    }
                }
                catch (Exception e)
                {
                    Trace.TraceError(e.ToString());
                    Console.WriteLine("Unexpected Error: " + e.Message);
                    Console.WriteLine("Details: ");
                    Console.WriteLine(e.ToString());
                }
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("Informe um arquivo de imagem");
            }
        }
    }
}
