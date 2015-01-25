using UnityEngine;
using System.Collections;

public class ZSort : MonoBehaviour {
	
    void Start() {
        renderer.sortingOrder = (int)(10 * (-renderer.bounds.center.y + renderer.bounds.size.y / 2));
    }
}
