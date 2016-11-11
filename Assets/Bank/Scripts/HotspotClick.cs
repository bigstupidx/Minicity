using UnityEngine;
using System.Collections;

public class HotspotClick : MonoBehaviour {

	public AudioSource source;

	void OnMouseDown(){
		source.Play ();
	}
}
