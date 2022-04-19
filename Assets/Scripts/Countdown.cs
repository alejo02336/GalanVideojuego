using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    [SerializeField] Image timeImage;
    [SerializeField] Text timeText;
    [SerializeField] float duration, currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn() {
        while (currentTime >= 0) {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        cambiarEscena();
    }

    void cambiarEscena() {
        SceneManager.LoadScene("Cinematica");
    }
}
