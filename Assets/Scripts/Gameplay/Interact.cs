using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject uiObject;

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider player) {
        if (player.gameObject.tag == "Player"){
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec(){
        yield return new WaitForSeconds(2);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}
