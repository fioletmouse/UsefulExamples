using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UsefulExamples
{
    static class Streams
    {
        const int BufferSize = 8192;

        // в последних версиях дот нета есть встроенная
        public static void CopyTo(this Stream input, Stream output)
        {
            byte[] buffer = new byte[BufferSize];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }

        public static byte[] ReadFully(this Stream input)
        {
            using (MemoryStream tempStream = new MemoryStream())
            {
                CopyTo(input, tempStream);
                return tempStream.ToArray();
            }
        }

        public static void Method()
        {
            WebRequest request = WebRequest.Create("http://---");
            using (WebResponse response = request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (FileStream output = File.Create("response.dat"))
            {
                responseStream.CopyTo(output);
            }
        }
    }
}
