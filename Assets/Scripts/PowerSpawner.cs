using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    public GameObject objekSenter;

    private void OnEnable() {
        if(GameManager.Instance.senterCanSpawn == true){
            if(Random.value > 0.2){
                objekSenter.SetActive(true);
                GameManager.Instance.senterCanSpawn = false;
            }
        }
    }
}
