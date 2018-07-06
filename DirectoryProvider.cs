using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gra
{
    public static class DirectoryProvider //static class with method that returns relative path created from absolute path
    {
        //returns relative path created from absolute path
        public static string GetRelativeDirectory(string absolutePath)
        {
            string[] CurDir = Directory.GetCurrentDirectory().Split('\\');
            string[] AbsolutePath = absolutePath.Split('\\');
            string relativePath = "";

            int CDMaxIndex = CurDir.Length - 1;
            int APMaxIndex = AbsolutePath.Length - 1;
            int ActualAPIndex;

            try
            {
            for (int i = CDMaxIndex; i > 0; i--)//iterates through all elements of current directory
            {
                for (int l = APMaxIndex; l > 0; l--)//iterates through all elements of given path
                {
                    if (CurDir[i] == AbsolutePath[l])//looks for the common element in path and starts building a relative path           
                    {                                   //from this spot
                        ActualAPIndex = l;
                        for (int j = 0; j <= i; j++)
                        {
                            relativePath += CurDir[j] + "\\";
                        }
                        for (int k = ActualAPIndex + 1; k <= APMaxIndex; k++)
                        {
                            relativePath += AbsolutePath[k];
                            if (k != AbsolutePath.Length - 1)
                            {
                                relativePath += "\\";
                            }
                        }
                        return relativePath;
                    }
                }
            }
            return relativePath;
            }
            catch { return null; }
        }
    }
}
