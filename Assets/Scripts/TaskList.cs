using UnityEngine;
using System.Collections;

public class TaskList : MonoBehaviour {
	public Task[] tasks;
	//public int sceneIndex;
	public GameObject taskGUIPrefab;
	public ArrayList tasksGUI;
	public UISprite background;
	GameObject panelFinish;
	int stars = 0;
	// Use this for initialization
	void Start () {
		panelFinish = transform.FindChild ("Camera/PanelFinish").gameObject;
		tasksGUI = new ArrayList ();
		for (int i = 0; i < tasks.Length; i++) {
			GameObject g = (GameObject)Instantiate (taskGUIPrefab);
			g.transform.parent = transform.FindChild ("Camera/PanelTasks");
			g.transform.localScale = Vector3.one;
			g.transform.localPosition = new Vector3 (875f, 670f - 85f * i, 0f);
			tasksGUI.Add (g.GetComponent<TaskGUI>());
		}
		background.bottomAnchor.absolute = - (tasks.Length * 85 + 70);


	}

	public void CompleteTask(int index){
		tasks [index].Complete ();
		((TaskGUI)tasksGUI [index]).toggle.value = true;
	}

	public void Finish(){
		//to do: evaluacion

		MainController m = GameObject.FindGameObjectWithTag ("MainController").GetComponent<MainController>();
		m.SaveScore (stars);
		panelFinish.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
