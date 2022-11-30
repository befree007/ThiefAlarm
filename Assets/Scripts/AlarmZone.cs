using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmZone : MonoBehaviour
{   
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _timeOfIncrease;
    private AudioSource _audioSource;
    private float _volumeScale;

    // Start is called before the first frame update
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _maxVolume = 1;
        StartCoroutine(ChangeVolume());
        Debug.Log("Entered2D");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _maxVolume = 0;
        Debug.Log("Exit2D");
    }

    private void LoopCoroutine()
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
        _volumeScale += Time.deltaTime / _timeOfIncrease;

        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _volumeScale);
        Debug.Log("WORK");
        yield return null;

        LoopCoroutine();
    }
}


