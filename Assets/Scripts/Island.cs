using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeToDesapear());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimeToDesapear()
    {
        yield return new WaitForSeconds(19.0f);
        anim.SetBool("Desapear",true);
        StartCoroutine(Desapear());

    }

    IEnumerator Desapear()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }



}
