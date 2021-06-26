using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsMenu;

    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private LookWithMouse lookWithMouse;

    private void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            this.characterController.enabled = false;
            this.playerMovement.enabled = false;
            this.lookWithMouse.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            this.settingsMenu.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void CloseSettings()
    {
        this.characterController.enabled = true;
        this.playerMovement.enabled = true;
        this.lookWithMouse.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        this.settingsMenu.SetActive(false);
    }
}
