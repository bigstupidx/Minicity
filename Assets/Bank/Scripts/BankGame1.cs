using UnityEngine;
using System.Collections;
using AC;
using System.Collections.Generic;

public class BankGame1 : BankGame_Base {
	public Transform finishPoint; //punto de guardado de los billetes correctos
	int count;

	void Start ()
	{
		count = totalBills;
		initialPositions = new Vector3[totalBills];
		addDistance = new Vector3 (-distance, 0, 0);
		//generateBills ();
	}

	void Update()
	{
		if (!AC.LocalVariables.GetBooleanValue (4)) 
		{
			//Temporal: con tecla R, todos los billetes vuelven a su lugar. Remover después
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				restoreBills ();
				count = totalBills;
			};
			if (Input.GetKeyDown (KeyCode.K) || count <= 0)
			{
				endGame (3,4);
				count = totalBills;
			};
		}
	}

	public void saveBill(int id)
	{
		billsList [id].GetComponent<Rigidbody> ().MovePosition (finishPoint.position);
		count -= 1;
	}
}
