using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Packaging;
using Framework.io;

namespace Framework.util
{

    /// <summary>
    /// A file importer for loading media from file-based resources.
    /// </summary>
    public class FileManager : IImporter
    {

        public List<Object> Elements { get; set; }

        public entity.ENTITY_STATE ElementState { get; set; }

        private const String TEMP_FILE_EXTENSION = "akt";

        private const long BUFFER_SIZE = 4096;

        protected const String SEPARATOR_CHAR = "$";

        private List<Object> inLoadElements;

        /// <summary>
        /// Path that represent the physical Zip file.
        /// </summary>
        string zipStore;

        /// <summary>
        /// Represents the logical and Zip container.
        /// </summary>
        Package zip;


        public FileManager(String pathFile)
        {
            zipStore = pathFile;
        }

        private String GetCodify(string originalText)
        {
            return originalText;
        }

        public void Load()
        {
            try
            {
                using (zip = System.IO.Packaging.Package.Open(zipStore, FileMode.Open))
                {
                    PackagePartCollection collection = zip.GetParts();

                    foreach (PackagePart part in collection)
                    {
                        FileInfo file = new FileInfo(Path.GetTempPath() + part.Uri.OriginalString);
                        if (file.Extension != "." + TEMP_FILE_EXTENSION) continue; //some hidden and zip-own files, just explicits

                        using (FileStream destFileStream = new FileStream(file.FullName, FileMode.Create, FileAccess.Write))
                        {
                            //set ready the source...
                            using (Stream src = part.GetStream())
                            {
                                MainStream.CopyFromStream(destFileStream, src);
                            }
                        }

                        //the temp file contains the information.
                        StreamReader reader = file.OpenText();

                        while (reader.Peek() != -1)
                        {
                            string line = GetCodify(reader.ReadLine());

                            string[] parts = line.Split(new string[] { SEPARATOR_CHAR }, StringSplitOptions.RemoveEmptyEntries);
                            string entity = parts[1];
                            string text = parts[2];
                            string progress = parts[3];
                            Type type = Type.GetType(entity);
                            
                            //TODO: finish the convertion process.
                            //Framework.entity.Anime item = new entity.Anime();

                            //item.FromString(text);
                            //item.ProgressString = progress;

                            //inLoadElements.Add(item);

                        }

                        reader.Close();
                        reader.Dispose();

                        file.Delete();
                    }

                }//end-using
            }
            catch { throw new IOException("error trying to manipulate the AK's files."); }
        }

        /// <exception cref="NullReferenceException">NullReferenceException - If Elements is empty.</exception>
        /// <exception cref="IOException">IOException</exception>
        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            if (Elements == null)
                throw new NullReferenceException("Propertie 'Elements' is not loaded.");

            CheckForStateChange();

            try
            {

                using (zip = System.IO.Packaging.Package.Open(zipStore, FileMode.Create))
                {
                    zip.PackageProperties.Creator = io.Configuration.ApplicationName;
                    zip.PackageProperties.Description = io.Configuration.ApplicationName + "'s Sharing file.";
                    zip.PackageProperties.Keywords = "anime, manga, stats, list, entertainment";
                    zip.PackageProperties.Title = "AK - " + DateTime.Now.ToLocalTime();

                    StringBuilder buffer = new StringBuilder();
                    foreach (Object obj in Elements)
                    {
                        buffer.AppendLine(String.Format("!{0}{1}{0}{2}{0}{3}", SEPARATOR_CHAR, obj.GetType(), (obj as entity.EntitySource).ToString(), (obj as entity.EntitySource).ProgressString));
                    }

                    //the temp file contains the information.
                    FileInfo file = new FileInfo(Path.ChangeExtension(Path.GetTempFileName(), TEMP_FILE_EXTENSION));

                    StreamWriter writer = file.AppendText();
                    writer.WriteLine(SetCodify(buffer.ToString()));
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();

                    SendFileToZip(file);

                    file.Delete();

                }//end-using
            }
            catch { throw new IOException("error trying to manipulate the AK's files."); }
        }

        private void CheckForStateChange()
        {
            if (this.ElementState != null)
            {
                try
                {
                    foreach (entity.EntitySource item in this.Elements)
                        item.State = this.ElementState;

                }
                catch { }
            }
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
                    MainStream.CopyStream(fileStream, dest);
                }
            }
        }

        private String SetCodify(string originalText)
        {
            return originalText;
        }


    }
}
