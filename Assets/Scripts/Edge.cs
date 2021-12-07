using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Edge : MonoBehaviour
{

	public Cell cell, otherCell;

	public MazeDirection direction;

	public void Initialize(Cell cell, Cell otherCell, MazeDirection direction)
	{
		this.cell = cell;
		this.otherCell = otherCell;
		this.direction = direction;
		cell.SetEdge(direction, this);
		transform.parent = cell.transform;
		transform.localPosition = Vector3.zero;
		//transform.localPosition = new Vector3;
		transform.localRotation = direction.ToRotation();
	}
}
