namespace ThoughtWorks.QRCode.Codec.Data
{
    using System;
    using SkiaSharp;

    public class QRCodeBitmapImage : QRCodeImage
    {
        private SKBitmap image;

        public QRCodeBitmapImage(SKBitmap image)
        {
            this.image = image;
        }


        public virtual int getPixel(int x, int y)
        {
            SKColor color = this.image.GetPixel(x, y);
            return (color.Alpha << 24) | (color.Red << 16) | (color.Green << 8) | color.Blue;
        }

        public virtual int Width =>
            this.image.Width;

        public virtual int Height =>
            this.image.Height;
    }
}

