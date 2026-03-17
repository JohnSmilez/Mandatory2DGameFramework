using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mandatory2DGameFramework.Configuration
{
    public class ConfigReader
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public GameDifficulty Difficulty { get; set; }

        public void StartReadConfigFile(string filepath)
        {
            XmlDocument cfg = new XmlDocument();
            cfg.Load(filepath);

            XmlNode? maxXNode = cfg.DocumentElement.SelectSingleNode("World/MaxX");

            if (maxXNode != null)
            {
                MaxX = int.Parse(maxXNode.InnerText);
            }
            XmlNode? maxYNode = cfg.DocumentElement.SelectSingleNode("World/MaxY");

            if (maxYNode != null)
            {
                MaxY = int.Parse(maxYNode.InnerText);
            }
            XmlNode? difficultyNode = cfg.DocumentElement.SelectSingleNode("World/Difficulty");

            if (difficultyNode != null)
            {
                // parse string til enum
                if (Enum.TryParse(difficultyNode.InnerText, true, out GameDifficulty diff))
                    Difficulty = diff;
                else
                    Difficulty = GameDifficulty.Medium; // default
            }
        }
    }
}