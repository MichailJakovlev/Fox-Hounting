using UnityEngine;

public class Rabbit : MonoBehaviour
{
    public Animator anim;

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Input.GetKey(KeyCode.Space))
        {
                anim.Play("Dead");
        }
    }
}
