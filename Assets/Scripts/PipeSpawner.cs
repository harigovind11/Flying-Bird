using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 0.5f;
    [SerializeField] private GameObject _pips;

    private float _timer;
    void Start()
    {
        SpawnPipe();
        
    }

    private void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    void SpawnPipe()
    {
        Vector3 spawnPipe = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_pips, spawnPipe, Quaternion.identity);
        Destroy(pipe,10f);
    }

}
