using System;
using System.IO;
using System.Text;

namespace Ar.Web.Helpers
{
    public static class UtilFunctions
    {

        public static Stream GetStreamFromText(string text)
        {
            Stream stream = new MemoryStream();
            byte[] byteArray = Encoding.UTF8.GetBytes(text);
            stream.Write(byteArray, 0, byteArray.Length);
            // Set the position at the beginning.
            stream.Position = 0;

            return stream;
        }
    }
}
