using System.Collections;
using UnityEngine;

public class TakeRabbit : MonoBehaviour
{
    public bool isTaken = false;
    public Collider Nest;
    public GameObject Mouth;
    public Animator rabbitAnim;
    public Animator foxAnim;
    public LifeTimer Timer;
    public SpawnRabbit Spawn;
    CharacterMovement moveScript;
    public float attackTime;
    bool isGrab = false;
    bool isRabbit = false;

    public void Start()
    {
        moveScript = GetComponent<CharacterMovement>();
        var Spawn = GetComponent<SpawnRabbit>();
    }

    public void GrabRabbit()
    {
        if(isRabbit)
        {
            isGrab = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Rabbit")
        {
            isRabbit = true;
            if (Input.GetKey(KeyCode.Space) || isGrab && isTaken == false)
            {
                isTaken = true;
                isGrab = false;
                isRabbit = false;
                Destroy(other.gameObject);
                Mouth.SetActive(true);
                StartCoroutine(Attack());
            } 
        }

        if (isTaken == true && other.gameObject.tag == "Fox Nest")
        {
            isTaken = false;
            Mouth.SetActive(false);
            Timer.lifeTime += 15;
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
