using UnityEngine;
using System.Collections;
using AC;
using System.Collections.Generic;

public class BankGame_Base : MonoBehaviour {
	public int totalBills; //cantidad de billetes a generar
	public float distance; //distancia vertical entre un billete y otro
	[HideInInspector]
	public Vector3 addDistance;
	public GameObject[] billsArray = new GameObject[6]; //arreglo de gameobjects de los distintos billetes

	[HideInInspector]
	public Vector3[] initialPositions; //posiciones iniciales de los billetes (remover)
	[HideInInspector]
	public List<GameObject> billsList = new List<GameObject>(); //lista de instancias de billetes

	public void generateBills()
	{
		//posición incial = este gameobject
		Vector3 pos = gameObject.transform.position;
		for (int i = 0; i < totalBills; i++)
		{
			billsList.Add ((GameObject)Instantiate (billsArray [Random.Range (0, 5)], pos, gameObject.transform.rotation));
			pos += addDistance;

			//guarda propiedades de cada billete (id y posicion inicial)
			billsList [i].GetComponent<BillProps> ().initialPosition = billsList [i].transform.position;
			billsList [i].GetComponent<BillProps> ().id = i;

			//posiciones iniciales en arreglo (remover)
			initialPositions [i] = billsList [i].transform.position;
		};
	}

	//Retorna todos los billetes a su posición inicial (almacenada en este gameObject)
	public void restoreBills()
	{
		for (int i = 0; i < totalBills; i++)
		{
			billsList [i].transform.position = initialPositions [i];
			billsList [i].GetComponent<Rigidbody> ().velocity = Vector3.zero;
		};
	}

	//Mueve un billete (id) a una posición determinada (pos)
	public void moveBill(int id, Vector3 pos)
	{
		billsList [id].GetComponent<Rigidbody> ().MovePosition (pos);
		billsList [id].GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}

	//elimina todos las instancias de billetes de la lista
	public void endGame(int gameVar, int timer)
	{
		AC.LocalVariables.SetBooleanValue (4, true);
		foreach (GameObject go in billsList){
			Destroy (go);
		}
		Debug.Log (AC.LocalVariables.GetFloatValue(3));
		billsList.Clear ();
	}

	public void enableBill(int id, bool enable){
		if (enable) {
			billsList [id].GetComponent<BillProps> ().enabled = true;
			billsList [id].GetComponent<Rigidbody> ().isKinematic = false;
		} else if (!enable) {
			billsList [id].GetComponent<BillProps> ().enabled = false;
			billsList [id].GetComponent<Rigidbody> ().isKinematic = true;
		}
	}
}

