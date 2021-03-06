﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GpfTools.GpfFile;

namespace GpfTools
{
    public static class GpfUtil
    {
        private static List<Tuple<String, Profile>> _profilesList;

        public static string FindGarminDeviceDirectory()
        {
            foreach (string s in Directory.GetLogicalDrives())
            {
                if (Directory.Exists(s+"Garmin"))
                {
                    var files = Directory.GetFiles(s + "Garmin", "GarminDevice.xml", SearchOption.TopDirectoryOnly);
                    if (files != null && files.Any())
                    {
                        return files.FirstOrDefault().Replace("GarminDevice.xml", "Profiles");
                    }
                }

            }
            return String.Empty;
        }


        public static void BackupDeviceToRepository()
        {

            foreach (var file in Directory.GetFiles(GetBackupDirectory(), "*.gpf"))
            {
                File.Delete(file);
                GitHelpers.GitBackup.Removefile(GetBackupDirectory(), Path.GetFileName(file));
            }
            foreach (var file in Directory.GetFiles(FindGarminDeviceDirectory(), "*.gpf"))
            {
                var fullPath = GetBackupDirectory() + "\\" + Path.GetFileName(file);
                File.Copy(file, fullPath, true);
                GitHelpers.GitBackup.Addfile(GetBackupDirectory(), fullPath);
            }
            GitHelpers.GitBackup.CommitChanges(GetBackupDirectory(), "Device Backup " + DateTime.Now);
        }

        public static string GetBackupDirectory()
        {
            var backupDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FenixBackup";
            if (!Directory.Exists(backupDir)) Directory.CreateDirectory(backupDir);
            return backupDir;
        }

        public static void SaveToDevice()
        {
            SaveToRepository("Pushed to device");

            foreach (var file in Directory.GetFiles(FindGarminDeviceDirectory(), "*.gpf"))
            {
                File.Delete(file);
            }
                foreach (var file in Directory.GetFiles(GetBackupDirectory(), "*.gpf"))
                {
                    File.Copy(file, FindGarminDeviceDirectory() + "\\" + Path.GetFileName(file), true);
                }
                
        }

        public static void SaveToRepository(string message = "Saved")
        {
            if (_profilesList != null)
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", ""); 
                XmlSerializer serializer = new XmlSerializer(typeof(Profile),new XmlAttributeOverrides() { });
                foreach (var tuple in _profilesList)
                {
                    using(TextWriter writer = new StreamWriter(tuple.Item1))
                    {
                        serializer.Serialize(writer, tuple.Item2, ns);
                    }
                }
                GitHelpers.GitBackup.CommitChanges(GetBackupDirectory(), message + " " + DateTime.Now);
            }
        }

        public static List<Tuple<String,Profile>> ProfilesList()
        {
            if(_profilesList== null)
            {
                var dir = GetBackupDirectory();
                _profilesList = new List<Tuple<String, Profile>>();
                if (!string.IsNullOrEmpty(dir))
                {
                    var files = Directory.GetFiles(dir, "*.gpf", SearchOption.TopDirectoryOnly);
                    XmlSerializer serializer = new XmlSerializer(typeof(Profile));

                    foreach (var file in files)
                    {
                        using(var fileStream = new FileStream(file, FileMode.Open))
                        {
                            _profilesList.Add(new Tuple<string, Profile>(fileStream.Name,
                                                                         serializer.Deserialize(fileStream) as Profile));
                        }
                    }

                }
            }
            return _profilesList;
        }

        public static void AddNewProfile(string baseOn, string name = "NewProfile")
        {
            var file = GetBackupDirectory() + "\\" + name + ".gpf";
            File.Copy(GetBackupDirectory() + "\\" + baseOn +".gpf",file );
            XmlSerializer serializer = new XmlSerializer(typeof(Profile));
            using (var fileStream = new FileStream(GetBackupDirectory() + "\\" + name + ".gpf", FileMode.Open))
            {
                _profilesList.Add(new Tuple<string, Profile>(fileStream.Name,
                                                             serializer.Deserialize(fileStream) as Profile));
            }
            GitHelpers.GitBackup.Addfile(GetBackupDirectory(),file);
            GitHelpers.GitBackup.CommitChanges(GetBackupDirectory(),"Added " + file);
        }

        public static void DeleteProfile(string name)
        {
            var profile = _profilesList.Find(s => s.Item1.Contains(name));
            File.Delete(profile.Item1);
            _profilesList.Remove(profile);
            GitHelpers.GitBackup.Removefile(GetBackupDirectory(),profile.Item1);
            GitHelpers.GitBackup.CommitChanges(GetBackupDirectory(), "Removed " + profile.Item1);
        }
    }
}
