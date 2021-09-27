using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]private bool endGame = false;

    [SerializeField]
    private GameObject[] Pools;

    [SerializeField]
    private float spawnRate = 1f;

    [SerializeField]
    private float firstSpawnDelay = 0f;

    
    private Vector3 spawnPoint;

    //private bool IsThereAtLeastOneObjectToSpawn
    //{
    //    get
    //    {
    //        bool result = false;

    //        for (int i = 0; i < Pools.Length; i++)
    //        {
    //            result = Pools[i] != null;

    //            if (result)
    //            {
    //                break;
    //            }
    //        }

    //        return result;
    //    }
    //}

    // Start is called before the first frame update
    private void Awake()
    {
        Player.OnPlayerDied += StopSpawning;
        if (Pools.Length > 0)
        {
            InvokeRepeating("SpawnObject", firstSpawnDelay, spawnRate);
            Debug.Log("Initialized");
        }
       
    }

    private void SpawnObject()
    {
        if (endGame==false)
        {
            spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0F, 1F), 1F, transform.position.z));
            GameObject temp = Pools[Random.Range(0, Pools.Length)].GetComponent<BulletPool>().GetBullet();
            temp.transform.position = spawnPoint;
            temp.SetActive(true);
            Debug.Log("Spawn");
        }
        else
        {
            Player.OnPlayerDied -= StopSpawning;
        }
        

       

    }

    private void StopSpawning(bool _endGame)
    {
        endGame = _endGame;
        //CancelInvoke();

    }
}