using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    [Header("Double Score")]
    public PowerUpData doubleScore = new PowerUpData();

    private void Update() {
        if(doubleScore.isActive){
            doubleScore.timer -= Time.deltaTime;
            
            if(doubleScore.timer <= 0){
                doubleScore.isActive = false;
                GameManager.Instance.scoreRate /= 2;
                doubleScore.timer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "DoubleScore"){
            other.gameObject.SetActive(false);
            DoubleScore();
        }
    }

    private void DoubleScore(){
        if(!doubleScore.isActive){
            GameManager.Instance.scoreRate *= 2;
            doubleScore.isActive = true;
        }
        doubleScore.timer += doubleScore.duration;

        if(doubleScore.timer > doubleScore.duration)
            doubleScore.timer = doubleScore.duration;
    }

    [System.Serializable]
    public class PowerUpData
    {
        public float duration = 8f;
        public float timer;
        public bool isActive;
    }
}
