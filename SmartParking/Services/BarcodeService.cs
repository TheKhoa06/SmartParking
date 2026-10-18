using System;
using System.Drawing;
using ZXing;
using ZXing.Common;

namespace SmartParking.Services
{
    public static class BarcodeService
    {
        public static Bitmap GenerateQrCode(string content, int width = 200, int height = 200)
        {
            if (string.IsNullOrWhiteSpace(content))
                content = "SMARTPARKING";

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = 1
                }
            };
            return writer.Write(content);
        }

        public static string DecodeQrCode(Bitmap bitmap)
        {
            try
            {
                var reader = new BarcodeReader();
                var result = reader.Decode(bitmap);
                return result != null ? result.Text : null;
            }
            catch
            {
                return null;
            }
        }
    }
}
