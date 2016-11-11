using UnityEngine;
using System.Collections;

public class UIControler : MonoBehaviour {

	public GameObject quiz;
	public GameObject tasklist;

	public GameObject[] popups;
	// Use this for initialization
	void Awake(){
		for (int i = 0; i < popups.Length; i++) {
			popups [i].gameObject.SetActive (false);
		}
	}

	void Start () {
		//tasklist.gameObject.SetActive (false);
		HideTaskList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CallQuiz(){
		quiz.gameObject.SetActive (true);
	}

	public void CallPopUp(int i){
		popups[i].gameObject.SetActive (true);
	}

	public void ShowTaskList(){
		tasklist.transform.FindChild ("Camera/PanelTasks").gameObject.SetActive (true);
	}

	public void HideTaskList(){
		tasklist.transform.FindChild ("Camera/PanelTasks").gameObject.SetActive (false);
	}
}
