using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public GameObject gridTilePrefab;
    public InputField widthInput;
    public InputField heightInput;
    public InputField tileWidthInput;
    public InputField tileHeightInput;
    private int width;
    private int height;
    private float tileWidth;
    private float tileHeight;
    private int[,] gridArray;
    private List<GameObject> gridTileToSave;
    

    public void PopulateGrid()
    {
        tileWidth =  float.Parse(tileWidthInput.text);
        tileHeight = float.Parse(tileHeightInput.text);

        Debug.Log("Width: " + tileWidth + " Height: " + tileHeight);

        width = int.Parse(widthInput.text);
        height = int.Parse(heightInput.text);

        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++) 
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                var gridTile = Instantiate(gridTilePrefab, transform);
                gridTile.gameObject.name = $"GridTile {x}.{y}";
                gridTile.gameObject.transform.localScale = new Vector3(tileWidth / 10, 1, tileHeight / 10);
                gridTile.transform.position = new Vector3(x * tileWidth, 0, y * tileHeight);
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
