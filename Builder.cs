using System;
using System.IO;
using System.Diagnostics;

namespace Builder
{
    public class Builder
    {
        private const string buildDir = "build";

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
                Directory.Delete(buildDir);
            }
        }

        public static void TargetCompile()
        {
            
        }

        public static void TargetTest()
        {
            
        }
    }
}