using IronBarCode;
using System.Drawing;
namespace EveryoneReads.Backend
{
    public static class BarcodeReader
    {
        public static string ReadISBNBarcode(Image img)
        {
            var resultFromFile = IronBarCode.BarcodeReader.Read(img); // From a file
            return string.Join("", resultFromFile.Values());
        }

    }
}
