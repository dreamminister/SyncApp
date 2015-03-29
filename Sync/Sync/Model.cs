using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync
{
    // directories enum
    public enum Dir 
    {
        First,
        Second
    }

    class Model
    {
        // all files map
        public Dictionary<Dir, List<string>> Files { get; set; }
        // dir name to its system path map
        Dictionary<Dir, string> DirToPathMap = new Dictionary<Dir, string>();
        // files from first dir
        public List<string> FirstDirFiles 
        {
            get { return Files[Dir.First]; }
        }
        // files from second dir
        public List<string> SecondDirFiles
        {
            get { return Files[Dir.Second]; }
        }

        // constructor, just default values
        public Model() 
        {
            Files = new Dictionary<Dir, List<string>>()
            {
                { Dir.First, new List<string>() },
                { Dir.Second, new List<string>() }
            };
        }

        // refreshes content of model from folder paths, not from UI!
        private void Refresh() 
        {
            if (DirToPathMap.ContainsKey(Dir.First))
                AddFiles(DirToPathMap[Dir.First], Dir.First);
            if (DirToPathMap.ContainsKey(Dir.Second))
                AddFiles(DirToPathMap[Dir.Second], Dir.Second);
        }

        internal void AddFiles(string path, Dir dirNumber)
        {
            // adding files to model's folder
            string[] files = Directory.GetFiles(path);
            
            DirToPathMap[dirNumber] = path;

            Files[dirNumber].Clear();
            Files[dirNumber].AddRange(files.Select(file => Path.GetFileName(file)).ToArray());
        }

        /// <summary>
        /// Add new file to both synced folders
        /// </summary>
        internal bool Add(string param, out string errorMessage)
        {
            try
            {
                // check that files were not removed when sync was clicked
                Refresh();

                if (DirToPathMap.ContainsKey(Dir.First))
                    using (File.Create(Path.Combine(DirToPathMap[Dir.First], param))) { };
                if (DirToPathMap.ContainsKey(Dir.Second))
                    using (File.Create(Path.Combine(DirToPathMap[Dir.Second], param))) { };

                errorMessage = "";
                return true;
            }
            catch (Exception ex) 
            {
                errorMessage = ex.Message;
                return false;
            }
            finally
            {
                Refresh();
            }
        }

        /// <summary>
        /// Removes file from both folders.
        /// </summary>
        internal bool Remove(string param, out string errorMessage)
        {
            // check that files were not removed when sync was clicked
            Refresh();

            try
            {
                foreach (var item in FirstDirFiles)
                {
                    if (item.Equals(param, StringComparison.InvariantCultureIgnoreCase))
                    {
                        File.Delete(Path.Combine(DirToPathMap[Dir.First], item));
                    }
                }

                foreach (var item in SecondDirFiles)
                {
                    if (item.Equals(param, StringComparison.InvariantCultureIgnoreCase))
                    {
                        File.Delete(Path.Combine(DirToPathMap[Dir.Second], item));
                    }
                }

                errorMessage = "";
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
            finally 
            {
                Refresh();
            }
        }

        /// <summary>
        /// Syncs conents from both folders.
        /// </summary>
        internal bool Sync(out string errorMessage)
        {
            // check that files were not removed when sync was clicked
            Refresh();

            var filesForSecondFolder = FirstDirFiles.Except(SecondDirFiles).ToList();
            var filesForFirstFolder = SecondDirFiles.Except(FirstDirFiles).ToList();

            try 
            {
                if (filesForFirstFolder.Count == 0 && filesForSecondFolder.Count == 0)
                {
                    errorMessage = "Nothing to Sync...";
                    return false;
                }

                foreach(var item in filesForSecondFolder)
                {
                    File.Copy(Path.Combine(DirToPathMap[Dir.First], item), Path.Combine(DirToPathMap[Dir.Second], item), false);
                }

                foreach (var item in filesForFirstFolder)
                {
                    File.Copy(Path.Combine(DirToPathMap[Dir.Second], item), Path.Combine(DirToPathMap[Dir.First], item), false);
                }

                errorMessage = "";
                return true;
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
            finally
            {
                Refresh();
            }
        }

        /// <summary>
        /// Resets all contents in all model.
        /// </summary>
        internal bool Reset(out string errorMessage)
        {
            try
            {
                DirToPathMap[Dir.First] = "";
                DirToPathMap[Dir.Second] = "";
                Files[Dir.First].Clear();
                Files[Dir.Second].Clear();
                errorMessage = "";
                return true;
            }
            catch (Exception ex) 
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
