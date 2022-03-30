using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Introduccion : MonoBehaviour
{
    int clicks;
    public Text textElement;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuButton;
    [SerializeField] GameObject objectClip;

    string textValue1 = "En esta versión podras experimentar un hecho historico, pero ten cuidado";
    string textValue2 = "Si pones cuidado en tu entorno podrias cambiar el desenlace del hecho";
    private void Start()
    {
        clicks = 0;
    }

    public void CambiarTexto()
    {
        if (clicks == 0) {
            textElement.text = textValue1;
            clicks++;
        }
        else if (clicks == 1) {
            textElement.text = textValue2;
            clicks++;
        }
        else if (clicks == 2) {
            SceneManager.LoadScene("Selector");
        }
        objectClip.GetComponent<AudioSource>().Play();
    }

    public void ActivarFullscreen() {
        Screen.fullScreen = !Screen.fullScreen;
        objectClip.GetComponent<AudioSource>().Play();
    }

    public void ActivarMenu() {
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
