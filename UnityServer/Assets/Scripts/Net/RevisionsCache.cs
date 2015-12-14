using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using UnityEngine;

using Common;



namespace Net
{
	/// <summary>
	/// Cache for revisions.
	/// </summary>
	public static class RevisionsCache
	{
		/// <summary>
		/// Revision data.
		/// </summary>
		private class RevisionData
		{
			public int locks;



			/// <summary>
			/// Initializes a new instance of the <see cref="Net.RevisionsCache+RevisionData"/> class.
			/// </summary>
			public RevisionData()
			{
				locks = 0;
			}
		}



		/// <summary>
		/// Gets the files.
		/// </summary>
		/// <value>The files.</value>
		public static ReadOnlyCollection<string> files
		{
			get
			{
				ReadOnlyCollection<string> res = sFiles;

				DebugEx.VeryVeryVerboseFormat("RevisionsCache.files = {0}", res);

				return res;
			}
		}



		private static Dictionary<int, RevisionData> sRevisions;
		private static ReadOnlyCollection<string>    sFiles;
		private static List<byte[]>                  sMD5HashesResponseMessages;



		/// <summary>
		/// Initializes the <see cref="Net.RevisionsCache"/> class.
		/// </summary>
		static RevisionsCache()
		{
			DebugEx.Verbose("Static class RevisionsCache initialized");

			sRevisions                 = new Dictionary<int, RevisionData>();
			sFiles                     = null;
			sMD5HashesResponseMessages = null;
		}

		/// <summary>
		/// Handler for new revision event.
		/// </summary>
		public static void OnNewRevision()
		{
			DebugEx.Verbose("RevisionsCache.OnNewRevision()");

			sFiles                     = null;
			sMD5HashesResponseMessages = null;
		}

		/// <summary>
		/// Locks the revision.
		/// </summary>
		/// <returns>The latest revision.</returns>
		public static int LockRevision(out ReadOnlyCollection<string> files, out List<byte[]> md5HashesResponseMessages)
		{
			int res = RevisionChecker.revision;

			if (sFiles == null)
			{
				List<string> tempList = new List<string>();

				string revisionDir = Application.persistentDataPath + "/Revisions/" + res.ToString();
				BuildFilesList(revisionDir, revisionDir.Length + 1, ref tempList);

				sFiles = tempList.AsReadOnly();
			}

			if (sMD5HashesResponseMessages == null)
			{
				sMD5HashesResponseMessages = Server.BuildMD5HashesResponseMessages();
			}

			RevisionData revisionData;

			if (!sRevisions.TryGetValue(res, out revisionData))
			{
				// TODO: Need to lock folder

				revisionData = new RevisionData();
				sRevisions.Add(res, revisionData);
			}

			++revisionData.locks;

			files                     = sFiles;
			md5HashesResponseMessages = sMD5HashesResponseMessages;

			DebugEx.VerboseFormat("RevisionsCache.LockRevision() = {0}", res);

			return res;
		}

		/// <summary>
		/// Unlocks the specified revision.
		/// </summary>
		/// <param name="revision">Revision.</param>
		public static void UnlockRevision(int revision)
		{
			DebugEx.VerboseFormat("RevisionsCache.UnlockRevision(revision = {0})", revision);

			RevisionData revisionData;
			
			if (sRevisions.TryGetValue(revision, out revisionData))
			{
				--revisionData.locks;

				if (revisionData.locks <= 0)
				{
					// TODO: Need to unlock folder

					sRevisions.Remove(revision);
				}
			}
			else
			{
				DebugEx.FatalFormat("Data not found for revision {0}", revision);
			}
		}

		/// <summary>
		/// Builds the files list.
		/// </summary>
		/// <param name="path">Path.</param>
		/// <param name="leftTrim">Amount of charachers to be trimmed at the left.</param>
		/// <param name="filesList">Files list.</param>
		private static void BuildFilesList(string path, int leftTrim, ref List<string> filesList)
		{
			DebugEx.VeryVerboseFormat("RevisionsCache.BuildFilesList(path = {0}, leftTrim = {1}, filesList = {2})", path, leftTrim, filesList);

			string[] folders = Directory.GetDirectories(path);
			
			foreach (string folder in folders)
			{
				filesList.Add(folder.Substring(leftTrim));

				BuildFilesList(folder, leftTrim, ref filesList);
			}

			string[] files = Directory.GetFiles(path);
			
			foreach (string file in files)
			{
				if (!file.EndsWith(".md5"))
				{
					filesList.Add(file.Substring(leftTrim));
				}
			}
		}
	}
}

