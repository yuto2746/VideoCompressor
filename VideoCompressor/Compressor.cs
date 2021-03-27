using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace VideoCompressor
{
    class Compressor
    {
        public void Compress(string src, string dest, string codec)
        {
            string encoder = "libx264";
            if (codec.Equals("H265"))
            {
                encoder = "libx265";
            }
            else if (codec.Equals("H264"))
            {
                encoder = "libx264";
            }

            var arguments = $"-i \"{src}\" -c:a copy -c:v {encoder} -crf 22 -tag:v hvc1 \"{dest}\"";

            var process = Process.Start(new ProcessStartInfo("ffmpeg.exe", arguments)
            {
                CreateNoWindow = true,
                UseShellExecute = false
            });

            process.WaitForExit();
        }
    }
}
