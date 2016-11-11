using UnityEngine;
using System.Collections;

public class aNumber : MonoBehaviour {
	public int answerNumber;


	public void onClick(){
		GameObject.FindGameObjectWithTag ("Quiz").GetComponent<Quiz> ().SetAlternative2 (answerNumber);
		Debug.Log("hola mundo");
	}
}
