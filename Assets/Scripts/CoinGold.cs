using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGold : MonoBehaviour
{
    private void OnEnable() {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            GameManager.coinValue++;
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        transform.Rotate(Vector3.up * 50 * Time.deltaTime);
    }
}
