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
		if(tasks != null && tasks.Length > 0)
			CreateTasks ();
		/*AddTask ("hola");
		AddTask ("bola");
		AddTask ("como");
		AddTask ("estas");
		CreateTasks ();*/
	}

	public void BackToMap(){
		GameObject.FindGameObjectWithTag ("MainController").GetComponent<MainController> ().BackToMap ();
	}

	public void CreateTasks(){
		tasksGUI = new ArrayList ();
		for (int i = 0; i < tasks.Length; i++) {
			GameObject g = (GameObject)Instantiate (taskGUIPrefab);
			g.transform.parent = transform.FindChild ("Camera/PanelTasks");
			g.transform.localScale = Vector3.one;
			g.transform.localPosition = new Vector3 (background.transform.localPosition.x - 445f, 670f - 85f * i, 0f);
			g.GetComponent<TaskGUI> ().label.text = tasks [i].nameTask;
			tasksGUI.Add (g.GetComponent<TaskGUI>());
		}
		background.bottomAnchor.absolute = - (tasks.Length * 85 + 70);
	}

	public void AddTask(string nameTask){
		int lenght = 0;
		if(tasks != null)
			lenght = tasks.Length + 1;
		Task[] temp = new Task[lenght];
		for (int i = 0; i < tasks.Length; i++) {
			temp [i] = tasks [i];
		}
		Task t = new Task ();
		t.nameTask = nameTask;
		temp [temp.Length - 1] = t;
		tasks = temp;
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

		stars = Mathf.FloorToInt (finalScore);
		print ("score: " + stars);
		MainController m = GameObject.FindGameObjectWithTag ("MainController").GetComponent<MainController>();
		m.SaveScore (stars);
		panelFinish.SetActive (true);
	}

	public void NullToFinish()
	{
		Finish (null);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
