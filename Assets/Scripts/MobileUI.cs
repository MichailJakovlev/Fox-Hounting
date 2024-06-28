using UnityEngine;

public class MobileUI : MonoBehaviour
{
    public GameObject MobileControl;
    
    void Start()
    {
        if(Application.isMobilePlatform)
        {
            MobileControl.SetActive(true);
        }
    }
}
