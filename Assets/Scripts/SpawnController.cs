using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private bool endGame = false;

    [SerializeField]
    private GameObject[] spawnObjects;

    [SerializeField]
    private float spawnRate = 1f;

    [SerializeField]
    private float firstSpawnDelay = 0f;

    
    private Vector3 spawnPoint;

    private bool IsThereAtLeastOneObjectToSpawn
    {
        get
        {
            bool result = false;

            for (int i = 0; i < spawnObjects.Length; i++)
            {
                result = spawnObjects[i] != null;

                if (result)
                {
                    break;
                }
            }

            return result;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        if (spawnObjects.Length > 0 && IsThereAtLeastOneObjectToSpawn)
        {
            InvokeRepeating("SpawnObject", firstSpawnDelay, spawnRate);
        }
    }
    private void OnEnable()
    {
        if(!endGame) Player.OnPlayerDied += StopSpawning;

    }
    private void OnDisable()
    {
        Player.OnPlayerDied -= StopSpawning;
    }
    private void SpawnObject()
    {
        GameObject spawnGO = spawnObjects[Random.Range(0, spawnObjects.Length)];

        if (spawnGO != null)
        {
            spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(
                Random.Range(0F, 1F), 1F, transform.position.z));

            GameObject instance = Instantiate(spawnGO, spawnPoint, Quaternion.identity);
        }
    }

    private void StopSpawning(bool _endgame)
    {
        endGame = _endgame;
        
        CancelInvoke();
    }
}