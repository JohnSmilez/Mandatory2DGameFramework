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
            XmlNode? difficultyNode = cfg.DocumentElement.SelectSingleNode("World/GameDifficulty");

            if (difficultyNode != null)
            {
                string value = difficultyNode.InnerText.ToLower();

                if (value == "easy")
                    Difficulty = GameDifficulty.Easy;
                else if (value == "normal")
                    Difficulty = GameDifficulty.Medium;
                else if (value == "hard")
                    Difficulty = GameDifficulty.Hard;
                else
                    Difficulty = GameDifficulty.Medium; // default
            }
        }
    }
}