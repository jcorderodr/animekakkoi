﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;

namespace AnimeKakkoi.Core.IO
{
    public class FileManager
    {

        /// <summary>
        /// Deletes the Application's principal folder.
        /// </summary>
        internal static void CleanApplicationData()
        {
            var ifolder = FileSystem.Current.LocalStorage.GetFolderAsync(IO.AkConfiguration.ApplicationDataFolder);
            ifolder.Result.DeleteAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        /// <returns>true if all files exists, otherwise, false.</returns>
        public static bool FileExists(params string[] files)
        {
            return files.All(f =>
                FileSystem.Current.LocalStorage.CheckExistsAsync(f).Result == ExistenceCheckResult.FileExists);
        }

        /// <summary>
        /// Verify for a folder if exists. Create it if doesn't.
        /// </summary>
        /// <param name="path">Name of the folder</param>
        /// <returns>A string containing the full path.</returns>
        public static String GetFolder(String path)
        {
            var ifolder = FileSystem.Current.LocalStorage.GetFolderAsync(path);
            if (ifolder.Result != null) return ifolder.Result.Path;

            var folder = FileSystem.Current.LocalStorage.CreateFolderAsync(path, CreationCollisionOption.OpenIfExists);
            return folder.Result.Path;
        }

        public static String GetPathSeparatorChar()
        {
            return PortablePath.DirectorySeparatorChar.ToString();
        }

        /// <summary>
        /// Open a file and retrieve all of his content.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>The file's content.</returns>
        internal static Task<string> OpenStream(String fileName)
        {
            var file = FileSystem.Current.GetFileFromPathAsync(fileName);

            if (file != null)
            {
                return file.Result.ReadAllTextAsync();
            }

            return null;
        }

        /// <summary>
        /// Open a file and retrieve all of his content, otherwise, creates a new one.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>The file's content.</returns>
        internal static Task<string> OpenOrCreateStream(String fileName)
        {
            var file = FileSystem.Current.GetFileFromPathAsync(fileName);

            if (file.Result == null)
               file = FileSystem.Current.LocalStorage.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

            if (file.Result != null)
            {
                return file.Result.ReadAllTextAsync();
            }

            return null;
        }


        internal static void SaveStream(string filename, string content)
        {
            var file = FileSystem.Current.GetFileFromPathAsync(filename);

            if (file.Result == null)
                file = FileSystem.Current.LocalStorage.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);

            if (file.Result != null)
            {
                file.Result.WriteAllTextAsync(content);
            }
        }

    }
}
