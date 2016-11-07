using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AC;

public class BankGame2 : BankGame_Base {

	public int rounds; //cantidad de rondas a jugar
	public int billsToAdd; //cantidad de billetes a sumar
	public int [] roundValues; //valores para cada ronda
	public GameObject [] triggers = new GameObject[3];
	public AudioSource[] sources;

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
				RestoreBills ();
				for (int i = 0; i < totalBills; i++) {
					EnableBill (i, true);
				};
			};

			if (Input.GetKeyDown (KeyCode.K))
			{
				EndGame (5,3);
				count = 0;
				sum = 0;
				billCount = 0;
			};
		}
	}

	public void CalculateRounds()
	{
		GenerateBills ();
		count = 0;
		randomGenerate = false;
		billsToAdd = triggers.Length;
		for (int i = 0; i < rounds; i++) {
			CalculateRound (i);
			taskList.GetComponent<TaskList> ().AddTask (roundValues[i].ToString());
		};
		AC.LocalVariables.SetIntegerValue (6, roundValues[count]);
		taskList.GetComponent<TaskList> ().CreateTasks ();
		taskList.SetActive (true);
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

	public void EndRound()
	{
		//complete current round
		if (sum == roundValues [count]) 
		{
			taskList.GetComponent<TaskList> ().CompleteTask(count);
			sources [0].Play ();
			Debug.Log ("Finished round " + (count + 1));
			AC.LocalVariables.SetIntegerValue (7, AC.LocalVariables.GetIntegerValue (7) + 1);
		} 
		else 
		{
			Debug.Log ("Wrong answer!");
			sources [1].Play ();
		}
		count++;

		//checks if there are rounds left
		if (count < rounds)
		{
			//sets next round
			RestoreBills ();
			sum = 0;
			billCount = 0;
			AC.LocalVariables.SetIntegerValue (6, roundValues [count]);
			Debug.Log ("Round " + (count + 1));
		}
		else
		{
			//ends game
			Debug.Log ("Game over");
			EndGame (5,3);
			taskList.SetActive (false);
			gameUI.SetScore (AC.LocalVariables.GetIntegerValue (7));
			PlayerPrefs.SetInt ("BankGame2", AC.LocalVariables.GetIntegerValue (7));
			//int[] scores = GetScores ();
			//taskList.GetComponent<TaskList> ().Finish (scores);
		}

	}

	public override void RestoreBills()
	{
		base.RestoreBills ();
		for (int i = 0; i < totalBills; i++) 
		{
			EnableBill (i, true);
		};
		foreach(GameObject t in triggers)
		{
			t.GetComponent<BoxCollider> ().enabled = true;
		}
	}
}
