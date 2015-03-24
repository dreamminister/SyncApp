using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync
{
    public enum Dir 
    {
        First,
        Second
    }

    class Model
    {
        public Dictionary<Dir, List<string>> Files { get; set; }
        Dictionary<Dir, string> DirToPathMap = new Dictionary<Dir, string>();

        public List<string> FirstDir 
        {
            get { return Files[Dir.First]; }
        }

        public List<string> SecondDir
        {
            get { return Files[Dir.Second]; }
        }

        public Model() 
        {
            Files = new Dictionary<Dir, List<string>>()
            {
                { Dir.First, new List<string>() },
                { Dir.Second, new List<string>() }
            };
        }

        internal void AddFiles(string path, Dir dirNumber)
        {
            string[] files = Directory.GetFiles(path);
            
            DirToPathMap[dirNumber] = path;

            Files[dirNumber].Clear();
            Files[dirNumber].AddRange(files.Select(file => Path.GetFileName(file)).ToArray());
        }

        internal bool Add(string param)
        {
            throw new NotImplementedException();
        }

        internal bool Remove(string param)
        {
            throw new NotImplementedException();
        }

        internal bool Sync()
        {
            throw new NotImplementedException();
        }

        internal bool Reset()
        {
            throw new NotImplementedException();
        }
    }
}
