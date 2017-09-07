using FileOutputs;
using System;
using System.Collections.Generic;
using System.IO;

namespace Actividad4
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(Outputs.getAllFiles());
            FileInfo[] Files = d.GetFiles("*.txt");

            string output_path4 = @"C:\Users\maple\Documents\9° Semester\CS13309_Archivos_HTML\a4_matricula.txt";
            string consoleOutput = "", fileOutput = "";
            // ------------PARTE 1
            var watch = System.Diagnostics.Stopwatch.StartNew();

            foreach (FileInfo file in Files)
            {
                fileOutput = "";
                var watchEach = System.Diagnostics.Stopwatch.StartNew();
                string htmlContent = File.ReadAllText(file.FullName);
                htmlContent.Trim();
                List<string> sortedWords = new List<string>();
                string[] eachWord = htmlContent.Split(' ');
                foreach (string word in eachWord)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        sortedWords.Add(word.ToLower());
                    }
                }
                sortedWords.Sort();

                foreach (string word in sortedWords)
                {
                    fileOutput += word + "\n";
                }

                consoleOutput = file.Name + " sorted in\t" + watchEach.Elapsed.TotalMilliseconds.ToString() + " ms";
                Console.WriteLine(consoleOutput);
                watchEach.Stop();
                Outputs.output_print(output_path4, fileOutput + "\n" + consoleOutput);
            }

            Console.Read();
        }
    }
}