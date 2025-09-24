namespace KeanSoftware.Models
{
    public class Lesson2 {
        public string name;
        public string[] filesNames;
        public string description;
        public string[] fileContents;

        public Lesson2(string _name, string[] _fileNames, string _description, string[] _fileContents)
        {
            name = _name;
            filesNames = _fileNames;
            description = _description;
            fileContents = _fileContents;
        }
        
    }
    public class Lessons {
        public string[] names;
        public string[] description;
        public Lessons(string[] strings, string[] _description){
            names = strings;
            description = _description;
        }

    }
    public class Link {
        public string link;
        public string linkName;

        public int sizeX;
        public int sizeY;
        public Link(string link, string linkName, int sizeX, int sizeY)
        {
            this.link = link;
            this.linkName = linkName;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }
    }
}
