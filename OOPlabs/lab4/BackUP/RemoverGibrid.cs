using System;
using System.Collections.Generic;

namespace BackUP
{
    public class RemoverRestriction : IRemoveGibrig
    {
        List<IRemovePoint> Restrictions;
        private bool MinPoints = true;
        private bool MaxPoints = false;

        RemoverRestriction()
        {
            Restrictions = new List<IRemovePoint>();
        }

        void addRestriction(BackUp backUp, IRemovePoint restriction)
        {
            Restrictions.Add(restriction);
            RemovePoint(backUp);
        }

        void removeRestriction(BackUp backUp, IRemovePoint restriction)
        {
            Restrictions.Remove(restriction);
        }

        void setRestrictionsMax()
        {
            MaxPoints = true;
            MinPoints = false;
        }
        public void RemovePoint(BackUp backUp)
        {
            if (Restrictions.Count != 0)
            {
                int pointsToBeRemoved = 0;
                if (MinPoints)
                {
                    pointsToBeRemoved = int.MaxValue;
                    for (int i = 0; i < Restrictions.Count; i++)
                    {
                        pointsToBeRemoved = Math.Min(pointsToBeRemoved, Restrictions[i].removePoints(backUp));
                    }
                }
                else
                {
                    pointsToBeRemoved = int.MaxValue;
                    for (int i = 0; i < Restrictions.Count; i++)
                    {
                        pointsToBeRemoved = Math.Max(pointsToBeRemoved, Restrictions[i].removePoints(backUp));
                    }
                }

                backUp.RestorePoints[^1].pointSize -= pointsToBeRemoved;
                backUp.RestorePoints[^1].pointSizeDelta -= pointsToBeRemoved;
                for (int i = 0; i < pointsToBeRemoved; i++)
                {

                    backUp.restorePoints.RemoveAt(0);
                }
            }

        }
    }
}