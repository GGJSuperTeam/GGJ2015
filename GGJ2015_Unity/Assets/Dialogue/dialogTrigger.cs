using UnityEngine;
using System.Collections;

public class colourTrigger : MonoBehaviour {

    public float r = -1.0f;
    public float g = -1.0f;
    public float b = -1.0f;


    void OnTriggerEnter2D(Collider2D other) {
        if (r < 0)
            r = Random.value;
        if (g < 0)
            g = Random.value;
        if (b < 0)
            b = Random.value;
        other.gameObject.renderer.material.color = new Color(r, g, b);
    }
}
