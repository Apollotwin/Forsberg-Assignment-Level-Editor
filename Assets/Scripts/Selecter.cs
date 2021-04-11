using UnityEngine;

public class Selecter : MonoBehaviour
{
    private GameObject selection;
    private GameObject currentSelection;
    private int selectedMaterial;

    void Update()
    {
        if (currentSelection != null)
        {
            var tile = currentSelection.GetComponent<GridTile>();
            tile.ChangeMaterial(default);
            currentSelection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * Camera.main.farClipPlane, Color.red);
        if (Physics.Raycast(ray, out var hit))
        {
            selection = hit.collider.gameObject;
            if (selection.CompareTag("Ground"))
            {
                var tile = selection.GetComponent<GridTile>();
                

                if (Input.GetButton("Fire1"))
                {
                    if (tile != null)
                    {
                        tile.ChangeMaterial(selectedMaterial);
                    }
                }
                else if(Input.GetButton("Fire2"))
                {
                    currentSelection = selection;
                }

            }
        }
    }

    public void SelectMaterial(int index)
    {
        selectedMaterial = index;
    }
}
