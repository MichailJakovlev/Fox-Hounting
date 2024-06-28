using UnityEngine;

public class MobileMenuUI : MonoBehaviour
{
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;

    void Start()
    {
        if(Application.isMobilePlatform)
        {
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
        }
    } 
}
