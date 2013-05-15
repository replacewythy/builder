using System;
using System.IO;
using System.Diagnostics;

namespace Builder
{
    public class Builder
    {
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
            
        }

        public static void TargetClean()
        {
            
        }

        public static void TargetCompile()
        {
            
        }

        public static void TargetTest()
        {
            
        }
    }
}