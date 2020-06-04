using CommonECS.Mathematics;
using System;
using System.Collections;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace CommonECS.Pathfinding
{
	public class PathBehaviour : MonoBehaviour
	{
		private void Start()
		{
			StartCoroutine(InvokeRepeating(() => {
				float startTime = Time.realtimeSinceStartup;

				int findPathJobCount = 5;
				var jobHandles = new NativeArray<JobHandle>(findPathJobCount, Allocator.Temp);
				for (int i = 0; i < findPathJobCount; ++i)
				{
					var findPathJob = new FindPathJob()
					{
						startPosition = new int2(0, 0),
						targetPosition = new int2(19, 19)
					};
					jobHandles[i] = findPathJob.Schedule();
				}
				JobHandle.CompleteAll(jobHandles);
				jobHandles.Dispose();

				float endTime = Time.realtimeSinceStartup;
				Debug.Log("Took: " + (endTime - startTime) * 1000 + " ms");
			}, 1f));
		}

		[BurstCompile]
		private struct FindPathJob : IJob
		{
			public int2 startPosition;
			public int2 targetPosition;

			public void Execute()
			{
				var gridSize = new int2(20, 20);
				var pathNodeArray = new NativeArray<PathNode>(gridSize.x * gridSize.y, Allocator.Temp);

				for (int y = 0; y < gridSize.y; y++)
				{
					for (int x = 0; x < gridSize.x; x++)
					{
						var pathNode = new PathNode();
						pathNode.x = x;
						pathNode.y = y;
						pathNode.index = CalculateNodeIndex(x, y, gridSize.x);
						pathNode.gCost = 0;
						pathNode.hCost = CalculateDistanceCost(new int2(x, y), targetPosition);
						pathNode.CalculateFCost();
						pathNode.isWalkable = true;
						pathNode.targetIndex = -1;

						pathNodeArray[pathNode.index] = pathNode;
					}
				}

				var startNodeIndex = CalculateNodeIndex(startPosition.x, startPosition.y, gridSize.x);
				var targetNodeIndex = CalculateNodeIndex(targetPosition.x, targetPosition.y, gridSize.x);

				var startNode = pathNodeArray[startNodeIndex];
				startNode.gCost = 0;
				startNode.CalculateFCost();
				pathNodeArray[startNode.index] = startNode;

				var openList = new NativeList<int>(Allocator.Temp);
				var closedArray = new NativeArray<bool>(gridSize.x * gridSize.y, Allocator.Temp);

				var neighbourOffsetArray = new NativeArray<int2>(8, Allocator.Temp);
				neighbourOffsetArray[0] = new int2(-1, 0);
				neighbourOffsetArray[1] = new int2(+1, 0);
				neighbourOffsetArray[2] = new int2(0, +1);
				neighbourOffsetArray[3] = new int2(0, -1);
				neighbourOffsetArray[4] = new int2(-1, -1);
				neighbourOffsetArray[5] = new int2(-1, +1);
				neighbourOffsetArray[6] = new int2(+1, +1);
				neighbourOffsetArray[7] = new int2(+1, -1);

				openList.Add(startNode.index);
				while (openList.Length > 0)
				{
					int currentNodeIndex = GetLowestCostFNodeIndex(openList, pathNodeArray);
					if (currentNodeIndex == targetNodeIndex)
					{
						// Reached destination
						break;
					}

					var currentNode = pathNodeArray[currentNodeIndex];

					// Remove current node from open list
					for (int i = 0; i < openList.Length; ++i)
					{
						if (openList[i] == currentNodeIndex)
						{
							openList.RemoveAtSwapBack(i);
							break;
						}
					}

					closedArray[currentNodeIndex] = true;

					for (int i = 0; i < neighbourOffsetArray.Length; ++i)
					{
						int2 neighbourOffset = neighbourOffsetArray[i];
						int2 neighbourNodePosition = new int2(currentNode.x + neighbourOffset.x, currentNode.y + neighbourOffset.y);

						if (!IsPositionInsideGrid(neighbourNodePosition, gridSize))
						{
							// Neighbour not a valid position
							continue;
						}

						int neighbourNodeIndex = CalculateNodeIndex(neighbourNodePosition.x, neighbourNodePosition.y, gridSize.x);

						if (closedArray[neighbourNodeIndex])
						{
							// Already searched this node
							continue;
						}

						var neighbourNode = pathNodeArray[neighbourNodeIndex];
						if (!neighbourNode.isWalkable)
						{
							// Not walkable
							continue;
						}

						var currentNodePosition = new int2(currentNode.x, currentNode.y);

						int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNodePosition, neighbourNodePosition);
						if (tentativeGCost < neighbourNode.gCost)
						{
							neighbourNode.targetIndex = currentNodeIndex;
							neighbourNode.gCost = tentativeGCost;
							neighbourNode.CalculateFCost();

							pathNodeArray[neighbourNodeIndex] = neighbourNode;
							if (!openList.Contains(neighbourNodeIndex))
							{
								openList.Add(neighbourNodeIndex);
							}
						}
					}
				}

				var targetNode = pathNodeArray[targetNodeIndex];
				if (targetNode.targetIndex == -1)
				{
					// Didn't find a path
				}
				else
				{
					// Found a path
					var path = CalculatePath(pathNodeArray, targetNode);
					path.Dispose();
				}

				pathNodeArray.Dispose();
				openList.Dispose();
				closedArray.Dispose();
				neighbourOffsetArray.Dispose();
			}

			private int CalculateNodeIndex(int x, int y, int width)
			{
				return x + y * width;
			}

			private int CalculateDistanceCost(int2 a, int2 b)
			{
				int dx = math.abs(a.x - b.x);
				int dy = math.abs(a.y - b.y);
				int d = math.abs(dx - dy);
				return math.min(dx, dy) + d;
			}

			private int GetLowestCostFNodeIndex(NativeList<int> openList, NativeArray<PathNode> pathNodeArray)
			{
				var result = pathNodeArray[openList[0]];
				for (int i = 1; i < openList.Length; ++i)
				{
					var test = pathNodeArray[openList[i]];
					if (result.fCost > test.fCost)
					{
						result = test;
					}
				}
				return result.index;
			}

			private bool IsPositionInsideGrid(int2 gridPosition, int2 gridSize)
			{
				return mathx.between(-1, gridSize.x, gridPosition.x) && mathx.between(-1, gridSize.y, gridPosition.y);
			}

			private NativeList<int2> CalculatePath(NativeArray<PathNode> pathNodeArray, PathNode endNode)
			{
				if (endNode.targetIndex == -1)
				{
					// Couln't find a path
					return new NativeList<int2>(Allocator.Temp);
				}
				else
				{
					var result = new NativeList<int2>(Allocator.Temp);
					result.Add(new int2(endNode.x, endNode.y));

					var currentNode = endNode;
					while (currentNode.targetIndex != -1)
					{
						currentNode = pathNodeArray[currentNode.targetIndex];
						result.Add(new int2(currentNode.x, currentNode.y));
					}

					return result;
				}
			}
		}

		IEnumerator InvokeRepeating(Action action, float delay)
		{
			action?.Invoke();
			yield return new WaitForSecondsRealtime(delay);
		}
	}
}
