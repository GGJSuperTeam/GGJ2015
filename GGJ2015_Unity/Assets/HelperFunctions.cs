using UnityEngine;
using System.Collections;

public class HelperFunctions : MonoBehaviour {

	//returns -1 when to the left, 1 to the right, and 0 for forward/backward
	public static float AngleDir(Vector2 A, Vector2 B)
	{
		return -A.x * B.y + A.y * B.x;
	}
}
