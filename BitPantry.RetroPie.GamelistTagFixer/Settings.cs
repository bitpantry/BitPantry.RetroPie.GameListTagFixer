using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPantry.RetroPie.GamelistVideoTagFixer
{
    internal class Settings
    {
        private readonly string _imageDirectoryPath;
        private readonly string _videoDirectoryPath;
        private readonly string _marqueeDirectoryPath;

        public string FilePath { get; }
        public string ImageDirectoryPath => _imageDirectoryPath ?? "./boxart/";
        public string VideoDirectoryPath => _videoDirectoryPath ?? "./snap/";
        public string MarqueeDirectoryPath => _marqueeDirectoryPath ?? "./wheel/";

        internal Settings(string[] args)
        {
            if (args.Length > 0)
                FilePath = args[0];

            if (args.Length > 1)
                _imageDirectoryPath = args[1];

            if (args.Length > 2)
                _videoDirectoryPath = args[2];

            if (args.Length > 3)
                _marqueeDirectoryPath = args[3];
        }
    }
}
