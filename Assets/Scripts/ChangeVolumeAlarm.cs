using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ChangeVolumeAlarm : MonoBehaviour
{
    [HideInInspector] public float _targetVolume;
    [HideInInspector] public float _volumeScale;
    [SerializeField] private float _timeOfIncrease;
    private AudioSource _audioSource;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _volumeScale += Time.deltaTime / _timeOfIncrease;
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeScale);

            yield return null;

            if (_audioSource.volume == _targetVolume)
            {
                StopAllCoroutines();
                Debug.Log("Stop");
            }
        }
    }
}
