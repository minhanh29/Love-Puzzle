using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailMove : MonoBehaviour
{
    public GameObject thu;
    public GameObject bg;
    // Start is called before the first frame update
    public void OpenThu()
    {
        thu.SetActive(true);
        bg.SetActive(true);
        gameObject.SetActive(false);
    }

}
