using System.Collections;
using UnityEngine;

public class TakeRabbit : MonoBehaviour
{
    public bool isTaken = false;
    public Collider Nest;
    private Collider _rabbit;
    public GameObject Mouth;
    public Animator rabbitAnim;
    public Animator foxAnim;
    public LifeTimer Timer;
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
                _rabbit = other;
                StartCoroutine(Attack());
            }

            if (isTaken && _rabbit.gameObject.transform.position != Mouth.transform.position && moveScript.isAttack == false)
            {
                _rabbit.gameObject.transform.position = Mouth.transform.position;
                _rabbit.gameObject.transform.rotation = Mouth.transform.rotation;
            }
        }

        if (isTaken == true && other.gameObject.tag == "Fox Nest")
        {
            isTaken = false;
            Destroy(_rabbit.gameObject);
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
