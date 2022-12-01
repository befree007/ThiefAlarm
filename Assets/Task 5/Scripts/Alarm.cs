using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{    
    [SerializeField] private float _timeOfIncrease;

    private float _volumeScale;
    private float _targetVolume;
    private AudioSource _audioSource;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator ChangeVolume(float targetVolume)
    {
        _volumeScale = 0;

        while (_audioSource.volume != targetVolume)
        {
            _volumeScale = Time.deltaTime / _timeOfIncrease;
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeScale);

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _targetVolume = 1;
        StartCoroutine(ChangeVolume(_targetVolume));
        Debug.Log("Entered2D");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _targetVolume = 0;
        StartCoroutine(ChangeVolume(_targetVolume));
        Debug.Log("Exit2D");
    }
}
