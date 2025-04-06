using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private AudioClip bgm;
    [SerializeField] private AudioClip death;
    [SerializeField] private AudioClip levelUp;

    [SerializeField] GameObject flappy; 
    
    private AudioSource _audioSource;

    private Animator animator;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

       _audioSource = GetComponent<AudioSource>();
       _audioSource.Play();

        animator = flappy.GetComponent<Animator>();
        Time.timeScale = 1f;

    }

    // public void Update()
    // {
    //     if (Score.instance._score == 10)
    //     {
    //         animator.SetTrigger("level2");
    //         _audioSource.PlayOneShot(levelUp);
    //         _audioSource.Play();
    //     }
    //     else if(Score.instance._score == 20)
    //     {
    //         animator.SetTrigger("level3");
    //         _audioSource.PlayOneShot(levelUp);
    //         _audioSource.Play();
    //     }
    // }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        _audioSource.Stop();
        _audioSource.PlayOneShot(death);
    }

    public void ReloadGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     
    }


}
