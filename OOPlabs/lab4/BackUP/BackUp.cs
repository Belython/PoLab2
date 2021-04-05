using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading;

namespace BackUP
{
    public class BackUp
    {
        public int MaxLength;
        public long MaxSize;
        public DateTime LastDateTime;
        public bool AllRestrictionsNeeded;

        public static int NEXT_ID = 0;
        public int id;
        public DateTime CreationTime;

        private string backupDirectory;

        public List<RestorePoint> restorePoints;
        public List<FileInfo> files;
        public List<FileInfo> deltafiles;

        public long backUpSize;

        private bool[] array;


        private int localPointId;

        public BackUp()
        {
            id = NEXT_ID;
            NEXT_ID++;
            CreationTime = DateTime.Now;

            LastDateTime = DateTime.MaxValue;
            MaxLength = int.MaxValue;
            MaxSize = long.MaxValue;
            AllRestrictionsNeeded = false;

            backUpSize = 0;
            files = new List<FileInfo>();
            restorePoints = new List<RestorePoint>();
            array = new bool[3];
        }

        public long BackUpSize
        {
            get { return backUpSize; }
        }

        public List<RestorePoint> RestorePoints
        {
            get { return restorePoints; }
        }

        public void SetRestrictionsType(bool isEvery)
        {
            AllRestrictionsNeeded = isEvery;
        }

        public void CheckAllRestrictions()
        {
            long currBranchSize = backUpSize;
            int currBranchLength = restorePoints.Count;
            DateTime currDateTime = LastDateTime;
            if (AllRestrictionsNeeded)
            {
                bool result = array[0] || array[1] || array[2];
                if (array[0] == true)
                {
                    result = (result && CheckLengthRestriction());
                }
                if (array[1] == true)
                {
                    result = (result && CheckSizeRestriction());
                }
                if (array[2] == true)
                {
                    result = (result && CheckDateRestriction());
                    if (result == true)
                    {
                        restorePoints.RemoveAt(RestorePoints.Count - 1);
                        recalculateSize();
                    }
                }
                else if (result == true)
                {
                    restorePoints.RemoveAt(0);
                    recalculateSize();
                }
            }
            else
            {
                if (CheckSizeRestriction())
                {
                    restorePoints.RemoveAt(0);
                    recalculateSize();
                    return;
                }

                if (CheckLengthRestriction())
                {
                    restorePoints.RemoveAt(0);
                    recalculateSize();
                    return;
                }

                if (CheckDateRestriction())
                {
                    restorePoints.RemoveAt(RestorePoints.Count - 1);
                    recalculateSize();
                    return;
                }
            }
        }

        private void recalculateSize()
        {
            long currSize = 0;
            foreach(RestorePoint restorePoint in restorePoints)
            {
                currSize += restorePoint.PointSize;
            }
            backUpSize = currSize;
        }

        public void AddFileToBackUp(FileInfo file)
        {
            files.Add(file);
            recalculateSize();
        }

        public void RemoveFileFromBackUp(FileInfo file)
        {
            files.Remove(file);
            recalculateSize();
        }

        public void CreateRestorePoint(bool IsDelta)
        {
            RestorePoint point = new RestorePoint(files, IsDelta);
            restorePoints.Add(point);
            recalculateSize();
            CheckAllRestrictions();
            CheckForDeltaFiles();
        }

        public void CheckForDeltaFiles()
        {
           for(int i = 0; i < restorePoints.Count - 1; i++)
           {
                RestorePoint point = restorePoints[i];
                foreach (FileInfo info in point.files)
                {
                    foreach (FileInfo futureInfo in restorePoints[i + 1].GetFiles())
                        if (info.Name.Equals(futureInfo.Name) && info.LastWriteTimeUtc != futureInfo.LastWriteTimeUtc)
                        {
                            restorePoints[i + 1].deltaFiles.Add(futureInfo);
                        }
                    foreach (FileInfo inf in files)
                    {
                        if (!point.files.Contains(inf))
                            restorePoints[i + 1].deltaFiles.Add(inf);
                    }
                    restorePoints[i + 1].recalculatedPointSize();
                }
           }
        }
    }
}
