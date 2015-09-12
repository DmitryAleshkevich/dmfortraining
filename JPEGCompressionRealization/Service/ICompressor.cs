using System.Drawing;

namespace JPEGCompressionRealization.Service
{
    public interface ICompressor
    {
        Bitmap Compress(string path);
    }
}
