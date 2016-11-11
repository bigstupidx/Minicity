using UnityEngine;
using System.Collections;

public class BankGame2Trigger : MonoBehaviour {

	public BankGame2 controller;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Scenery" && other.tag != "Player") {
			//obtener datos de billete
			int i = other.GetComponent<BillProps> ().id;
			Vector3 pos = controller.initialPositions [i];

			if (other.GetComponent<BillProps> ().enabled) {
				Vector3 newPos = new Vector3 (transform.position.x, transform.position.y + 0.01f, transform.position.z);
				//desactivar billete y moverlo a la posicion indicada
				controller.EnableBill (i, false);
				controller.MoveBill (i, newPos);
				//sumar el valor del billete a la suma de esta ronda
				Debug.Log(other.GetComponent<BillProps> ().value);
				controller.sum += other.GetComponent<BillProps> ().value;
				Debug.Log (controller.sum);
				//actualizar la cantidad de billetes sumados
				controller.billCount++;
				//desactiva el trigger
				GetComponent<BoxCollider> ().enabled = false;
			};

			//si se sumaron todos los billetes, terminar ronda
			if (controller.billCount == controller.billsToAdd) {
				controller.EndRound ();
			};
		};
	}
}
