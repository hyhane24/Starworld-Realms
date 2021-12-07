using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Maze : MonoBehaviour
{
    public Cell cellPrefab;
    private Cell[,] cells;
    public Vector2 size;
    public Passage passagePrefab;
    public Wall wallPrefab;
    public GameObject EnemyPrefab;
    public GameObject KeyPrefab;
    private GameObject key;
    public GameObject healthPrefab;
    
    public GameObject[] enemies;
    public Maze()
    {
        Debug.Log("Maze Default Constructor Called");
    }

    public Vector2 RandomCoordinates
    {
        get
        {
            return new Vector2(Random.Range(0, size.x), Random.Range(0, size.z));
        }
    }

    public bool ContainsCoordinates(Vector2 coordinate)
    {
        return coordinate.x >= 0 && coordinate.x < size.x && coordinate.z >= 0 && coordinate.z < size.z;
    }

    public void Generate()
    {
        cells = new Cell[size.x,size.z];
        List<Cell> activeCells = new List<Cell>();
        DoFirstGenerationStep(activeCells);
        while (activeCells.Count > 0)
        {
            // CreateCell(coordinates);
            // Debug.Log(coordinates.x + "," + coordinates.z);
            // coordinates += MazeDirections.RandomValue.ToVector2();
            // coordinates.z += 1;
            DoNextGenerationStep(activeCells);
        }

     
    }

    private void DoFirstGenerationStep(List<Cell> activeCells)
    {
        activeCells.Add(CreateCell(RandomCoordinates));
    }

    private void DoNextGenerationStep(List<Cell> activeCells)
    {
        int currentIndex = activeCells.Count - 1;
        Cell currentCell = activeCells[currentIndex];
        if (currentCell.IsFullyInitialized)
        {
            activeCells.RemoveAt(currentIndex);
            return;
        }
        else
        {
            MazeDirection direction = currentCell.RandomUninitializedDirection;
            Vector2 coordinates = currentCell.coordinates + direction.ToVector2();
            if (ContainsCoordinates(coordinates))
            {
                Cell neighbor = GetCell(coordinates);
                if (neighbor == null)
                {
                    neighbor = CreateCell(coordinates);
                    CreatePassage(currentCell, neighbor, direction);
                    activeCells.Add(neighbor);
                }
                else
                {
                    CreateWall(currentCell, neighbor, direction);
                }
            }
            else
            {
                CreateWall(currentCell, null, direction);
            }
        }
    }

    private void CreatePassage(Cell cell, Cell otherCell, MazeDirection direction)
    {
        //Passage passage = PrefabUtility.InstantiatePrefab(passagePrefab) as Passage;
        Passage passage = Instantiate(passagePrefab) as Passage;
        passage.Initialize(cell, otherCell, direction);
        //passage = PrefabUtility.InstantiatePrefab(passagePrefab) as Passage;
        passage = Instantiate(passagePrefab) as Passage;
        passage.Initialize(otherCell, cell, direction.GetOpposite());
        //generate random enemy prefab with random chance
        int chance = Random.Range(0, 19);
        if (chance == 1)
        {
            int num = Random.Range(0, 4);
            GameObject enemy = Instantiate(enemies[num],new Vector3(passage.transform.position.x, passage.transform.position.y, passage.transform.position.z),Quaternion.identity);
        }
        else if(chance == 2)
        {
            GameObject healthPickup = Instantiate(healthPrefab, new Vector3(passage.transform.position.x, passage.transform.position.y+1.2f, passage.transform.position.z), Quaternion.identity);
        }
        // generate key if its fairly close to center
        // This will probably have to be changed to relative position if maze is moved relative to other levels
        if (Mathf.Abs(passage.transform.parent.position.x) < 5 && Mathf.Abs(passage.transform.parent.position.z) < 5)
        {
            Debug.Log(passage.transform.parent.position.x+",!,"+passage.transform.parent.position.z);

            Debug.Log("ASD" + key);
            if (key == null)
            {
                key = Instantiate(KeyPrefab, new Vector3(passage.transform.position.x, passage.transform.position.y + KeyPrefab.GetComponent<MeshRenderer>().bounds.size.y, passage.transform.position.z), Quaternion.identity);
                //GameObject key = Instantiate(KeyPrefab,passage.transform.parent.position, Quaternion.identity);
                if (key == null)
                {
                    Debug.Log("Key generation error");
                }
            }

        }
    }

    private void CreateWall(Cell cell, Cell otherCell, MazeDirection direction)
    {
        //Wall wall = PrefabUtility.InstantiatePrefab(wallPrefab) as Wall;
        Wall wall = Instantiate(wallPrefab) as Wall;
        wall.Initialize(cell, otherCell, direction);
        if (otherCell != null)
        {
            //wall = PrefabUtility.InstantiatePrefab(wallPrefab) as Wall;
            wall = Instantiate(wallPrefab) as Wall;
            wall.Initialize(otherCell, cell, direction.GetOpposite());
        }
    }

    public Cell GetCell(Vector2 coordinates)
    {
        return cells[coordinates.x, coordinates.z];
    }


    private Cell CreateCell(Vector2 coordinates)
    {
        //Debug.Log(coordinates.x);
        // Cell newCell = PrefabUtility.InstantiatePrefab(cellPrefab) as Cell;
        Cell newCell = Instantiate(cellPrefab) as Cell;
        if (newCell == null)
        {
            Debug.Log("Error generating cell " + coordinates.x + "," + coordinates.z);
        }
        cells[coordinates.x, coordinates.z] = newCell;
        newCell.coordinates = coordinates;
        newCell.name = "Cell " + coordinates.x + ", " + coordinates.z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
        Debug.Log(newCell.transform.localPosition.x);
        return newCell;

    }
}
