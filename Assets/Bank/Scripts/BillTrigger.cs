using UnityEngine;
using System.Collections;
using AC;

public class BillTrigger : MonoBehaviour {
	public Game1 controller;

	void OnTriggerStay(Collider other){
		int i = other.GetComponent<BillProps> ().id;
		Vector3 pos = other.GetComponent<BillProps> ().initialPosition;
		if (Input.GetMouseButtonUp (0)) {
			if (other.tag == this.tag) {
				Debug.Log ("hola");
			} else {
				controller.restoreBill (i, pos);
			}
		};
	}
}
