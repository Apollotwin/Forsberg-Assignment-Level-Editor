using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class GridTile : MonoBehaviour
{
    public Material[] tileMaterials;
    private MeshRenderer gridMat;
    private int matIndex;

    public int MatIndex
    {
        get => matIndex;
        set => matIndex = value;
    }

    private void Awake()
    {
        gridMat = GetComponent<MeshRenderer>();
    }

    public void ChangeMaterial(int index)
    {
        MatIndex = index;
        gridMat.material = tileMaterials[index];
    }
}