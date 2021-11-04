using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;

    private List<GameObject> pooledTile = new List<GameObject>();
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;
    [SerializeField] private int amountToPool = 3;//Tiap tile

    [Header("Spawn")]
    [SerializeField] private float numberOfTiles = 5;
    [SerializeField] private float _zSpawn = 50;
    [SerializeField] private float tileLength = 50;

    [SerializeField] private GameObject[] tilePrefabs;

    private void Awake() {
        if(instance == null)
            instance = this;

    }

    private void Start() {
        for(int i = 0; i < tilePrefabs.Length; i++){
            for(int j = 0; j < amountToPool; j++){
                SpawnTile(i);
            }
        }

        for(int i = 0; i < numberOfTiles; i++){
            if(i == 0){
                pooledTile[0].SetActive(true);
                activeTiles.Add(pooledTile[0]);
            }
            else
                GenerateTile();
        }
        
    }

    private void Update() {
        if(playerTransform.position.z - 35> _zSpawn - (numberOfTiles * tileLength)){
            GenerateTile();
            DeleteTile();
        }
    }

    public GameObject GetPooledObject(){
        int random = Random.Range(1, pooledTile.Count);

        while(pooledTile[random].activeInHierarchy){
            random = Random.Range(1, pooledTile.Count);
        }

        return pooledTile[random];
    }

    public void GenerateTile(){
        GameObject obj = GetPooledObject();
        obj.transform.position = transform.forward * _zSpawn;
        obj.SetActive(true);
        activeTiles.Add(obj);
        _zSpawn += tileLength;
    }

    private void DeleteTile(){
        activeTiles[0].SetActive(false);
        activeTiles.RemoveAt(0);
    }

    public void SpawnTile(int index){
        GameObject obj = Instantiate(tilePrefabs[index], this.transform);
        obj.SetActive(false);
        pooledTile.Add(obj);
    }
}
