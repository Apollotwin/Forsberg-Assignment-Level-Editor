using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    void Start()
    {
        var grid = FindObjectOfType<Grid>();
        grid = new Grid(5,3);
    }
}
