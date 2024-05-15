using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _varsBloks;

    private void Start()
    {
        SpawnBloks();
    }
    public void SpawnBloks()
    {
        Instantiate(_varsBloks[Random.Range(0,_varsBloks.Length)],transform.position,Quaternion.identity);
    }
}
