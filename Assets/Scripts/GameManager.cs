using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 4f;
    public GameObject gameOverText;
    public GameObject finishText;
    public GameObject complimentText;
    public GameObject darkener;
    public GameObject emUText;
    public GameObject mail;

    public AudioSource bgMusic;
    public AudioSource overMusic;
    public AudioSource cheerMusic;
    public AudioSource happyMusic;

    private void Start()
    {
        gameOverText.SetActive(false);
        finishText.SetActive(false);
        complimentText.SetActive(false);
        darkener.SetActive(false);
    }

    public void EndGame()
    {
        bgMusic.Stop();
        overMusic.Play();
        gameOverText.SetActive(true);
        darkener.SetActive(true);
        StartCoroutine("Restart");
    }

    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(restartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameWin()
    {
        bgMusic.Stop();
        cheerMusic.Play();
        StartCoroutine("showFinish");
        StartCoroutine("showCompliment");
        StartCoroutine("nextLevel");
    }

    public void finalGame()
    {
        bgMusic.Stop();
        happyMusic.Play();
        StartCoroutine("showFinish");
        StartCoroutine("showCompliment");
        StartCoroutine("showEmU");
        StartCoroutine("showMail");
    }

    public IEnumerator showFinish()
    {
        yield return new WaitForSeconds(0.5f);
        darkener.SetActive(true);
        finishText.SetActive(true);
    }

    public IEnumerator showCompliment()
    {
        yield return new WaitForSeconds(2f);
        complimentText.SetActive(true);
    }

    public IEnumerator showEmU()
    {
        yield return new WaitForSeconds(3.5f);
        emUText.SetActive(true);
        finishText.SetActive(false);
        complimentText.SetActive(false);
    }

    public IEnumerator showMail()
    {
        yield return new WaitForSeconds(4f);
        mail.SetActive(true);
    }
}
