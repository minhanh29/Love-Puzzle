using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlowButton : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];
    public GlowButton glowButton;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void makeGlow()
    {
        image.sprite = sprites[1];
        glowButton.clearGlow();
    }

    public void clearGlow()
    {
        image.sprite = sprites[0];
    }
}
