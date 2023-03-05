using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMultiplayer : MonoBehaviour
{
    private Vector3 _baryCentre;
    private Transform[] _playerTransforms;
    
    void Start()
    {
        _playerTransforms = GameObject.FindGameObjectWithTag("Player").GetComponents<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sum = Vector3.zero;
        foreach (Transform player in _playerTransforms)
        {
            sum += transform.position;
        }

        Vector3 barycenter = sum / _playerTransforms.Length;
        transform.position = barycenter;
        
    }
}
