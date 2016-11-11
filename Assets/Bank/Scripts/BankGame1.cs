using UnityEngine;
using System.Collections;
using AC;
using System.Collections.Generic;

public class BankGame1 : BankGame_Base 
{
	public Transform finishPoint; //punto de guardado de los billetes correctos

	void Start ()
	{
		count = totalBills;
		initialPositions = new Vector3[totalBills];
		addDistance = new Vector3 (-distance, 0, 0);
		randomGenerate = true;
		//GenerateBills ();
	}

	void Update()
	{
		if (!AC.LocalVariables.GetBooleanValue (4)) 
		{
			//Temporal: con tecla R, todos los billetes vuelven a su lugar. Remover después
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				RestoreBills ();
				count = totalBills;
			};
			if (Input.GetKeyDown (KeyCode.K) || count <= 0)
			{
				EndGame (4,3);
				float score = AC.LocalVariables.GetFloatValue (3); //time
				int stars = 0;
				if (score > 20) {
					stars = 1;
					AC.LocalVariables.SetIntegerValue (8, stars);
					PlayerPrefs.SetInt ("BankGame1", stars);
				} 
				else if (score < 20 && score > 10) {
					stars = 2;
					AC.LocalVariables.SetIntegerValue (8, stars);
					PlayerPrefs.SetInt ("BankGame1", stars);
				} 
				else if (score >= 0 && score < 10) {
					stars = 3;
					AC.LocalVariables.SetIntegerValue (8, stars);
					PlayerPrefs.SetInt ("BankGame1", stars);
				}
				gameUI.SetScore (stars);
				count = totalBills;
			};
		}
	}

	public void SaveBill(int id)
	{
		billsList [id].GetComponent<Rigidbody> ().MovePosition (finishPoint.position);
		count -= 1;
	}
}
