using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text moveSpeedText;
    public Text mouseSensetivePlaceholderText;
    public Image crossHair;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Cursor.visible = !StateManager.CameraControlToggle || StateManager.OptionMenuToggle;
        Cursor.lockState = !Cursor.visible ? CursorLockMode.Locked : CursorLockMode.None;
        crossHair.gameObject.SetActive(!Cursor.visible);
    }
}