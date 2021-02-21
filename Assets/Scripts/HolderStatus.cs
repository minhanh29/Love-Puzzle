using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HolderStatus : MonoBehaviour
{
    public Sprite[] sprites;
    private int groundP1 = 9;
    private int groundP2 = 10;
    private bool changedColor = false;
    private SpriteRenderer spriteRenderer;    // changing color

    EndPoint endPoint;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        endPoint = FindObjectOfType<EndPoint>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") && !changedColor)
        {
            changedColor = true;
            gameObject.layer = groundP1;
            spriteRenderer.sprite = sprites[0];
            endPoint.CorrectSound();
        }   

        if (collision.gameObject.CompareTag("Player2") && !changedColor)
        {
            changedColor = true;
            gameObject.layer = groundP2;
            spriteRenderer.sprite = sprites[1];
            endPoint.CorrectSound();
        }
    }
}
