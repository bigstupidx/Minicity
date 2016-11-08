using UnityEngine;
using System.Collections;
using AC;

public class GrabBill : MonoBehaviour {

	public float height;
	private AudioSource _sound;

	void Awake(){
		_sound = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 newPos = new Vector3 (transform.position.x, height, transform.position.z);

		if (GetComponent<Moveable_PickUp> ().isHeld) {
			transform.position = newPos;
		}
	}

	void OnMouseDown(){
		_sound.Play ();
	}
}
