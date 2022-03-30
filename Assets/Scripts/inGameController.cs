using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inGameController : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuButton;
    [SerializeField] GameObject objectClip;
    public void ActivarFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        objectClip.GetComponent<AudioSource>().Play();
    }

    public void ActivarMenu()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
        menuButton.SetActive(false);
        objectClip.GetComponent<AudioSource>().Play();
    }

    public void DesactivarMenu()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
        menuButton.SetActive(true);
        objectClip.GetComponent<AudioSource>().Play();
    }

    public void EscenaJuego(string escena)
    {
        SceneManager.LoadScene(escena);
        objectClip.GetComponent<AudioSource>().Play();
    }
}
