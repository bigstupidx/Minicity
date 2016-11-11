using UnityEngine;
using System.Collections;

[System.Serializable]
public class Questions{
	public string question;
	public string[] answers;
	public int correctAnswer;

	//Sounds
	public AudioSource questionAudio;
	public AudioSource[] answersAudios;
}
