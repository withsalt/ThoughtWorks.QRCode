using System;
using System.IO;
using SkiaSharp;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace CommonUtils
{
    /// <summary>
    /// 二维码工具
    /// </summary>
    public static class QrCodeUtil
    {
        /// <summary>
        /// 返回二维码图片
        /// </summary>
        public static SKBitmap Encode(string text)
        {
            var qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 4;
            qrCodeEncoder.QRCodeVersion = 6;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            return qrCodeEncoder.Encode(text);
        }

        /// <summary>
        /// 定义参数,生成二维码
        /// </summary>
        public static void Create(string text, string path)
        {
            var bitmap = Encode(text);
            SaveAsPng(bitmap, path);
        }

        /// <summary>
        /// 返回二维码定义的字符串
        /// </summary>
        public static string Decode(SKBitmap image)
        {
            var qrCodeBitmapImage = new QRCodeBitmapImage(image);
            var qrCodeDecoder = new QRCodeDecoder();
            return qrCodeDecoder.decode(qrCodeBitmapImage); ;
        }

        /// <summary>
        /// 返回二维码定义的字符串
        /// </summary>
        public static string Decode(string path)
        => Decode(SKBitmap.Decode(path));

        /// <summary>
        /// 将 SKBitmap 保存为 PNG 文件。
        /// </summary>
        /// <param name="bitmap">要保存的 SKBitmap 对象。</param>
        /// <param name="outputPath">输出文件的路径。</param>
        public static void SaveAsPng(SKBitmap bitmap, string outputPath)
        {
            if (bitmap == null)
                throw new ArgumentNullException(nameof(bitmap), "SKBitmap 不能为空。");

            if (string.IsNullOrWhiteSpace(outputPath))
                throw new ArgumentException("输出路径不能为空或空白。", nameof(outputPath));

            // 将 SKBitmap 转换为 SKImage
            using (SKImage image = SKImage.FromBitmap(bitmap))
            {
                // 编码为 PNG 格式
                using (SKData data = image.Encode(SKEncodedImageFormat.Png, 100)) // 100 表示最高质量
                {
                    // 将编码后的数据保存到文件
                    using (Stream stream = File.OpenWrite(outputPath))
                    {
                        data.SaveTo(stream);
                    }
                }
            }
        }
    }
}
