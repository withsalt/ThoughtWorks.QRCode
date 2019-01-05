﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace ThoughtWorks.QRCode.Demo
{
    /// <summary>
    /// 二维码工具
    /// </summary>
    public static class QrCodeUtil
    {
        /// <summary>
        /// 返回二维码图片
        /// </summary>
        public static Bitmap Encode(string text)
        {
            try
            {
                var qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 5;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                return qrCodeEncoder.Encode(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        /// <summary>
        /// 定义参数,生成二维码
        /// </summary>
        public static void Create(string text, string path)
        {
            try
            {
                var image = Encode(text);
                if (image == null)
                    return;
                image.Save(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// 返回二维码定义的字符串
        /// </summary>
        public static string Decode(Bitmap image)
        {
            try
            {
                var qrCodeBitmapImage = new QRCodeBitmapImage(image);
                var qrCodeDecoder = new QRCodeDecoder();
                return qrCodeDecoder.decode(qrCodeBitmapImage); ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "#";
            }
        }

        /// <summary>
        /// 返回二维码定义的字符串
        /// </summary>
        public static string Decode(string path)
        {
            return Decode(new Bitmap(path));
        }
    }
}