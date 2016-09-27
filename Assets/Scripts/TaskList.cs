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
			g.transform.localPosition = new Vector3 (background.transform.localPosition.x - 445f, 670f - 85f * i, 0f);
			tasksGUI.Add (g.GetComponent<TaskGUI>());
		}
		background.bottomAnchor.absolute = - (tasks.Length * 85 + 70);

	}

	public void CompleteTask(int index){
		tasks [index].Complete ();
		((TaskGUI)tasksGUI [index]).toggle.value = true;
	}

	public void Finish(int[] scores){
		//to do: evaluacion
		float finalScore = 0f;
		if(scores != null)
			for (int i = 0; i < scores.Length; i++)
				finalScore += scores [i];

		float taskScore = 0f;
		for (int i = 0; i < tasks.Length; i++) {
			taskScore += tasks [i].completed ? 1 : 0;
		}
		taskScore = 3f * taskScore / tasks.Length;
		finalScore += taskScore;
		if(scores != null)
			finalScore = finalScore / (scores.Length + 1);

		stars = Mathf.RoundToInt (finalScore);
		print ("score: " + stars);
		MainController m = GameObject.FindGameObjectWithTag ("MainController").GetComponent<MainController>();
		m.SaveScore (stars);
		panelFinish.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
