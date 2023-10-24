using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HANOI_1._0
{
    public class GameSerializer
    {
        public void SaveGame(TowerOfHanoi game, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TowerOfHanoi));
                serializer.Serialize(writer, game);
            }
        }

        public TowerOfHanoi LoadGame(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TowerOfHanoi));
                return (TowerOfHanoi)serializer.Deserialize(reader);
            }
        }
    }
}
