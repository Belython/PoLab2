using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackUP
{
    public class RestorePoint
    {
        public static int NEXT_ID = 0;
        public int id;

        public DateTime Date;

        public List<FileInfo> files;
        public List<FileInfo> deltaFiles;
        public long pointSize;
        public long pointSizeDelta;

        public bool deltaPoint;

        public RestorePoint()
        {
            id = NEXT_ID;
            NEXT_ID++;
            files = new List<FileInfo>();
            deltaFiles = new List<FileInfo>();
            pointSize = 0;
        }
        public RestorePoint(bool deltapoint)
        {
            id = NEXT_ID;
            NEXT_ID++;

            deltaPoint = deltapoint;
            files = new List<FileInfo>();
            deltaFiles = new List<FileInfo>();
            pointSize = 0;
            pointSizeDelta = 0;
        }
        public RestorePoint(List<FileInfo> files, bool deltapoint)
        {
            id = NEXT_ID;
            NEXT_ID++;

            this.files = files.ToList();
            deltaPoint = deltapoint;
            deltaFiles = new List<FileInfo>();
            Date = DateTime.Now;
            recalculatedPointSize();
        }

        public RestorePoint(List<FileInfo> files)
        {
            id = NEXT_ID;
            NEXT_ID++;

            this.files = files;
            deltaFiles = new List<FileInfo>();
            Date = DateTime.Now;
            recalculatedPointSize();
        }

        public long PointSize
        {
            get { return pointSize; }
        }

        public void recalculatedPointSize()
        {
            long size = 0;
            if(!deltaPoint)
            foreach(FileInfo info in files)
            {
                size += info.Length;
            }
            else
            {
                foreach (FileInfo info in deltaFiles)
                {
                    size += info.Length;
                }
            }
            pointSize = size;
        }

        public List<FileInfo> GetFiles()
        {
            return deltaPoint ? deltaFiles : files;
        }

    }
}
