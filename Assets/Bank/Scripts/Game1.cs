using UnityEngine;
using System.Collections;
using AC;

public class Game1 : MonoBehaviour {
	public int totalBills = 6;
	public bool testMode = false;
	public GameObject[] billsArray = new GameObject[6];
	public GameObject bounds;
	Vector3[] initialPositions;
	GameObject[] bills;

	// Use this for initialization
	void Start () {
		bills = new GameObject[totalBills];
		initialPositions = new Vector3[totalBills];
		generateBills ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.R)) {
			restoreBills ();
		};
	}

	public void generateBills(){
		Vector3 pos = gameObject.transform.position;
		for (int i = 0; i < totalBills; i++) {
			if (testMode) {
				bills[i] = (GameObject)Instantiate (billsArray [0], pos, gameObject.transform.rotation);
			} else {
				bills [i] = (GameObject)Instantiate (billsArray [Random.Range (0, 5)], pos, gameObject.transform.rotation);
			};
			pos = new Vector3 (pos.x - 0.15f, pos.y, pos.z);
			bills[i].GetComponent<BillProps>().initialPosition = bills [i].transform.position;
			bills [i].GetComponent<BillProps> ().id = i;
			initialPositions [i] = bills [i].transform.position;
		};
	}

	public void restoreBills(){
		for (int i = 0; i < totalBills; i++) {
			bills [i].transform.position = initialPositions [i];
		};
	}

	public void restoreBill(int id, Vector3 pos){
		bills [id].GetComponent<Rigidbody> ().MovePosition (pos);
	}
}
