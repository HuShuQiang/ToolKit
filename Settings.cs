using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 工具集合
{
    internal class Settings
    {

        //声明写INI文件的API函数
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        //声明读INI文件的API函数
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public string Path = "./Settings.ini";
        public Settings(string INIPath = "./Settings.ini")
        {
            Path = INIPath;
        }
        public void Write(string Section, string Key, string Value)
        {
            if (!File.Exists(Path))
            {
                FileStream fs = new FileStream(Path, FileMode.CreateNew);
                fs.Close();
            }
            WritePrivateProfileString(Section, Key, Value, Path);
        }

        public string Read(string Section, string Key)
        {
            if (!File.Exists(Path))
            {
                return "";
            }
            StringBuilder Str = new StringBuilder(4096);
            int i = GetPrivateProfileString(Section, Key, "", Str, 4096, Path);
            return Str.ToString();
        }

    }


}
