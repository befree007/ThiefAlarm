using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmZone : MonoBehaviour
{   
    [SerializeField] private float _timeOfIncrease;
    [SerializeField] private ChangeVolumeAlarm _changeVolumeAlarm;
    private Coroutine _changeVolume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _changeVolumeAlarm._targetVolume = 1;
        _changeVolumeAlarm._volumeScale = 0;
        _changeVolume = StartCoroutine(_changeVolumeAlarm.ChangeVolume(_changeVolumeAlarm._targetVolume));
        Debug.Log("Entered2D");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _changeVolumeAlarm._targetVolume = 0;
        _changeVolumeAlarm._volumeScale = 0;
        _changeVolume = StartCoroutine(_changeVolumeAlarm.ChangeVolume(_changeVolumeAlarm._targetVolume));
        Debug.Log("Exit2D");
    }
}


