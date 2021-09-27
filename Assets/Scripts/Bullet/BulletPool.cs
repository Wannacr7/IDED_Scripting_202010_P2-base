using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject baseBullet;
    [SerializeField] public int poolSize;
    

    private List<GameObject> bulletPool = new List<GameObject>();

    private void Awake()
    {
        if (baseBullet != null)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bulletInstance = Instantiate<GameObject>(baseBullet);
                //bulletInstance.SetCanBeRecycled();
                StoreBullet(bulletInstance);
            }
        }
        
    }

    public GameObject GetBullet()
    {
        GameObject bullet = null;

        if (bulletPool.Count > 0)
        {
            bullet = bulletPool[0];
            bulletPool.RemoveAt(0);
            //bullet.gameObject.transform.position = _position;
            //bullet.SetActive(true);
            
        }
        else
        {
            bullet = Instantiate<GameObject>(baseBullet);
        }
        
        return bullet;
    }
   
    public void StoreBullet(GameObject targetBullet)
    {
        

        bulletPool.Add(targetBullet);
        targetBullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
        targetBullet.gameObject.SetActive(false);
        targetBullet.transform.position = transform.position;
    }
    
}
