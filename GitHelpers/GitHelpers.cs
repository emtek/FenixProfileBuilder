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
        private static Repository _repository ;

        public static void EnsureRepository(string dir)
        {
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            Git.Init(dir);
            _repository = new Repository(dir);
        }

        public static void RevertToChangeset(string dir,string commithash)
        {
            EnsureRepository(dir);
            _repository.Head.Reset(commithash, ResetBehavior.Hard);
        }

        public static List<Tuple<string,string>> GetChangeSets(string dir)
        {
            EnsureRepository(dir);
            var repo = new Repository(dir);
            var commits = repo.Head.CurrentCommit.Ancestors;
            return commits.Select(s => new Tuple<string, string>(s.Hash, s.Message)).ToList();
        }

        public static void Removefile(string dir,string file)
        {
            EnsureRepository(dir);
            var repository = new Repository(dir);
            repository.Index.Remove(file);
        }

        public static void Addfile(string dir, string file)
        {
            EnsureRepository(dir);
            var repository = new Repository(dir);
            repository.Index.Add(file);
            
        }

        public static void CommitChanges(string dir,string comment)
        {
            EnsureRepository(dir);
            if (_repository.Index.Status.AnyDifferences)
            {
                _repository.Index.Entries.ToList().ForEach(e => _repository.Index.Add(e));
                _repository.Commit(comment, Author.Anonymous);
            }

        }
    }
}
