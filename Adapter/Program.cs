using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            string video = "video.flv";

            IVideoConverter[] converters = {new MP4Converter(), new AVIConverter(), new MOVConverter()};

            foreach (var converter in converters)
            {
                converter.Convert(video);
            }
        }
    }

    interface IVideoConverter
    {
        void Convert(string video);
    }

    class MP4Converter : IVideoConverter
    {
        public void Convert(string video)
        {
            Console.WriteLine($"Output: {video.Substring(0, video.IndexOf(".")) + ".mp4"}");
        }
    }

    class AVIConverter : IVideoConverter
    {
        public void Convert(string video)
        {
            Console.WriteLine($"Output: {video.Substring(0, video.IndexOf(".")) + ".avi"}");
        }
    }

    class MOVConverterByApple
    {
        private string video = "null";

        public void SetVideo(string video)
        {
            this.video = video;
        }

        public string GetConvertedVideo()
        {
            return video.Substring(0, video.IndexOf(".")) + ".mov";
        }
    }

    class MOVConverter : IVideoConverter
    {
        private MOVConverterByApple adaptee = new MOVConverterByApple();

        public void Convert(string video)
        {
            adaptee.SetVideo(video);
            Console.WriteLine($"Output: {adaptee.GetConvertedVideo()}");
        }
    }
}
