using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    [SerializeField] float duration, currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = duration;
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        cambiarEscena();
    }

    void cambiarEscena()
    {
        SceneManager.LoadScene("collage");
    }
}
