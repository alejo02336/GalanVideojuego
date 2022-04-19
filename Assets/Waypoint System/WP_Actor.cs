using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WP_Actor : MonoBehaviour
{ 
    float speed = 1.0f;
    Animator animator;

    public Transform target;
    bool init = false;

    public Image bloodImage;
    private float r, g, b, a;
    bool dead = false;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
         transform.LookAt(new Vector3(target.position.x,transform.position.y,target.position.z));
        animator = GetComponent<Animator>();

        r= bloodImage.color.r;
        g= bloodImage.color.g;
        b= bloodImage.color.b;
        a= bloodImage.color.a;

    }

    // Update is called once per frame
    void Update()
    {

        if(init){
        transform.Translate(new Vector3(0,0,speed*Time.deltaTime));
        }

        if(dead){
            a += 0.01f;
        }

        a-=0.001f;

        a= Mathf.Clamp(a, 0, 1f);

        ChangeColor();
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Waypoint"){
            target = other.gameObject.GetComponent<Waypoint>().nextPoint;
            transform.LookAt(new Vector3(target.position.x,transform.position.y,target.position.z));
            Debug.Log(target);
        }
    }


  
    IEnumerator ExampleCoroutine()
    {
       
        yield return new WaitForSeconds(3.3f);

        init = true;
        animator.SetTrigger("walk");
         yield return new WaitForSeconds(10f);
         animator.SetTrigger("shoot");
         
         init= false;
        yield return new WaitForSeconds(2f);
        dead= true;
        init= true;
        animator.SetTrigger("run");
        speed = 3.0f;
        yield return new WaitForSeconds(3f);
          init= false;
    }

    private void ChangeColor(){
        Color c = new Color(r,g,b,a);
        bloodImage.color = c;
    }
}
