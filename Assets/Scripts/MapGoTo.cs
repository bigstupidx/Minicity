using UnityEngine;
using System.Collections;

public class MapGoTo : MonoBehaviour {
	public Transform gotoPosition;
	Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	public void executeGoTo(){
		//player.position = gotoPosition.position;
		//player.rotation = gotoPosition.rotation;
		player.GetComponent<NavMeshAgent> ().Warp (gotoPosition.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
