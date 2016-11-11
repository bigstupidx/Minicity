using UnityEngine;
using System.Collections;

public class PopUpAnimAlpha : MonoBehaviour {

	private AnimatedAlpha _aAlpha;
	public float deltaAlpha;
	public float wait;
	// Use this for initialization
	void Start () {
		_aAlpha = GetComponent<AnimatedAlpha> ();
		_aAlpha.alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (_aAlpha.alpha <= 1) {
			_aAlpha.alpha += deltaAlpha;
		} else {
			//StartCoroutine (WillDeactivate);
		}
	}

	/*
	IEnumerator WillDeactivate(){
		gameObject.SetActive (false);
		yield return new WaitForSeconds (wait);
	}
	*/
}
