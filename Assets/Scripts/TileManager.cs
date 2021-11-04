using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private float _zSpawn = 50;
    [SerializeField] private float tileLength = 50;


    
    void Start()
    {
        //GameObject tile = ObjectPooler.instance.GetPooledObject();
        //tile.SetActive(true);

        // tile.transform.position = transform.forward * _zSpawn;
        // _zSpawn += tileLength;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
