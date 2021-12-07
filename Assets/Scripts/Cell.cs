using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cell : MonoBehaviour
{
    public Vector2 coordinates;
	private int initializedEdgeCount;

	private Edge[] edges = new Edge[MazeDirections.Count];

	public Edge GetEdge(MazeDirection direction)
	{
		int intdir = (int)direction;
		return edges[intdir];
	}
	public bool IsFullyInitialized
	{
		get
		{
			return initializedEdgeCount == MazeDirections.Count;
		}
	}

	public void SetEdge(MazeDirection direction, Edge edge)
	{
		int intdir = (int)direction;
		edges[intdir] = edge;
		initializedEdgeCount += 1;
	}

	public MazeDirection RandomUninitializedDirection
	{
		get
		{
			int skips = Random.Range(0, MazeDirections.Count - initializedEdgeCount);
			for (int i = 0; i < MazeDirections.Count; i++)
			{
				if (edges[i] == null)
				{
					if (skips == 0)
					{
						return (MazeDirection)i;
					}
					skips -= 1;
				}
			}
			throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
		}
	}
}
