using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AC;

public class BankGame2 : BankGame_Base {

	public int rounds; //cantidad de rondas a jugar
	public int billsToAdd; //cantidad de billetes a sumar
	public int [] roundValues; //valores para cada ronda
	public GameObject [] triggers = new GameObject[3];

	[HideInInspector]
	public int count; //cuenta la ronda actual
	[HideInInspector]
	public int sum; //suma de los tres valores
	[HideInInspector]
	public int billCount; //billetes ingresados

	List <int> billValues = new List<int>(); //lista de valores de los distintos billetes

	void Start () {
		//inicializa variables
		totalBills = billsArray.Length;
		roundValues = new int[rounds];
		initialPositions = new Vector3[totalBills];
		addDistance = new Vector3 (distance, 0, 0);
	}

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

			if (Input.GetKeyDown (KeyCode.K))
			{
				endGame (5,3);
				count = 0;
				sum = 0;
				billCount = 0;
			};
		}
	}

	public void CalculateRounds()
	{
		generateBills ();
		count = 0;
		randomGenerate = false;
		billsToAdd = triggers.Length;
		for (int i = 0; i < rounds; i++) {
			CalculateRound (i);
		};
		AC.LocalVariables.SetIntegerValue (6, roundValues[count]);
	}

	public void CalculateRound(int j)
	{
		billValues.Clear ();
		for (int i = 0; i < billsArray.Length; i++) 
		{
			billValues.Add(billsArray[i].GetComponent<BillProps>().value);
		};

		for (int i = 0; i < billsToAdd; i++) 
		{
			int helper = Random.Range (0, billValues.Count);
			roundValues [j] += billValues [helper];
			billValues.RemoveAt (helper);
		};
	}

	public void endRound()
	{
		//complete current round
		if (sum == roundValues [count]) 
		{
			Debug.Log ("Finished round " + (count + 1));
		} 
		else 
		{
			Debug.Log ("Wrong answer!");
		}
		count++;

		//checks if there are rounds left
		if (count < rounds)
		{
			//sets next round
			restoreBills ();
			sum = 0;
			billCount = 0;
			AC.LocalVariables.SetIntegerValue (6, roundValues [count]);
			Debug.Log ("Round " + (count + 1));
		}
		else
		{
			//ends game
			Debug.Log ("Game over");
			endGame (5,3);
		}

	}

	public override void restoreBills()
	{
		base.restoreBills ();
		for (int i = 0; i < totalBills; i++) 
		{
			enableBill (i, true);
		};
		foreach(GameObject t in triggers)
		{
			t.GetComponent<BoxCollider> ().enabled = true;
		}
	}
}
