using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    public bool isDashing = false;
    public bool isAttack = false;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public Vector3 moveDir;
    float turnSmoothVelocity;
    public VariableJoystick variableJoystick;

    void LateUpdate()
    {
        if (Time.timeScale == 1)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (isDashing || isAttack)
            {
                horizontal = 0f;
                vertical = 0f;
            }

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (Application.isMobilePlatform || variableJoystick.Vertical != 0 && variableJoystick.Horizontal != 0)
            {
                Vector3 joyStickDirection = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
                agent.velocity = joyStickDirection * speed * Time.fixedDeltaTime;
                agent.SetDestination(joyStickDirection + agent.transform.position);
                anim.Play("Fox_Run");
            }

            else if (horizontal != 0 || vertical != 0)
            {
                if (direction.magnitude >= 0.1f)
                {
                    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                    transform.rotation = Quaternion.Euler(0f, angle, 0f);

                    moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

                    anim.Play("Fox_Run");

                    agent.velocity = moveDir * speed * Time.fixedDeltaTime;
                    agent.SetDestination(moveDir + agent.transform.position);
                }
            }

            else if (isDashing == false && isAttack == false)
            {
                agent.SetDestination(agent.transform.position);
                anim.Play("Fox_Idle");
            }
        }   
    }
}
