using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent(out GridTile gridTile))
            {
                gridTile.isHighlighted = true;
            }
            else
            {
                gridTile.isHighlighted = false;
            }

        }
    }
}
