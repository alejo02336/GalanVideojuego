using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public DialogueTrigger trigger;
    bool can = true;
    public GameObject talkIndicator;
    public Transform Target;
    public float Speed = 1f;

    private Coroutine LookCoroutine;

    public void StartRotating()
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt());
    }

    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(Target.position - transform.position);

        float time = 0;

        Quaternion initialRotation = transform.rotation;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, lookRotation, time);

            time += Time.deltaTime * Speed;

            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        talkIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
           
        
    }

    public void OnTriggerStay(Collider other) {
        talkIndicator.SetActive(true);
        if((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.E)  && can){

            
            StartRotating();
            trigger.StartDialogue();
            can = false;
            
        }
    }

    public void OnTriggerExit() {
        can = true;
        talkIndicator.SetActive(false);
    }
}
