using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;

    [SerializeField] private Vector3 zoneSize;
    
    [SerializeField] private float spawnTime;

    void Start()
    {
        InvokeRepeating("SpawnPrefab", spawnTime, spawnTime);

        //or
        //int _vateurHasardApperlMethode = Random.Range(3,6);
        //Invoke("CreerShere",_vateurHasardApperlMethode);
    }

    void Update()
    {
        
    }

    void SpawnPrefab()
    {
        GameObject instantiated = Instantiate(Prefab);
        
        //or
        //GameObject nouvelInstance;
        //nouvelInstance = Instantiate(_spehrePrefab);
    

        instantiated.transform.position = new Vector3(
            Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),
            Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2),
            Random.Range(transform.position.z - zoneSize.z / 2, transform.position.z + zoneSize.z / 2)
        );
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, zoneSize);
    }
}
