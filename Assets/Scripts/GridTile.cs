using System;
using UnityEngine;

[Serializable]
public class GridTile : MonoBehaviour
{
    public GameObject gridTile;
    private Material gridMat;
    public enum GridTileType { empty, grass, water }
    public GridTileType type;

    private void Start()
    {
        gridMat = FindObjectOfType<MeshRenderer>().material;
    }

    private void Update()
    {
        if (type == GridTileType.empty)
        {
            gridMat.color = Color.gray;
        }
        if(type == GridTileType.grass)
        {
            gridMat.color = Color.green;
        }
        if(type == GridTileType.water)
        {
            gridMat.color = Color.blue;
        }
    }
}