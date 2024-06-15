using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TakeRabbit : MonoBehaviour
{
    bool isTaken = false;
    public Collider Nest;
    public Collider Rabbit;
    public GameObject Mouth;
    public Animator rabbitAnim;
    public Animator foxAnim;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Rabbit")
        {
            if(Input.GetKey(KeyCode.Space) && isTaken == false)
            {
                isTaken = true;
            }           
        }

        if(isTaken == true && other.gameObject.tag == "Fox Nest")
        {
            isTaken = false;
            Destroy(Rabbit.gameObject);
            print("Yeah");
        }
    }

    void Update()
    {
        if (isTaken)
        {
            Rabbit.transform.position = Mouth.transform.position;
            Rabbit.transform.rotation = Mouth.transform.rotation;
            rabbitAnim.Play("Dead");
        }
    } 
}
