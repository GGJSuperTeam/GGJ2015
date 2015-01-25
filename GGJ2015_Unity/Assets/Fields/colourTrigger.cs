using UnityEngine;
using System.Collections;

public class randomColourTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;
        other.gameObject.renderer.material.color = new Color(r, g, b);
    }
}
