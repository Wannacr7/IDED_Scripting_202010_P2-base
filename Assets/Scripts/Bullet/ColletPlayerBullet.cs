using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletPlayerBullet : MonoBehaviour
{
    private void Update()
    {
        if (gameObject)
        {
            Invoke("CollectBullet", 10);
        }
    }

    private void CollectBullet()
    {
        Collector.ReadyToBackPool(this.gameObject);
    }
}
