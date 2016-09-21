using UnityEngine;
using System.Collections;

public class Game1 : MonoBehaviour {
	public int totalBills = 5;
	public GameObject[] billsArray = new GameObject[6];

	// Use this for initialization
	void Start () {
		generateBills ();
	}

	public void generateBills(){
		Vector3 pos = gameObject.transform.position;
		for (int i = 0; i < totalBills; i++) {
			Instantiate (billsArray [Random.Range (0, 5)], pos, gameObject.transform.rotation);
			pos = new Vector3 (pos.x - 0.1f, pos.y, pos.z);
		};
	}

}
