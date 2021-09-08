using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurretType : MonoBehaviour
{
    public GameObject[] GetSpawnPoint
    {
        get => _spawnPoints;
    }
    public float GetPower
    {
        get => _power;
    }

    [SerializeField] private float _power;
    [SerializeField] private GameObject[] _spawnPoints;

}
