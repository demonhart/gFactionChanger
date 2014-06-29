using System.IO;

namespace gFactionChanger
{
    public class Reader
    {
        private BinaryReader read;

        public void setReader(BinaryReader read)
        {
            this.read = read;
        }

        public BinaryReader getReader()
        {
            return this.read;
        }


    }
}
