using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] private GameObject[] CharPrefabs;
    [SerializeField] private PlayerController controller;

    private void Start() {
        for(int i = 0; i < CharPrefabs.Length; i++){
            if(i == DataManager.selectedChar){
                CharPrefabs[i].SetActive(true);
                controller.anim = CharPrefabs[i].GetComponent<Animator>();
                break;
            }
        }
    }
}
