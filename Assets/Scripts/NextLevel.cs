using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // [SerializeField] private int SceneIndex;
    private Scene _scene;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene(); //caching
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // SceneManager.LoadScene("2"); // sahnenin ismini yazarakta onu çağırabiliriz.

            SceneManager.LoadScene(_scene.buildIndex+1); // buildIndex ile şu anki sahneyi çağırmış olurum
            // SceneManager.LoadScene(SceneIndex); // bu da oyunda bir sonraki sahne indexini girerek yapmamızı saplıyor
        }
    }


    public void StartLevel()
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }
}
