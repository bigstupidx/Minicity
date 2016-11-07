using UnityEngine;
using System.Collections;
using AC;

public class QuestionController : MonoBehaviour {
	//0: question
	//1 - 4: answers
	public string[] question1;
	public string[] question2;
	UIButton submit;
	public int[] correctAnswer;
	[HideInInspector]
	public int selectedAnswer;
	[HideInInspector]
	public int index;
	Transform root;
	int score;
	public int checkVariableAC; //variable en AC para chequear si las preguntas se estan mostrando
	public int scoreAC; //variable en AC para marcar correcto o equivocado pregunta1
	public AudioSource[] question1Audio;
	public AudioSource[] question2Audio;
	public AudioSource[] rightWrong;

	// Use this for initialization
	void Awake () {
		Launch ();
	}

	public void SubmitAnswers() //submit
	{
		if (selectedAnswer != 0) 
		{
			float scoreAssist;
			if (selectedAnswer == correctAnswer [index]) 
			{
				score++;
				//rightWrong [0].Play ();
				StartCoroutine (PlayAudio (rightWrong [0]));
			} 
			else 
			{
				//rightWrong [1].Play ();
				StartCoroutine (PlayAudio (rightWrong [1]));
			}
			if (index < 1) 
			{
				index++;
				LoadQuestion ();
			} 
			else 
			{
				scoreAssist = score * 3;
				score = (int)Mathf.Floor (scoreAssist / 2);
				EndGame ();
			}
		}
	}

	public void LoadQuestion() //Carga info del questionpanel
	{
		root.FindChild ("Answer1").GetComponent<UIToggle> ().Set (false);
		root.FindChild ("Answer2").GetComponent<UIToggle> ().Set (false);
		root.FindChild ("Answer3").GetComponent<UIToggle> ().Set (false);
		if (index == 0) 
		{
			root.FindChild ("Question").GetComponent<UILabel> ().text = question1[0];
			root.FindChild ("Answer1").transform.FindChild ("Label").GetComponent<UILabel> ().text = question1 [1];
			root.FindChild ("Answer2").transform.FindChild ("Label").GetComponent<UILabel> ().text = question1 [2];
			root.FindChild ("Answer3").transform.FindChild ("Label").GetComponent<UILabel> ().text = question1 [3];
		}
		if (index == 1) 
		{
			root.FindChild ("Question").GetComponent<UILabel> ().text = question2[0];
			root.FindChild ("Answer1").transform.FindChild ("Label").GetComponent<UILabel> ().text = question2 [1];
			root.FindChild ("Answer2").transform.FindChild ("Label").GetComponent<UILabel> ().text = question2 [2];
			root.FindChild ("Answer3").transform.FindChild ("Label").GetComponent<UILabel> ().text = question2 [3];
		}
		selectedAnswer = 0;
	}

	public void SelectAnswer(GameObject g) //asigna respuesta seleccionada de los checkbox
	{
		string s = g.name;
		selectedAnswer = int.Parse (s.Substring(s.Length-1));
		if (g.gameObject.GetComponent<UIToggle> ().value) 
		{
			if (index == 0) 
			{
				question1Audio [selectedAnswer].Play ();
			} 
			else if (index == 1) 
			{
				question2Audio [selectedAnswer].Play ();
			}
		};
	}


	public void Launch() //inicializa las preguntas y oculta el panel
	{ 
		this.gameObject.GetComponent<TweenAlpha> ().ResetToBeginning ();
		index = 0;
		score = 0;
		root = transform.FindChild ("Background").GetComponent<Transform>();
		submit = root.FindChild ("Submit").GetComponent<UIButton> ();
		LoadQuestion ();
	}

	void EndGame()
	{
		AC.LocalVariables.SetIntegerValue (scoreAC, score);
		AC.LocalVariables.SetBooleanValue (checkVariableAC, true);
		AC.LocalVariables.SetIntegerValue (12, GetScore ());
		this.gameObject.SetActive (false);
	}

	public void SetVisible(int i) //setea visibilidad
	{
		if (i == 0) 
		{
			GetComponent<TweenAlpha> ().PlayReverse ();
		} 
		else if (i == 1) 
		{
			GetComponent<TweenAlpha> ().PlayForward ();
			if (index == 0) 
			{
				question1Audio [0].Play ();
			}
		}
	}

	IEnumerator PlayAudio(AudioSource source){
		source.Play ();
		yield return new WaitForSeconds (source.clip.length);
		question2Audio [0].Play ();
	}

	public int GetScore(){
		int[] scores = new int[3];
		scores [0] = AC.LocalVariables.GetIntegerValue (8);
		scores [1] = AC.LocalVariables.GetIntegerValue (7);
		scores [2] = AC.LocalVariables.GetIntegerValue (11);
		int finalScore = 0;
		for (int i = 0; i < scores.Length; i++) {
			finalScore += scores [i];
		};
		return (int)Mathf.Floor (finalScore / 3);
	}
}
