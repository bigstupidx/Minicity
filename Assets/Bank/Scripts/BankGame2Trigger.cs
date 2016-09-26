using UnityEngine;
using System.Collections;

public class BankGame2Trigger : MonoBehaviour {

	public BankGame2 controller;

	void OnTriggerEnter(Collider other)
	{
		int i = other.GetComponent<BillProps> ().id;
		//Vector3 pos = other.GetComponent<BillProps> ().initialPosition;
		Vector3 pos = controller.initialPositions[i];
		if(other.GetComponent<BillProps>().enabled)
		{
			Vector3 newPos = new Vector3 (transform.position.x, transform.position.y + 0.1f, transform.position.z);
			controller.enableBill (i, false);
			controller.moveBill (i, newPos);
	};
	}
}
