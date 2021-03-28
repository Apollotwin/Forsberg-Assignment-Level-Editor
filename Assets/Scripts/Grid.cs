using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject gridTilePrefab;
    public int width;
    public int height;
    private int[,] gridArray;

    public Grid(int width, int height)
    {
        this.width = width;
        this.height = height;
        
        gridArray = new int[width,height];

        for (int x = 0; x < gridArray.GetLength(0); x++) 
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Instantiate(gridTilePrefab, transform);
            }   
        }
    }
    
}
