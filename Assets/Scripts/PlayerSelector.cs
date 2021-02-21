using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public PlayerController player1;
    public PlayerController player2;

    public void selectP1()
    {
        player1.enabled = true;
        player2.enabled = false;
    }

    public void selectP2()
    {
        player1.enabled = false;
        player2.enabled = true;
    }
}
