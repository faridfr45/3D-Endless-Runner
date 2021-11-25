using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleScore : MonoBehaviour
{
    public float duration;
    private MeshRenderer mer;
    private Collider col;

    private void Start() {
        mer = GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
    }

    private void OnEnable() {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            StartCoroutine(doDoubleScore());
        }
    }
    void Update()
    {
        transform.Rotate(Vector3.up * 50 * Time.deltaTime);
    }

    public IEnumerator doDoubleScore(){
        GameManager.Instance.scoreRate *= 2;

        yield return new WaitForSeconds(duration);

        GameManager.Instance.scoreRate /= 2;
    }
}
