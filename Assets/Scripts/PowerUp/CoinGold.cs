using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGold : MonoBehaviour
{   
    private MeshRenderer mer;
    private Collider col;

    private void Awake() {
        mer = this.GetComponent<MeshRenderer>();
        col = this.GetComponent<Collider>();
    }

    private void OnEnable() {
        if(mer.enabled == false){
            mer.enabled = true;
            col.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            GameManager.Instance.coinValue++;
            SoundManager.Instance.Play("Coin");
            mer.enabled = false;
            col.enabled = false;
        }
    }
    void Update()
    {
        transform.Rotate(Vector3.up * 50 * Time.deltaTime);
    }
}
