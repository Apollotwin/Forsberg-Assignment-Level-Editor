using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject gridTilePrefab;
    public int width;
    public int height;
    private int[,] gridArray;

    public void PopulateGrid()
    {
        gridArray = new int[width,height];

        for (int x = 0; x < gridArray.GetLength(0); x++) 
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Instantiate(gridTilePrefab, transform);
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
