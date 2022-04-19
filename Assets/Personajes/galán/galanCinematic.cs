using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class galanCinematic : MonoBehaviour
{
   
    Animator animator; 
 


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
        
        animator = GetComponent<Animator>();
    } 

 


  
    IEnumerator ExampleCoroutine()
    {
       
        yield return new WaitForSeconds(3.3f);

     
       
         yield return new WaitForSeconds(10f);
       animator.SetTrigger("dead");
        
    }
    
}
