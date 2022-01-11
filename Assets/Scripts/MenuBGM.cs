using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBGM : MonoBehaviour
{
    public GameObject bgm;

    private void Start() {
        if(GameObject.Find("BGM(Clone)") == null){
            Instantiate(bgm);
        }
    }
}
