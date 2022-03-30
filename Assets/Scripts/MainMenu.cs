using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject objectClip;
    
    public void EscenaJuego(string escena) {
        SceneManager.LoadScene(escena);
        objectClip.GetComponent<AudioSource>().Play();
    }
}
