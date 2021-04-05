using System;
using System.Collections.Generic;

namespace BackUP
{
    public class RemovePointCount : IRemovePoint
    {
        public int MaxLength;

        public RemovePointCount()
        {
            MaxLength = int.MaxValue;
        }
        public void SetRestrictionLength(int length)
        {
            MaxLength = length;
        }
        public bool CheckLengthRestriction(List<RestorePoint> RestorePoints)
        {
            var currBranchLength = RestorePoints.Count;
            return currBranchLength > MaxLength;
        }
        public int removePoints(BackUp backUp)
        {
            if (CheckLengthRestriction(backUp.restorePoints))
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