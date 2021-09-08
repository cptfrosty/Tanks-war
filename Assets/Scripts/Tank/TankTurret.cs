using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurret : MonoBehaviour
{
    const float forceShoot = 50;
    const int countBullet = 30;

    [SerializeField] private Bullet _prefabBullet;
    [SerializeField] private List<Bullet> Bullets;

    [SerializeField] private KeyCode _shootKey;
    [SerializeField] private TankTurretType[] _turrets;
    private int _levelTurret = 0;

    private List<GameObject> _spawnPointBullet = new List<GameObject>();

    private void Start()
    {
        ShowTurret(_levelTurret);
        SpawnBullets();
    }

    private void ShowTurret(int levelTurret)
    {
        _levelTurret = levelTurret;
        for(int i = 0; i < _turrets.Length; i++)
        {
            _turrets[i].gameObject.SetActive(false);
        }

        _turrets[_levelTurret].gameObject.SetActive(true);
        OverwriteSpawnPointBullets(_turrets[_levelTurret]);
    }

    void OverwriteSpawnPointBullets(TankTurretType type)
    {
        _spawnPointBullet.Clear();
        for(int i = 0; i < type.GetSpawnPoint.Length; i++)
        {
            _spawnPointBullet.Add(type.GetSpawnPoint[i]);
        }
    }

    void SpawnBullets()
    {
        for(int i = 0; i < countBullet; i++)
        {
            Bullet bullet = Instantiate(_prefabBullet);
            bullet.gameObject.SetActive(false);
            Bullets.Add(bullet);
        }
    }

    private void Update()
    {
        Shoot();
        TestingLevelTurret();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            for(int i = 0; i < _spawnPointBullet.Count; i++)
            {
                for(int j = 0; j < Bullets.Count; j++)
                {
                    if (!Bullets[j].gameObject.activeSelf)
                    {
                        Bullets[j].transform.position = _spawnPointBullet[i].transform.position;
                        Bullets[j].gameObject.SetActive(true);
                        Bullets[j].GetComponent<Rigidbody2D>().AddForce(transform.up * forceShoot, ForceMode2D.Impulse);
                        break;
                    }
                }
            }
        }
    }

    //----------TESTING----------------//
    void TestingLevelTurret()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_levelTurret < 3)
            {
                _levelTurret++;
                ShowTurret(_levelTurret);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_levelTurret > 0)
            {
                _levelTurret--;
                ShowTurret(_levelTurret);
            }
        }
    }

}
