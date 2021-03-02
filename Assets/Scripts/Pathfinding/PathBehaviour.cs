using CommonECS.Mathematics;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace CommonECS.Pathfinding
{
	public class PathBehaviour : MonoBehaviour
	{
		[BurstCompile]
		private struct FindPathJob : IJob
		{
			private const int TRAVERSE_COST = 10;
			private const int DISTANCE_COST = 10;
			private const int DIAGONAL_COST = 14;

			public int2 startPosition;
			public int2 targetPosition;

			public NativeArray<bool> grid;
			public int gridWidth;
			public int gridHeight;

			public void Execute()
			{
				var gridrange = new intrange2(0, 0, gridWidth - 1, gridHeight - 1);
				var pathArray = new NativeArray<PathNode>(gridWidth * gridHeight, Allocator.Temp);

				for (int y = 0; y < gridHeight; y++)
				{
					for (int x = 0; x < gridWidth; x++)
					{
						var index = x + y * gridWidth;

						var pathNode = new PathNode();
						pathNode.x = x;
						pathNode.y = y;
						pathNode.currIndex = index;
						pathNode.prevIndex = -1;
						pathNode.cumulativeCost = int.MaxValue;
						pathNode.isWalkable = grid[index];

						pathArray[index] = pathNode;
					}
				}

				var targetIndex = targetPosition.x + targetPosition.y * gridWidth;
				var targetNode = pathArray[targetIndex];

				var startIndex = startPosition.x + startPosition.y * gridWidth;
				var startNode = pathArray[startIndex];
				startNode.cumulativeCost = 0;
				pathArray[startIndex] = startNode;

				var remainingList = new NativeList<int>(Allocator.Temp);
				var checkedArray = new NativeArray<bool>(gridWidth * gridHeight, Allocator.Temp);

				var directionsArray = new NativeArray<int2>(8, Allocator.Temp);
				directionsArray[0] = new int2(-1, 0);
				directionsArray[1] = new int2(+1, 0);
				directionsArray[2] = new int2(0, +1);
				directionsArray[3] = new int2(0, -1);
				directionsArray[4] = new int2(-1, -1);
				directionsArray[5] = new int2(-1, +1);
				directionsArray[6] = new int2(+1, +1);
				directionsArray[7] = new int2(+1, -1);

				remainingList.Add(startIndex);
				while (remainingList.Length > 0)
				{
					int currentNodeIndex = GetLowestTotalCostNodeIndex(remainingList, pathArray);

					if (currentNodeIndex == targetIndex)
						break;
					
					if (remainingList.TryIndexOf(currentNodeIndex, out int index))
						remainingList.RemoveAtSwapBack(index);
					
					checkedArray[currentNodeIndex] = true;

					var currentNode = pathArray[currentNodeIndex];

					for (int i = 0; i < directionsArray.Length; ++i)
					{
						var direction = directionsArray[i];

						var neighbourX = currentNode.x + direction.x;
						var neighbourY = currentNode.y + direction.y;

						if (!gridrange.Contains(neighbourX, neighbourY))
							continue;

						int neighbourNodeIndex = neighbourX + neighbourY * gridWidth;
						if (checkedArray[neighbourNodeIndex])
							continue;

						var neighbourNode = pathArray[neighbourNodeIndex];
						if (!neighbourNode.isWalkable)
							continue;
						
						int totalCumulativeCost = currentNode.cumulativeCost + GetDistanceCost(currentNode, neighbourNode) + neighbourNode.traverseCost;
						if (totalCumulativeCost < neighbourNode.cumulativeCost)
						{
							neighbourNode.prevIndex = currentNodeIndex;
							neighbourNode.cumulativeCost = totalCumulativeCost;
							neighbourNode.distanceCost = GetDistanceCost(neighbourNode, targetNode);
							neighbourNode.totalCost = neighbourNode.cumulativeCost + neighbourNode.distanceCost;

							pathArray[neighbourNodeIndex] = neighbourNode;

							if (!remainingList.Contains(neighbourNodeIndex))
								remainingList.Add(neighbourNodeIndex);
						}
					}
				}

				var result = new NativeList<int2>(Allocator.Temp);

				var node = pathArray[targetIndex];
				while (node.prevIndex != -1)
				{
					var prev = pathArray[node.prevIndex];

					if (result.Length > 1)
					{
						var last = result[result.Length - 1];
						if (
							math.sign(node.x - last.x) != math.sign(prev.x - node.x) ||
							math.sign(node.y - last.y) != math.sign(prev.y - node.y)
						)
						{
							result.Add(new int2(node.x, node.y));
						}
					}
					else
					{
						result.Add(new int2(node.x, node.y));
					}

					node = prev;
				}
				if (result.Length > 1)
				{
					result.Add(new int2(node.x, node.y));
				}
				result.Dispose(); // Better something else next time...
				
				pathArray.Dispose();
				remainingList.Dispose();
				checkedArray.Dispose();
				directionsArray.Dispose();
			}

			private static int GetDistanceCost(PathNode a, PathNode b)
			{
				int dx = Mathf.Abs(b.x - a.x);
				int dy = Mathf.Abs(b.y - a.y);
				if (dx > dy)
					return DIAGONAL_COST * dy + DISTANCE_COST * (dx - dy);
				return DIAGONAL_COST * dx + DISTANCE_COST * (dy - dx);
			}

			private int GetLowestTotalCostNodeIndex(NativeList<int> openList, NativeArray<PathNode> pathArray)
			{
				var result = openList[0];
				var nodeA = pathArray[result];

				for (int i = 1; i < openList.Length; ++i)
				{
					var current = openList[i];
					var nodeB = pathArray[current];
					
					if (nodeA.totalCost > nodeB.totalCost)
					{
						result = current;
						nodeA = nodeB;
					}
				}

				return result;
			}
		}
	}
}
