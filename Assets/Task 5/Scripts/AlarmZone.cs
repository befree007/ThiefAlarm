using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmZone : MonoBehaviour
{
    private float _targetVolume;
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _targetVolume = 1;
        StartCoroutine(_alarm.ChangeVolume(_targetVolume));
        Debug.Log("Entered2D");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _targetVolume = 0;
        StartCoroutine(_alarm.ChangeVolume(_targetVolume));
        Debug.Log("Exit2D");
    }
}


