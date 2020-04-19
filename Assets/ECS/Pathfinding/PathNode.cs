namespace Common.ECS.Pathfinding
{
    public struct PathNode
    {
        public int index;
        public int x;
        public int y;

        public int gCost;
        public int hCost;
        public int fCost;

        public bool isWalkable;

        public int targetIndex;

        public void CalculateFCost()
        {
            fCost = gCost + hCost;
        }
    }
}