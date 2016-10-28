using UnityEngine;
using System.Collections;
using AC;

public class GrabBill : MonoBehaviour {

	public float height;
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = new Vector3 (transform.position.x, height, transform.position.z);
		/*if (AC.LocalVariables.GetBooleanValue (9)) {
			transform.position = newPos;
		}*/

		if (GetComponent<Moveable_PickUp> ().isHeld) {
			transform.position = newPos;
		}
	
	}
}
