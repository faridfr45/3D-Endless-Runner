using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    [Header("Double Score")]
    public PowerUpData doubleScore = new PowerUpData();

    [Header("Flashlight")]
    public GameObject modelSenter;
    public PowerUpData senter = new PowerUpData();

    private void Update() {
        if(doubleScore.isActive){
            doubleScore.timer -= Time.deltaTime;
            
            if(doubleScore.timer <= 0){
                doubleScore.isActive = false;
                GameManager.Instance.scoreRate /= 2;
                doubleScore.timer = 0;
            }
        }

        if(senter.isActive){
            senter.timer -= Time.deltaTime;
            
            if(senter.timer <= 0){
                senter.isActive = false;
                modelSenter.SetActive(false);
                senter.timer = 0;
                GameManager.Instance.senterCanSpawn = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "DoubleScore"){
            other.gameObject.SetActive(false);
            DoubleScore();
        }
        if(other.transform.tag == "Senter"){
            other.gameObject.SetActive(false);
            Senter();
        }
    }

    private void DoubleScore(){
        SoundManager.Instance.Play("Power");
        if(!doubleScore.isActive){
            GameManager.Instance.scoreRate *= 2;
            doubleScore.isActive = true;
        }
        doubleScore.timer += doubleScore.duration;

        if(doubleScore.timer > doubleScore.duration)
            doubleScore.timer = doubleScore.duration;
    }

    private void Senter(){
        SoundManager.Instance.Play("Power");
        if(!senter.isActive){
            modelSenter.SetActive(true);
            senter.isActive = true;
        }
        senter.timer += doubleScore.duration;

        if(senter.timer > senter.duration)
            senter.timer = senter.duration;
    }

    [System.Serializable]
    public class PowerUpData
    {
        public float duration = 8f;
        public float timer;
        public bool isActive;
    }
}
