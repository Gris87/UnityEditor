using System.Collections.Generic;

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
			public int          locks;
			public List<string> files;



			/// <summary>
			/// Initializes a new instance of the <see cref="Net.RevisionsCache+RevisionData"/> class.
			/// </summary>
			/// <param name="filesList">List of files.</param>
			public RevisionData(List<string> filesList)
			{
				locks = 0;
				files = filesList;
			}
		}



		/// <summary>
		/// Gets the MD5HashesResponse messages.
		/// </summary>
		/// <value>The MD5HashesResponse messages.</value>
		public static List<byte[]> md5HashesResponseMessages
		{
			get
			{
				if (sMD5HashesResponseMessages == null)
				{
					sMD5HashesResponseMessages = Server.BuildMD5HashesResponseMessages();
				}

				List<byte[]> res = sMD5HashesResponseMessages;

				DebugEx.VeryVeryVerboseFormat("RevisionsMD5Cache.md5HashesMessages = {0}", res);

				return sMD5HashesResponseMessages;
			}
		}



		private static Dictionary<int, RevisionData> sRevisions;
		private static List<byte[]>                  sMD5HashesResponseMessages;
		private static List<string>                  sFiles;



		/// <summary>
		/// Initializes the <see cref="Net.RevisionsCache"/> class.
		/// </summary>
		static RevisionsCache()
		{
			DebugEx.Verbose("Static class RevisionsCache initialized");

			sRevisions                 = new Dictionary<int, RevisionData>();
			sMD5HashesResponseMessages = null;
			sFiles                     = null;
		}

		/// <summary>
		/// Handler for new revision event.
		/// </summary>
		public static void OnNewRevision()
		{
			DebugEx.Verbose("RevisionsCache.OnNewRevision()");

			sMD5HashesResponseMessages = null;
			sFiles                     = null;
		}

		/// <summary>
		/// Locks the revision.
		/// </summary>
		/// <returns>The latest revision.</returns>
		public static int LockRevision()
		{
			int res = RevisionChecker.revision;

			RevisionData revisionData;

			if (!sRevisions.TryGetValue(res, out revisionData))
			{
				// TODO: Need to lock folder
				// TODO: Need to get files

				revisionData = new RevisionData(sFiles);
				sRevisions.Add(res, revisionData);
			}

			++revisionData.locks;

			return res;
		}

		/// <summary>
		/// Unlocks the specified revision.
		/// </summary>
		/// <param name="revision">Revision.</param>
		public static void UnlockRevision(int revision)
		{
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
	}
}

