using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

using Common;



namespace Net
{
    /// <summary>
    /// Revision checker.
    /// </summary>
    public static class RevisionChecker
    {
        private const float CHECK_DURATION = 5000f / 1000f;



        /// <summary>
        /// Gets the revision.
        /// </summary>
        /// <value>Revision number.</value>
        public static int revision
        {
            get
            {
                int res = sRevision;

                DebugEx.VeryVeryVerboseFormat("RevisionChecker.revision = {0}", res);

                return res;
            }
        }



        private static Timer  sTimer;
        private static string sAppDir;
        private static int    sRevision;



        /// <summary>
        /// Initializes the <see cref="Net.RevisionChecker"/> class.
        /// </summary>
        static RevisionChecker()
        {
            DebugEx.Verbose("Static class RevisionChecker initialized");

            sTimer = new Timer(OnTimeout, CHECK_DURATION);
            sTimer.Start();

            sAppDir   = Application.persistentDataPath;
            sRevision = -1;

            OnTimeout();
        }

        /// <summary>
        /// Update is called once per frame.
        /// </summary>
        public static void Update()
        {
            DebugEx.VeryVeryVerbose("RevisionChecker.Update()");

            sTimer.Update();
        }

        /// <summary>
        /// Handler for timeout event.
        /// </summary>
        private static void OnTimeout()
        {
            DebugEx.VeryVeryVerbose("RevisionChecker.OnTimeout()");

            sTimer.Start();

            RestoreFileStructure();

            if (sRevision < 0)
            {
				// TODO: Need to unlock all folders

                SetToTheLatestRevision();
            }

            CheckForNewRevision();
        }

        /// <summary>
        /// Restores the file structure.
        /// </summary>
        private static void RestoreFileStructure()
        {
            DebugEx.VeryVeryVerbose("RevisionChecker.RestoreFileStructure()");

            if (!Directory.Exists(sAppDir + "/Revisions"))
            {
                Directory.CreateDirectory(sAppDir + "/Revisions");
            }

            if (!Directory.Exists(sAppDir + "/Revisions/NewRevision"))
            {
                CreateNewRevisionFolder();
            }

            if (!File.Exists(sAppDir + "/Revisions/Readme.txt"))
            {
                File.WriteAllText(
                                  sAppDir + "/Revisions/Readme.txt",
                                  "If you want to commit new revision, please put files in NewRevision folder and then remove Lock file\n",
                                  Encoding.UTF8
                                 );
            }
        }

        /// <summary>
        /// Creates NewRevision folder.
        /// </summary>
        private static void CreateNewRevisionFolder()
        {
            DebugEx.Verbose("RevisionChecker.CreateNewRevisionFolder()");

            Directory.CreateDirectory(sAppDir + "/Revisions/NewRevision");
            File.WriteAllText(sAppDir + "/Revisions/NewRevision/Lock", "", Encoding.UTF8);
        }

        /// <summary>
        /// Sets to the latest revision.
        /// </summary>
        private static void SetToTheLatestRevision()
        {
            DebugEx.Verbose("RevisionChecker.SetToTheLatestRevision()");

            sRevision = 0;

            char[] pathDelimeters = new char[2];
            pathDelimeters[0]     = '/';
            pathDelimeters[1]     = '\\';

            string[] revisions = Directory.GetDirectories(sAppDir + "/Revisions");

            for (int i = 0; i < revisions.Length; ++i)
            {
                string revision = revisions[i];

                int index = revision.LastIndexOfAny(pathDelimeters);

                if (index >= 0)
                {
                    revision = revision.Substring(index + 1);
                }

                int revisionNumber;

                if (int.TryParse(revision, out revisionNumber))
                {
                    if (revisionNumber > sRevision)
                    {
                        sRevision = revisionNumber;
                    }
                }
            }

            DebugEx.DebugFormat("Latest revision: {0}", sRevision);
        }

        /// <summary>
        /// Checks for new revision.
        /// </summary>
        private static void CheckForNewRevision()
        {
            DebugEx.VeryVeryVerbose("RevisionChecker.CheckForNewRevision()");

            if (!File.Exists(sAppDir + "/Revisions/NewRevision/Lock"))
            {
                CalculateMD5InFolder(sAppDir + "/Revisions/NewRevision");

                ++sRevision;
                Directory.Move(sAppDir + "/Revisions/NewRevision", sAppDir + "/Revisions/" + sRevision.ToString());

                CreateNewRevisionFolder();

				RevisionsCache.OnNewRevision();

                DebugEx.DebugFormat("New revision: {0}", sRevision);
            }
        }

        /// <summary>
        /// Calculates MD5 hash of each file in folder.
        /// </summary>
        /// <param name="path">Path to folder.</param>
        private static void CalculateMD5InFolder(string path)
        {
            DebugEx.VeryVerboseFormat("RevisionChecker.CalculateMD5InFolder(path = {0})", path);

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                if (!File.Exists(file + ".md5") && !file.EndsWith(".md5"))
                {
                    CalculateMD5ForFile(file);
                }
            }

            string[] folders = Directory.GetDirectories(path);

            foreach (string folder in folders)
            {
                CalculateMD5InFolder(folder);
            }
        }

        /// <summary>
        /// Calculates MD5 hash for specified file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        public static void CalculateMD5ForFile(string path)
        {
            DebugEx.VeryVerboseFormat("RevisionChecker.CalculateMD5ForFile(path = {0})", path);

            MD5 md5 = MD5.Create();

            FileStream stream = File.OpenRead(path);
            byte[]     hash   = md5.ComputeHash(stream);
            stream.Close();

            File.WriteAllText(path + ".md5", Utils.BytesInHex(hash), Encoding.UTF8);
        }
    }
}
