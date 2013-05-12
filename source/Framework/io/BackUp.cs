using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.IO.Packaging;

namespace Framework.io
{
    /// <summary>
    /// Class that provide the base mechanism for saving & zip the App's files.
    /// @ver 0.2
    /// </summary>
    public class BackUp
    {

        private const long BUFFER_SIZE = 4096;

        /// <summary>
        /// Path that represent the physical Zip file.
        /// </summary>
        string zipStore;

        /// <summary>
        /// Represents the logical and Zip container.
        /// </summary>
        Package zip;

        System.ComponentModel.BackgroundWorker bgWoker;

        System.ComponentModel.BackgroundWorker bgLoader;

        /// <summary>
        /// Raises with progress changes.
        /// </summary>
        public event EventHandler<System.ComponentModel.ProgressChangedEventArgs> BackUpProgressChanged;

        /// <summary>
        /// Raises after the task finished.
        /// </summary>
        public event EventHandler<System.ComponentModel.RunWorkerCompletedEventArgs> BackUpProgressFinished;

        public bool IsRunning
        {
            get
            {
                return
                    bgWoker.IsBusy || bgWoker.CancellationPending ||
                    bgLoader.IsBusy || bgLoader.CancellationPending;
            }
        }

        /// <summary>
        /// Creates a new instance of the BackUp class.
        /// </summary>
        /// <param name="path">string - destiny file.</param>
        public BackUp()
        {
            bgWoker = new System.ComponentModel.BackgroundWorker();
            bgWoker.WorkerSupportsCancellation = true;
            bgWoker.WorkerReportsProgress = true;
            bgWoker.DoWork += new System.ComponentModel.DoWorkEventHandler(BackUp_DoWork);
            bgWoker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(bgWoker_ProgressChanged);
            bgWoker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgWoker_RunWorkerCompleted);
            //
            bgLoader = new System.ComponentModel.BackgroundWorker();
            bgLoader.WorkerSupportsCancellation = true;
            bgLoader.WorkerReportsProgress = true;
            bgLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(bgLoader_DoWork);
            bgLoader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(bgWoker_ProgressChanged);
            bgLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgWoker_RunWorkerCompleted);

        }

        void BackUp_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                string[] files = io.Configuration.GetBackUpFiles();

                using (zip = System.IO.Packaging.Package.Open(zipStore, FileMode.Create))
                {

                    zip.PackageProperties.Creator = io.Configuration.ApplicationName;
                    zip.PackageProperties.Description = "AnimeKakkoi's BackUp file.";
                    zip.PackageProperties.Keywords = "anime, manga, stats, list";
                    zip.PackageProperties.Title = "AK - " + DateTime.Now.ToLocalTime();

                    int count = 0;
                    foreach (string s in files)
                    {
                        FileInfo file = new FileInfo(io.Configuration.ApplicationDataFolder + s);
                        SendFileToZip(file);
                        //
                        bgWoker.ReportProgress((int)Convert.ToSingle(++count * 100 / files.Length));
                    }

                }//end-using
            }
            catch { throw new IOException("error trying to manipulate the backup's files."); }

        }

        void bgLoader_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            using (zip = System.IO.Packaging.Package.Open(zipStore, FileMode.Open))
            {
                PackagePartCollection collection = zip.GetParts();
                int count = 0;

                foreach (PackagePart part in collection)
                {
                    FileInfo file = new FileInfo(io.Configuration.ApplicationDataFolder + part.Uri.OriginalString);
                    if (!file.Exists) continue; //some hidden and zip-own files

                    using (FileStream destFileStream = new FileStream(file.FullName, FileMode.Create, FileAccess.Write))
                    {
                        //set ready the source...
                        using (Stream src = part.GetStream())
                        {
                            CopyFromStream(destFileStream, src);
                        }
                    }
                    bgLoader.ReportProgress((int)Convert.ToSingle(++count * 100 / collection.Count()));
                }

            }//end-using
        }

        void bgWoker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (this.BackUpProgressChanged != null)
            {
                this.BackUpProgressChanged(sender, e);
            }
        }

        void bgWoker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (this.BackUpProgressFinished != null)
            {
                this.BackUpProgressFinished(sender, e);
            }
        }

        /// <summary>
        ///  Starts the BackUp process given the destiny file.
        /// </summary>
        /// <param name="argument">the object for using through the process.</param>
        public void AsyncMakeBackUp(string argument)
        {
            if (String.IsNullOrEmpty(argument)) throw new ArgumentNullException("the given argument is invalid.");
            zipStore = String.Format("{0}", argument);
            bgWoker.RunWorkerAsync();
        }

        public void AsyncLoadBackUp(string argument)
        {
            if (String.IsNullOrEmpty(argument)) throw new ArgumentNullException("the given argument is invalid.");
            zipStore = String.Format("{0}", argument);
            bgLoader.RunWorkerAsync();
        }

        public void CancelAsyncMaking()
        {
            bgWoker.CancelAsync();
        }

        public void CancelAsyncLoading()
        {
            bgLoader.CancelAsync();
        }

        private void SendFileToZip(FileInfo fileToZip)
        {
            //creates the logic file
            Uri uri = PackUriHelper.CreatePartUri(new Uri(fileToZip.Name, UriKind.Relative));
            //Check if file already exists
            if (zip.PartExists(uri))
            {
                zip.DeletePart(uri);
            }
            //Indicates the file into the zip
            PackagePart part = zip.CreatePart(uri, "", CompressionOption.Normal);
            //open the file to zip...
            using (FileStream fileStream = new FileStream(fileToZip.FullName, FileMode.Open, FileAccess.Read))
            {
                //set ready the destination...
                using (Stream dest = part.GetStream())
                {
                    CopyStream(fileStream, dest);
                }
            }
        }

        private static void CopyFromStream(System.IO.FileStream outputStream, System.IO.Stream inputStream)
        {
            long bufferSize = inputStream.Length < BUFFER_SIZE ? inputStream.Length : BUFFER_SIZE;
            byte[] buffer = new byte[bufferSize];
            int bytesRead = 0;
            long bytesWritten = 0;
            while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                outputStream.Write(buffer, 0, bytesRead);
                bytesWritten += bufferSize;
            }
        }

        private static void CopyStream(System.IO.FileStream inputStream, System.IO.Stream outputStream)
        {
            long bufferSize = inputStream.Length < BUFFER_SIZE ? inputStream.Length : BUFFER_SIZE;
            byte[] buffer = new byte[bufferSize];
            int bytesRead = 0;
            long bytesWritten = 0;
            while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                outputStream.Write(buffer, 0, bytesRead);
                bytesWritten += bufferSize;
            }
        }

    }
}
