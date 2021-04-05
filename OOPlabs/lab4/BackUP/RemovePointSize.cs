using System.Collections.Generic;

namespace BackUP
{
    public class RemovePointSize : IRemovePoint
    {
        public long MaxSize;
        public RemovePointSize()
        {
            MaxSize = long.MaxValue;
        }
        public void SetRestrictionSize(long maxSize)
        {
            MaxSize = maxSize;
        }
        public bool CheckSizeRestriction(List<RestorePoint> RestorePoints, BackUp backUp)
        {
            var currBranchSize = backUp.BackUpSize;
            return currBranchSize > MaxSize;
        }
        public int removePoints(BackUp backUp)
        {
            if (CheckSizeRestriction(backUp.restorePoints, backUp))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}