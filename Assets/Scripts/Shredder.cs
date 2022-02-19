using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shredder : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    SceneChanger sceneChanger;
    AudioSource heartSound;
    private int heartIndex;
    FruitsSpawner fruitsSpawner;
    int numberOfHearts;

    private void Start()
    {
        heartSound = GetComponent<AudioSource>();
        sceneChanger = FindObjectOfType<SceneChanger>();
        fruitsSpawner = FindObjectOfType<FruitsSpawner>();
        heartIndex = 0;
        numberOfHearts = 3;
    }

    private void Update()
    {
        if (fruitsSpawner.totalAmountOfFruitsDown == 0 && numberOfHearts > 0)
        {
            StartCoroutine(ShowWinScene());
            //StopAllCoroutines();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            Destroy(collision.gameObject);
            Destroy(hearts[heartIndex]);
            heartSound.Play();
            heartIndex++;
            numberOfHearts--;
            fruitsSpawner.totalAmountOfFruitsDown--;
            if (heartIndex == 3)
            {
                StartCoroutine(ShowGameOverScene());
            }
        }
    }

    IEnumerator ShowWinScene()
    { 
        yield return new WaitForSeconds(1f);
        sceneChanger.WinScene();
    }

    IEnumerator ShowGameOverScene()
    {
        yield return new WaitForSeconds(0.5f);
        sceneChanger.GameOverScene();
             
    }

}
