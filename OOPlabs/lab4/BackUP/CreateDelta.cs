namespace BackUP
{
    public class CreateDelta : ICreatePoint
    {
        public void CreatePoint(BackUp backUp)
        {
            backUp.CheckForDeltaFiles();
            var tmpRestorePoint = new RestorePoint(backUp.files, false);
            var deltaSize = tmpRestorePoint.pointSize - backUp.restorePoints[^1].pointSize;
            var deltaRestorePoint = new RestorePoint(backUp.deltafiles, true);
            backUp.backUpSize = tmpRestorePoint.pointSize;
            backUp.backUpSize += deltaSize;
            backUp.restorePoints.Add(deltaRestorePoint);
        }
    }
}