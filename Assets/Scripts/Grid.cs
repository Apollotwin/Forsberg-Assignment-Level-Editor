using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public GameObject gridTilePrefab;
    public InputField widthInput;
    public InputField heightInput;
    private int width;
    private int height;
    private int[,] gridArray;
    private List<GameObject> gridTileToSave;
    

    public void PopulateGrid()
    {
        width = int.Parse(widthInput.text);
        height = int.Parse(heightInput.text);

        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++) 
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Debug.Log(x + "," + y);
                var gridTile = Instantiate(gridTilePrefab, transform);
                gridTile.gameObject.name = $"GridTile {x}.{y}";
                gridTile.transform.position = new Vector3(x * 10, 0, y * 10);
                gridTile.GetComponent<GridTile>().type = GridTile.GridTileType.empty;
            }   
        }
    }

    public void ClearGrid()
    {
        var allTiles = FindObjectsOfType<GridTile>();

        foreach (var gridTile in allTiles)
        {
            Destroy(gridTile.gameObject);
        }
    }
}
