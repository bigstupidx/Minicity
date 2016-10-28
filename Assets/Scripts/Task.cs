using UnityEngine;
using System.Collections;

[System.Serializable]
public class Task {
	public string nameTask;
	public string description;
	public bool completed = false;

	public void Complete(){
		completed = true;
	}
}
