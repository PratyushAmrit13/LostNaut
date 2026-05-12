using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool isPaused;

    private void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = isPaused ? 0f : 1f;

        Cursor.visible = true;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void OnClickResume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
