using CommonUtils;
using System;

namespace ThoughtWorks.QRCode.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "D:/" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            var qr = QrCodeUtil.Encode("Hello World!");
            QrCodeUtil.SaveAsPng(qr, path);
            Console.WriteLine(QrCodeUtil.Decode(qr));

            path = "D:/" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            QrCodeUtil.Create("中国智造，惠及全球！", path);
            Console.WriteLine(QrCodeUtil.Decode(path));

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
