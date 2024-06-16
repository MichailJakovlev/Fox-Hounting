using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TakeRabbit : MonoBehaviour
{
    bool isTaken = false;
    public Collider Nest;
    private Collider Rabbit;
    public GameObject Mouth;
    public Animator foxAnim;
    public SpawnRabbit Spawn;
    CharacterMovement moveScript;
    public float attackTime;

    public void Start()
    {
        moveScript = GetComponent<CharacterMovement>();
        var Spawn = GetComponent<SpawnRabbit>();
    }

    public void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Rabbit")
        {
            if (Input.GetKey(KeyCode.Space) && isTaken == false)
            {
                isTaken = true;
                Rabbit = other;
                StartCoroutine(Attack());    
            }

            if (isTaken && Rabbit.gameObject.transform.position != Mouth.transform.position && moveScript.isAttack == false)
            {
                Rabbit.gameObject.transform.position = Mouth.transform.position;
                Rabbit.gameObject.transform.rotation = Mouth.transform.rotation;
            }
        }

        if (isTaken == true && other.gameObject.tag == "Fox Nest")
        {
            isTaken = false;
            Destroy(Rabbit.gameObject);
            Spawn.SpawnOnce();
        }
    }

    IEnumerator Attack()
    {
        float startTime = Time.time;
        moveScript.isAttack = true;
        
        while (Time.time < startTime + attackTime)
        {
            foxAnim.Play("Fox_Attack_Paws");
            yield return null;
        }
        moveScript.isAttack = false;
    }
}
