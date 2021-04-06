using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Patterns
{
    class Config
    {
        protected Config()
        {
            //
        }

        private static Config _config;

        public static Config Instance()
        {
            if (_config == null)
            {
                _config = new Config();
            }

            return _config;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cfg = Config.Instance();

        }
    }
}
