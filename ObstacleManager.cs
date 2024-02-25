using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    
    public Transform spawnPoint;
    public GameObject AsteriodPrefab;
    
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("GeneratedAsteriod", 1.0f, 1.0f);
    }

    // Update is called once per frame
    private void GeneratedAsteriod()
    {
        Vector3 randomPos = new Vector3(Random.Range(-1.5f, 1.5f), spawnPoint.position.y,0);
        Instantiate(AsteriodPrefab, randomPos, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
