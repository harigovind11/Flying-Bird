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

    [SerializeField] GameObject bird;

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

        Time.timeScale = 1f;
        animator = bird.GetComponent<Animator>();

    }
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        animator.SetTrigger("puff");
        _audioSource.Stop();
        _audioSource.PlayOneShot(death);
        bird.GetComponent<FlyAbility>().enabled = false;
        bird.GetComponent<Rigidbody2D>().gravityScale = 0f;

    }

    public void ReloadGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


}
