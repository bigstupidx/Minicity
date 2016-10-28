using UnityEngine;
using System.Collections;
using AC;
using System.Collections.Generic;

public class BankGame_Base : MonoBehaviour {
	public int totalBills; //cantidad de billetes a generar
	public float distance; //distancia vertical entre un billete y otro
	public GameObject[] billsArray = new GameObject[6]; //arreglo de gameobjects de los distintos billetes
	public GameObject taskList;
	public DisplayUI gameUI;
	public float billHeight;

	[HideInInspector]
	public Vector3 addDistance;
	[HideInInspector]
	public int count;
	[HideInInspector]
	public Vector3[] initialPositions; //posiciones iniciales de los billetes (remover)
	[HideInInspector]
	public List<GameObject> billsList = new List<GameObject>(); //lista de instancias de billetes


	public bool randomGenerate;

	public void GenerateBills()
	{
		//posición incial = este gameobject
		Vector3 pos = gameObject.transform.position;
		for (int i = 0; i < totalBills; i++)
		{
			if (randomGenerate) 
			{
				billsList.Add ((GameObject)Instantiate (billsArray [Random.Range (0, 5)], pos, gameObject.transform.rotation));
			} else if (billsArray.Length == totalBills) 
			{
				billsList.Add ((GameObject)Instantiate (billsArray [i], pos, gameObject.transform.rotation));
			};

			pos += addDistance;

			//guarda propiedades de cada billete (id y posicion inicial)
			billsList [i].GetComponent<BillProps> ().initialPosition = billsList [i].transform.position;
			billsList [i].GetComponent<BillProps> ().id = i;
			billsList [i].GetComponent<GrabBill> ().height = billHeight;

			//posiciones iniciales en arreglo (remover)
			initialPositions [i] = billsList [i].transform.position;
		};
	}

	//Retorna todos los billetes a su posición inicial (almacenada en este gameObject)
	public virtual void RestoreBills()
	{
		for (int i = 0; i < totalBills; i++)
		{
			billsList [i].GetComponent<Moveable_PickUp> ().LetGo ();
			billsList [i].GetComponent<Transform> ().position = initialPositions[i];
			billsList [i].GetComponent<Rigidbody> ().velocity = Vector3.zero;
		};
	}

	//Mueve un billete (id) a una posición determinada (pos)
	public void MoveBill(int id, Vector3 pos)
	{
		billsList [id].GetComponent<Moveable_PickUp> ().LetGo ();
		billsList [id].GetComponent<Rigidbody> ().MovePosition (pos);
		billsList [id].GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}

	//elimina todos las instancias de billetes de la lista
	public void EndGame(int gameVar, int timer)
	{
		AC.LocalVariables.SetBooleanValue (gameVar, true);
		foreach (GameObject go in billsList)
		{
			Destroy (go);
		}
		Debug.Log (AC.LocalVariables.GetFloatValue(timer));
		billsList.Clear ();
	}

	public void EnableBill(int id, bool enable){
		if (enable) {
			billsList [id].GetComponent<BillProps> ().enabled = true;
			billsList [id].GetComponent<Rigidbody> ().isKinematic = false;
		} else if (!enable) {
			billsList [id].GetComponent<BillProps> ().enabled = false;
			billsList [id].GetComponent<Rigidbody> ().isKinematic = true;
		}
	}

	public int[] GetScores(){
		int[] scores = new int[2];
		scores [0] = AC.LocalVariables.GetIntegerValue (8);
		scores [1] = AC.LocalVariables.GetIntegerValue (7);
		return scores;
	}
}

