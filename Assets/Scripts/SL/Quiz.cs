using UnityEngine;
using System.Collections;

public class Quiz : MonoBehaviour {
	public Questions[] questions;
	public GameObject qGUIPrefab;
	public ArrayList qGUI;

	public TaskList tasklist;

	private int currentQuestion = 0;
	private int alternativeSelected = -1;

	[HideInInspector]
	public int quizScore = 0;

	public void Submit(){
		if (alternativeSelected != -1) {
			if (questions [currentQuestion].correctAnswer == alternativeSelected) 
				quizScore++;
			alternativeSelected = -1;

			if ((currentQuestion + 1) <= questions.Length - 1)
				ShowQuestion (currentQuestion + 1);
			else
				QuizEnd ();
			
		}
	}
	void Awake(){
		
	}
	// Use this for initialization
	void Start () {
		QuizStart ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (alternativeSelected);
	}

	void InitQuiz(){
		if (questions.Length > 0) {
			qGUI = new ArrayList ();

			for (int i = 0; i < questions.Length; i++) {
				GameObject p = (GameObject)Instantiate (qGUIPrefab);
				p.GetComponent<QuestionsGui> ().questionLabel.text = questions [i].question;
				p.GetComponent<QuestionsGui> ().answerLabel [0].text = questions [i].answers [0];
				p.GetComponent<QuestionsGui> ().answerLabel [1].text = questions [i].answers [1];
				p.GetComponent<QuestionsGui> ().answerLabel [2].text = questions [i].answers [2];
				p.transform.parent = transform.FindChild ("Camera/Panel");
				p.transform.localScale = Vector3.one;
				//p.transform.localPosition = new Vector3 (-3740f, 1258f, -10f);
				p.transform.localPosition = new Vector3 (0f, 100f, -10f);
				qGUI.Add (p.GetComponent<QuestionsGui> ());
			}
		}
	}

	public void SetAlternative(GameObject a){
		//Debug.Log (gameObject.name);
		alternativeSelected = a.GetComponent<aNumber>().answerNumber;
		((QuestionsGui)qGUI [currentQuestion]).gameObject.GetComponent<pressedControl> ().ChangeState (alternativeSelected);

		questions [currentQuestion].answersAudios[alternativeSelected].Play (22050);
		Debug.Log (alternativeSelected);
	}

	public void SetAlternative2(int b){
		if (questions [currentQuestion].questionAudio.isPlaying == false) {
			alternativeSelected = b;
			((QuestionsGui)qGUI [currentQuestion]).gameObject.GetComponent<pressedControl> ().ChangeState (alternativeSelected);

			questions [currentQuestion].answersAudios [alternativeSelected].Play (22050);
			Debug.Log (alternativeSelected);
		}
	}

	void ShowQuestion(int q){
		for (int i = 0; i < questions.Length; i++) {
			((QuestionsGui)qGUI [i]).gameObject.SetActive (false);
		}
		currentQuestion = q;
		((QuestionsGui)qGUI [q]).gameObject.SetActive (true);

		questions [currentQuestion].questionAudio.Play (22050);
		//StartCoroutine (PlayAudio (questions [currentQuestion].questionAudio));
	}
		
	void QuizStart(){
		InitQuiz ();
		ShowQuestion (0);
	}

	void QuizEnd(){
		Debug.Log ("Terminaste con un puntaje de: " + quizScore);
		int finalScore = (quizScore > 0) ? quizScore + 1 : 0;
		//GameObject.FindGameObjectWithTag ("TaskList").GetComponent<TaskList> ().Finish (new int[1]{finalScore});
		tasklist.Finish(new int[1]{finalScore});

		gameObject.GetComponent<TweenAlpha>().PlayReverse();

		if (gameObject.GetComponent<TweenAlpha>().value == 0)
			gameObject.SetActive (false);
	}
		
}
