using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmZone : MonoBehaviour
{   
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _timeOfIncrease;
    private AudioSource _audioSource;
    private float _runningTime;
    private float _volumeScale;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _maxVolume = 1;
        _runningTime = 0;
        StartCoroutine(ChangeVolume());
        Debug.Log("Entered2D");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _maxVolume = 0;
        _runningTime = 0;
        Debug.Log("Exit2D");
    }

    private void RepetCoroutine()
    {
        if (_audioSource.volume == 0)
        {
            StopCoroutine(ChangeVolume());
        }
        else
        {
            StartCoroutine(ChangeVolume());
        }        
    }

    private IEnumerator ChangeVolume()
    {
        _runningTime += Time.deltaTime;
        _volumeScale = _runningTime / _timeOfIncrease;

        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _volumeScale);
        Debug.Log("WORK");
        yield return null;

        RepetCoroutine();
    }
}


