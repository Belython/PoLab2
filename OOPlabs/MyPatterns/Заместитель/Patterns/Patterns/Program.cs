using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata;

namespace Patterns
{
    class Video
    {}

    interface IDownloader
    {
        Video Dowland(string url);
    }

    class YoutudeDowlander : IDownloader
    {
        public Video Dowland(string url)
        {
            Console.WriteLine("dowland youtube");
            return new Video();
        }
    }

    class CachedDowlander : IDownloader
    {
        private IDownloader _d;
        private Dictionary<string, Video> _cache = new Dictionary<string, Video>();

        public CachedDowlander(IDownloader d)
        {
            SetDownloader(d);
        }

        public void SetDownloader(IDownloader d)
        {
            _d = d;
        }
        public Video Dowland(string url)
        {
            if (!_cache.TryGetValue(url, out var v))
            {
                v = _d.Dowland(url);
                _cache[url] = v;
            }

            return v;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var d = new CachedDowlander(new YoutudeDowlander());
            d.Dowland("www");
            d.Dowland("www");
            d.Dowland("www");
            d.Dowland("www");
        }
    }
}
