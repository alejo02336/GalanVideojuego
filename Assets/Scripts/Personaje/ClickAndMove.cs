using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

 


namespace Graphics.Feedback.Scripts {
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class ClickAndMove : MonoBehaviour {
 
    NavMeshAgent nv;
    Animator anim;
 
    Vector3 Objetivo;

    [SerializeField] GameObject objectClip;
    [SerializeField]  AudioClip clip ;

    //Pointer
    private  FeedbackPointer _feedbackPointer = new FeedbackPointer();

    [SerializeField]
    private float _feedbackPointerScale = 100f;

    

    [SerializeField]
    private GameObject _moveToIndicator;

    // Use this for initialization
    void Start ()
    {
        nv = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();    
        _feedbackPointer.PreparePointer(_moveToIndicator, _feedbackPointerScale);

    }
    
    // Update is called once per frame
    void Update ()
    {


         anim.SetFloat("Velocidad", nv.velocity.magnitude/nv.speed);
       
        if (DialogueManager.isActive == true) return;


        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit h;
            if (Physics.Raycast(r, out h))
            {
                Objetivo = h.point;
                _feedbackPointer.ShowPointer(h.point);
                SetPosition();

            }
       
        }
        
     

    }
    void SetPosition()
    {
        nv.SetDestination(Objetivo);
    }

    public void Step()
    {
      
      objectClip.GetComponent<AudioSource>().PlayOneShot(clip);
        
    }
}
}
