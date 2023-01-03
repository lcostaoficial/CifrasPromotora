using System.IO;
using System.Web;

namespace CIFRAS.Infra.CrossCutting.Helpers
{
    public static class FileExtension
    {
        public static byte[] ToByte(this HttpPostedFileBase file)
        {
            BinaryReader binaryReader = new BinaryReader(file.InputStream);
            return binaryReader.ReadBytes(file.ContentLength);
        }

        public static MemoryStream ToMemoryStream(this HttpPostedFileBase file)
        {
            return new MemoryStream(file.ToByte());
        }

        public static StreamReader ToStreamReader(this HttpPostedFileBase file)
        {
            return new StreamReader(file.ToMemoryStream());
        }
    }
}