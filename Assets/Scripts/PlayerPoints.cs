using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    // public int score=0;
    [SerializeField] private TextMeshProUGUI _text;
    private AudioSource _audio;


    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _text.text = score.totalScore.ToString(); // yeni sahneye geçtiğinde direkt olarak bize bir önceki skoru yazmasını sağlar bir kez çalışır.
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Elmas"))
        {
            _audio.Play();
            Destroy(other.gameObject);
            score.totalScore++;
            _text.text = score.totalScore.ToString();
        }
    }
}
