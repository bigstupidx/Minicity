using UnityEngine;
using System.Collections;
using AC;
using System.Collections.Generic;

public class Game1 : MonoBehaviour {
	public int totalBills; //cantidad de billetes a generar
	public float distance; //distancia vertical entre un billete y otro
	public GameObject[] billsArray = new GameObject[6]; //arreglo de gameobjects de los distintos billetes
	public Transform finishPoint; //punto de guardado de los billetes correctos

	Vector3[] initialPositions; //posiciones iniciales de los billetes (remover)
	List<GameObject> billsList = new List<GameObject>(); //lista de instancias de billetes
	int count;

	void Start ()
	{
		count = totalBills;
		initialPositions = new Vector3[totalBills];
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
			};
			if (Input.GetKeyDown (KeyCode.K) || count <= 0)
			{
				endGame1 ();
			};
		}
	}

	public void generateBills()
	{
		//posición incial = este gameobject
		Vector3 pos = gameObject.transform.position;
		for (int i = 0; i < totalBills; i++)
		{
			billsList.Add ((GameObject)Instantiate (billsArray [Random.Range (0, 5)], pos, gameObject.transform.rotation));
			pos = new Vector3 (pos.x - distance, pos.y, pos.z);

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
		};
	}

	//Restaura un billete (id) a su posición inicial (pos) almacenada en dicho billete
	public void restoreBill(int id, Vector3 pos)
	{
		billsList [id].GetComponent<Rigidbody> ().MovePosition (pos);
	}

	//
	public void saveBill(int id)
	{
		billsList [id].GetComponent<Rigidbody> ().MovePosition (finishPoint.position);
		count -= 1;
	}

	//elimina todos las instancias de billetes de la lista
	public void endGame1()
	{
		AC.LocalVariables.SetBooleanValue (4, true);
		foreach (GameObject go in billsList){
			Destroy (go);
		}
		Debug.Log (AC.LocalVariables.GetFloatValue(3));
		billsList.Clear ();
		count = totalBills;
	}
}
