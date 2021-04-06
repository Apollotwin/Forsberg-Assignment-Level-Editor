using System;
using UnityEngine;

[Serializable]
public class GridTile : MonoBehaviour
{
    public GameObject gridTile;
    private Material gridMat;
    public enum GridTileType { empty, grass, water, selected }
    public GridTileType type;
    public bool isHighlighted = false;

    public GridTile(GridTileType type)
    {
        this.type = type;
        if (type == GridTileType.empty)
        {
            gridMat.color = Color.white;
        }
        if(type == GridTileType.grass)
        {
            gridMat.color = Color.green;
        }
        if(type == GridTileType.water)
        {
            gridMat.color = Color.blue;
        }
        if (type == GridTileType.selected)
        {
            gridMat.color = Color.yellow;
        }
    }

    private void Start()
    {
        gridMat = FindObjectOfType<MeshRenderer>().material;
    }

    private void Update()
    {
        if (isHighlighted)
        {
            type = GridTileType.selected;
        }
        else
        {
            type = GridTileType.empty;
        }
    }
}