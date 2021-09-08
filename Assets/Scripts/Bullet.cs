using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    const float LifeTime = 2f;

    private void OnEnable()
    {
        StartCoroutine(TimerLife());
    }

    IEnumerator TimerLife()
    {
        yield return new WaitForSeconds(LifeTime);
        gameObject.SetActive(false);
    }
}
