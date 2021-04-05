using System;
using System.Collections.Generic;

namespace BackUP
{
    public class RemovePointTime : IRemovePoint
    {
        public DateTime LastDateTime;
        public RemovePointTime()
        {
            LastDateTime = DateTime.MaxValue;
        }
        public void SetRestrictionTime(DateTime dateTime)
        {
            LastDateTime = dateTime;
        }
        public bool CheckDateRestriction(List<RestorePoint> RestorePoints, BackUp backUp)
        {
            var currBranchDate = RestorePoints[backUp.restorePoints.Count - 1];
            return currBranchDate.Date > LastDateTime;
        }
        public int removePoints(BackUp backUp)
        {
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