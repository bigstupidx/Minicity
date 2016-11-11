using UnityEngine;
using System.Collections;

public class PanelBuilding : MonoBehaviour {
	public GameObject panelBuildingGUIPrefab;
	public Transform panelRoot;
	// Use this for initialization
	void Start () {
		GameObject[] buildings = GameObject.FindGameObjectsWithTag ("Building");
		foreach (GameObject b in buildings) {
			GameObject g = (GameObject)Instantiate (panelBuildingGUIPrefab);
			g.transform.parent = panelRoot;
			g.transform.localScale = Vector3.one;
			g.GetComponent<BuildingName> ().initialize (b.transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
