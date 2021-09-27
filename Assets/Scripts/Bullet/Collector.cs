using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collector : MonoBehaviour
{
    public BulletPool[] pools;

    public static Action<GameObject> ReadyToBackPool;



    private void OnEnable()
    {
        ReadyToBackPool += SendToPoolType;
    }
    private void OnDisable()
    {
        ReadyToBackPool -= SendToPoolType;
    }

    public void SendToPoolType(GameObject _bullet)
    {
        switch (_bullet.GetComponent<TypeBullet>().typeBullet)
        {
            case ETypeBullet.High:
                pools[0].StoreBullet(_bullet);
                break;
            case ETypeBullet.Mid:
                pools[1].StoreBullet(_bullet);
                break;
            case ETypeBullet.Low:
                pools[2].StoreBullet(_bullet);
                break;
            case ETypeBullet.Player:
                pools[3].StoreBullet(_bullet);
                break;
            default:
                break;
        }
    }
}
