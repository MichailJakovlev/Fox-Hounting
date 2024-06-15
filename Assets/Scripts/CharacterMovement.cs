using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    //public CharacterController controller;
    
    public NavMeshAgent agent;
    public Animator anim;
    public bool isDashing = false;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public Vector3 moveDir;
    float turnSmoothVelocity;

    public void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (isDashing) {
            horizontal = 0f;
            vertical = 0f;
        }
        Vector3 direction = new Vector3 (horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f) {

            

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            anim.Play("Fox_Run");

            agent.velocity = moveDir * speed * Time.fixedDeltaTime;
            agent.SetDestination(moveDir + agent.transform.position);
           

        }

        if (direction.magnitude <= 0.1f && isDashing == false)
        {

            anim.Play("Fox_Idle");
        }

    }

}


