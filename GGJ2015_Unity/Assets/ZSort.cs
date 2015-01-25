using UnityEngine;
using System.Collections;

public class ZSort : MonoBehaviour {
	
	private Vector3 newPos = Vector3.zero;
    private GameObject deer;

    void Start() {
        renderer.sortingOrder = (int)(10 * (-renderer.bounds.center.y + renderer.bounds.size.y / 2));
    }
}
