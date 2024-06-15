using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeRabbit : MonoBehaviour
{
    bool isTaken = false;
    public Collider Nest;
    public Collider Rabbit;
    public GameObject Mouth;
    public Animator rabbitAnim;
    public Animator foxAnim;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        RaycastHit hit;

        if (Input.GetMouseButtonUp(0))
        {

            if (Physics.Raycast(ray, out hit, 200f))
            {
                if (hit.collider == Rabbit)
                {
                    isTaken = true;
                }
            }
        }
        if (isTaken)
        {

            Rabbit.transform.position = Mouth.transform.position;
            Rabbit.transform.rotation = Mouth.transform.rotation;
            rabbitAnim.Play("Dead");
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit, 200f))
            {
                if (hit.collider == Nest)
                {
                    isTaken = false;
                    Destroy(Rabbit.gameObject);
                }
            }

        }
    }
}
