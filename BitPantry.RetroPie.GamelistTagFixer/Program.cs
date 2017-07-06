using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BitPantry.RetroPie.GamelistVideoTagFixer
{
    class Program
    {
        private static Settings _settings;

        static void Main(string[] args)
        {
            // parse args

            _settings = new Settings(args);

            // open file

            var doc = new XmlDocument();
            doc.Load(_settings.FilePath);

            // update game elements

            foreach (XmlElement game in doc.SelectNodes("/gameList/game"))
            {
                var name = game.SelectSingleNode("name");

                if (game.SelectSingleNode("image") == null)
                    game.AppendChild(CreateElement(doc, "image", Path.Combine(_settings.ImageDirectoryPath, $"{name.InnerText}.png")));

                if (game.SelectSingleNode("video") == null)
                    game.AppendChild(CreateElement(doc, "video", Path.Combine(_settings.VideoDirectoryPath, $"{name.InnerText}.mp4")));

                if (game.SelectSingleNode("marquee") == null)
                    game.AppendChild(CreateElement(doc, "marquee", Path.Combine(_settings.MarqueeDirectoryPath, $"{name.InnerText}.png")));
            }

            // save document

            doc.Save(_settings.FilePath);
        }

        private static XmlNode CreateElement(XmlDocument doc, string name, string innerText)
        {
            var node = doc.CreateElement(name);
            node.InnerText = innerText;
            return node;
        }
    }
}
