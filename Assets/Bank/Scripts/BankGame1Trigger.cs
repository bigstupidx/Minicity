using UnityEngine;
using System.Collections;
using AC;

public class BankGame1Trigger : MonoBehaviour 
{
	public BankGame1 controller;
	public AudioSource wellDone;

	void OnTriggerStay(Collider other)
	{
		if (other.tag != "Scenery" && other.tag != "Player") {
			int i = other.GetComponent<BillProps> ().id;
			//Vector3 pos = other.GetComponent<BillProps> ().initialPosition;
			Vector3 pos = controller.initialPositions [i];
			if (!Input.GetMouseButton (0)) {
				if (other.tag == this.tag) {
					controller.SaveBill (i);
					wellDone.Play ();
				} else {
					controller.MoveBill (i, pos);
					GetComponent<AudioSource> ().Play ();
				};
			};
		};
	}
}
