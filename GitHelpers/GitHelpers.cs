using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitSharp;

namespace GitHelpers
{
    public class GitBackup
    {
        public static void BackupFilesToRepository(string srcDir, string destDir,string commitMessage = "Backup",string mask = "*")
        {

            if(Directory.Exists(srcDir)&&Directory.Exists(destDir))
            {
                Git.Init(destDir);
                var repository = new Repository(destDir);
                foreach (var file in Directory.GetFiles(srcDir, mask))
                {
                    File.Copy(file,destDir + Path.GetFileName(file),true);
                    repository.Index.Add(destDir +"/"+ Path.GetFileName(file));
                }
                
                repository.Commit(commitMessage + " " + DateTime.Now);
            }
        }

        public static void Removefile(string dir,string file)
        {
            var repository = new Repository(dir);
            repository.Index.Remove(file);
            repository.Index.CommitChanges("Deleted " + file, Author.Anonymous);
        }

        public static void Addfile(string dir, string file)
        {
            var repository = new Repository(dir);
            repository.Index.Add(file);
            repository.Index.CommitChanges("Added " + file, Author.Anonymous);
        }

        public static void CommitChanges(string dir,string comment)
        {
            var repository = new Repository(dir);
            repository.Index.Add(Directory.GetFiles(dir, "*.gpf"));
            //repository.Index.CommitChanges(comment, Author.Anonymous);
        }
    }
}
