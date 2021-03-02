namespace CommonECS.Pathfinding
{
	public struct PathNode
	{
		public int x;
		public int y;

		public int currIndex;
		public int prevIndex;

		public int traverseCost;
		public int cumulativeCost; // G cost
		public int distanceCost; // H cost
		public int totalCost; // F cost

		public bool isWalkable;
	}
}
