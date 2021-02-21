using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    public AudioSource correctSound;

    private float limit = 2f;
    private float distance1, distance2;
    private bool ended = false;

    private void Update()
    {
        distance1 = Vector2.Distance(transform.position, player1.position);
        distance2 = Vector2.Distance(transform.position, player2.position);

        if (distance1 < limit && distance2 < limit && !ended)
        {
            ended = true;
            int index = SceneManager.GetActiveScene().buildIndex;

            if (index < 3)
                FindObjectOfType<GameManager>().GameWin();
            else
                FindObjectOfType<GameManager>().finalGame();
        }
    }

    public void CorrectSound()
    {
        correctSound.Play();
    }
}
