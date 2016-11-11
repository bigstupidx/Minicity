using UnityEngine;
using System.Collections;

public class BuildingName : MonoBehaviour {
	public string myName = "";
	public AudioClip audioclip;
	public Transform parent;
	public UILabel nameLabel;
	UIButton b;
	Transform player;
	// Use this for initialization
	void Start () {
	}

	public void initialize(Transform t){
		b = GetComponent<UIButton> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		parent = t;
		myName = t.name;
		nameLabel.text = myName;
		audioclip = Resources.Load(myName) as AudioClip;
	}

	public void clicked(){
		Camera.main.GetComponent<AudioSource> ().PlayOneShot (audioclip);
	}
	
	// Update is called once per frame
	void Update () {
		b.isEnabled = (Vector3.Distance (player.position, parent.position) < 50f) && (Vector3.Angle(Camera.main.transform.forward, parent.position - Camera.main.transform.position) < 90f);
		if (parent != null) {
			//print (Camera.main.WorldToScreenPoint (parent.position));
			transform.localPosition = new Vector3 ((Camera.main.WorldToScreenPoint (parent.position).x - Screen.width / 2f) * 2.5f, (Camera.main.WorldToScreenPoint (parent.position).y - Screen.height / 2f) * 2.5f, Camera.main.WorldToScreenPoint (parent.position).z);
			transform.localScale = Vector3.one * (1f - (Vector3.Distance (player.position, parent.position) / 50f) * 0.9f);
		}
	}
}
