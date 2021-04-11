using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public GameObject buildPanel;
    public GameObject optionMenu;
    
    public static bool CameraControlToggle { get; private set; } = true;
    public static bool OptionMenuToggle { get; private set; }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            CameraControlToggle = !CameraControlToggle;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OptionMenuToggle = !OptionMenuToggle;
        }
        
        buildPanel.SetActive(!CameraControlToggle);
        optionMenu.SetActive(OptionMenuToggle);
    }
    
    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}