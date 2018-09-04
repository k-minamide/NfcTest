using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace NfcTest.Nfc
{
    public class ReaderWriter
    {
        public static Tag GetInformation()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("python", "./nfctest.py");

            startInfo.CreateNoWindow = true; // コンソールを開かない
            startInfo.UseShellExecute = false; // シェル機能を使用しない

            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;

            Process process = Process.Start(startInfo);
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                string error = process.StandardError.ReadToEnd();
                throw new Exception(string.IsNullOrEmpty(error) ? process.StandardOutput.ReadToEnd() : error);
            }

            return ToTag(process.StandardOutput.ReadToEnd()); // 標準出力の読み取り
        }

        private static Tag ToTag(string jsonText)
        {
            Tag tag = JsonConvert.DeserializeObject<Tag>(jsonText);

            switch (tag.type)
            {
                case Type.Type3Tag:
                    tag = JsonConvert.DeserializeObject<Type3Tag>(jsonText);
                    break;
            }

            return tag;
        }
    }
}
