using UnityEngine;
using System.Collections;

public class DisplayUI : MonoBehaviour {

	public UILabel [] textList;
	//0 -> game start
	//1 -> finished game! Score:
	//2 -> game over
	//3 -> game 1:
	//4 -> game 2:

	public void SetVisible(int i){
		textList [i].GetComponent<TweenAlpha> ().PlayForward ();
	}

	public void SetInvisible(int i){
		textList [i].GetComponent<TweenAlpha> ().PlayReverse ();
	}

	public void Initialize(){
		for (int i = 0; i < textList.Length; i++) {
			textList [i].GetComponent<TweenAlpha> ().ResetToBeginning ();
		};
	}

	public void SetScore(int score){
		string textScore ="";
		for (int i = 0; i < score; i++) {
			textScore += "*";
		};
		textList[1].text = "Finished game!\nScore: "+textScore;
	}

	public void SetStars(){
		for(int i=0;i<AC.LocalVariables.GetIntegerValue(8);i++){
			textList[3].text += "*";
		};
		for(int i=0;i<AC.LocalVariables.GetIntegerValue(7);i++){
			textList[4].text += "*";
		};
	}
}
