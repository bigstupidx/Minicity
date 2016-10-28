using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	Transform _starsSign;
	public Minigame minigame;
	MainController m;

	// Use this for initialization
	void Start () {
		m = GameObject.FindGameObjectWithTag ("MainController").GetComponent<MainController> ();
		_starsSign = transform.FindChild ("Stars");
	}

	public void ShowStars(){
		if(_starsSign == null)
			_starsSign = transform.FindChild ("Stars");
		_starsSign.transform.localScale = new Vector3 (1f, minigame.score, 1f);
	}

	void EnterBuiding(){
		print ("launching");
		m.LaunchScene (this);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
