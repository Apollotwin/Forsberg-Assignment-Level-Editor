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

        width = int.Parse(widthInput.text);
        height = int.Parse(heightInput.text);
        
        ClearGrid();
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++) 
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                var gridTile = Instantiate(gridTilePrefab, transform);
                gridTile.gameObject.name = $"GridTile {x}.{z}";
                gridTile.gameObject.transform.localScale = new Vector3(tileWidth / 10, 1, tileHeight / 10);
                gridTile.transform.position = new Vector3(x * tileWidth, 0, z * tileHeight);
            }   
        }
    }

    public void ClearGrid()
    {
        var allTiles = FindObjectsOfType<GridTile>();
        if(allTiles == null) return;
        foreach (var gridTile in allTiles)
        {
            Destroy(gridTile.gameObject);
        }
    }

    public void SaveTile()
    {
        var allTiles = FindObjectsOfType<GridTile>();

        foreach (var tile in allTiles)
        {
            PlayerPrefs.SetInt(tile.name, tile.MatIndex);
        }
    }

    public void LoadTile()
    {
        var allTiles = FindObjectsOfType<GridTile>();

        foreach (var tile in allTiles)
        {
            var index = PlayerPrefs.GetInt(tile.name);
            tile.ChangeMaterial(index);
        }
    }

    public void SaveGrid()
    {
        PlayerPrefs.SetInt("GridWidth", width);
        PlayerPrefs.SetInt("GridHeight", height);
        PlayerPrefs.SetFloat("tileWidth", tileWidth);
        PlayerPrefs.SetFloat("tileHeight", tileHeight);
        
        SaveTile();
    }
    
    public void LoadGrid()
    {
        ClearGrid();
        
        width = PlayerPrefs.GetInt("GridWidth");
        height = PlayerPrefs.GetInt("GridHeight");
        tileWidth = PlayerPrefs.GetFloat("tileWidth");
        tileHeight = PlayerPrefs.GetFloat("tileHeight");
        
        GenerateGrid();
        LoadTile();
    }
}
