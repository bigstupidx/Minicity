using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AC;

public class BankGame2 : BankGame_Base {

	public int rounds; //cantidad de rondas a jugar
	int count; //cuenta la ronda actual
	int sum; //suma de los tres valores
	int [] roundValues; //valores para cada ronda
	List <int> billValues;

	// Use this for initialization
	void Start () {
		totalBills = billsArray.Length;
		roundValues = new int[rounds];
		initialPositions = new Vector3[totalBills];
		addDistance = new Vector3 (distance, 0, 0);
		CalculateRounds ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!AC.LocalVariables.GetBooleanValue (5)) 
		{
			//Temporal: con tecla R, todos los billetes vuelven a su lugar. Remover después
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				restoreBills ();
				for (int i = 0; i < totalBills; i++) {
					enableBill (i, true);
				};
			};
			if (Input.GetKeyDown (KeyCode.K) || count <= 0)
			{
				endGame (5,3);
			};
		}
	}

	void CalculateRounds(){
		for (int i = 0; i < billsArray.Length; i++) {
			billValues.Add(billsArray[i].GetComponent<BillProps>().value);
		};
		for (int i = 0; i < rounds; i++) {
			int helper = Random.Range (0, billValues.Count - 1);
			roundValues [i] = billValues [helper];
			billValues.RemoveAt (helper);
		};
	}

}
