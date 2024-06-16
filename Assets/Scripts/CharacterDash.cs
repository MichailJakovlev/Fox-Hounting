using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class CharacterDash : MonoBehaviour
{
    CharacterMovement moveScript;

    public Animator anim;
    public float dashSpeed;
    public float dashDelay;
    public float dashTime;
    public float trueSpeed = 200;

    float dashTimer;

    public void Start()
    {
        moveScript = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer <= 0f)
        {
            StartCoroutine(Dash());
            dashTimer = dashDelay;
        }

        if (dashTimer > 0f)
        {
            dashTimer -= Time.deltaTime;
        }

        if(moveScript.isDashing == false)
        {
            moveScript.agent.velocity = moveScript.moveDir * moveScript.speed * Time.fixedDeltaTime;
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {
            moveScript.isDashing = true;
            
            anim.Play("Fox_Jump_InAir");
            
            moveScript.agent.velocity = moveScript.moveDir * dashSpeed * Time.fixedDeltaTime;
            moveScript.agent.SetDestination(moveScript.moveDir + moveScript.agent.transform.position);

            yield return null;
        }
        
        moveScript.isDashing = false;
    }
}
