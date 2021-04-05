using System.Collections.Generic;

namespace BackUP
{
    public class CreatePoint : ICreatePoint
    {
        private List<RestorePoint> restorePoints;
        public void CreatePoint(BackUp backUp)
        {
            var restorePoint = new RestorePoint(backUp.files);
            backUp.deltafiles.Clear();
            backUp.CheckForDeltaFiles();
            backUp.backUpSize += restorePoint.pointSize;
            backUp.restorePoints.Add(restorePoint);
        }
    }
}