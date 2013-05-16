using System;
using System.IO;
using System.Diagnostics;

namespace Builder
{
    public class Builder
    {
        private const string buildDir = "build";
        private const string outputFile = "build/WebCreatures.exe";
        private static string files = "";

        static void Main(string[] args)
        {
            Console.Write("\nTarget: ");
            string target = Console.ReadLine();
            switch(target)
            {
                case "":
                case "default":
                    TargetDefault();
                    break;
                case "clean":
                    TargetClean();
                    break;
                case "compile":
                    TargetCompile();
                    break;
                case "test":
                    TargetTest();
                    break;
            }
        }

        public static void TargetDefault()
        {
            TargetCompile();
        }

        public static void TargetClean()
        {
            if(Directory.Exists(buildDir))
            {
                Directory.Delete(buildDir, true);
            }
        }

        public static void TargetCompile()
        {
            TargetClean();
            Directory.CreateDirectory(buildDir);
            DirectoryInfo thisDir = new DirectoryInfo(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            string currentPath = thisDir.ToString();
            DirectoryInfo[] srcArray = thisDir.GetDirectories("src");
            if(srcArray.Length == 1)
            {
                DirectoryInfo srcDir = srcArray[0];
                FileInfo[] sourceFiles = srcDir.GetFiles("*.cs", SearchOption.AllDirectories);
                foreach(FileInfo fi in sourceFiles)
                {
                    addFile(fi, currentPath);
                }
                Process process = new Process();
                process.StartInfo.FileName = "mcs";
                process.StartInfo.Arguments = files.Trim() + " -out:" + outputFile;
                process.Start();
            }
            else
            {
                Console.WriteLine("There is a problem with the src directory.");
            }
        }

        public static void TargetTest()
        {
            TargetCompile();
        }

        public static void addFile(FileInfo fi, string path)
        {
            files += " " + fi.ToString();
        }
    }
}