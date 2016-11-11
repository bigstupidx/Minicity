using UnityEngine;
using System.Collections;

public class pressedControl : MonoBehaviour {

	public UIButton[] buttons;

	public void ChangeState(int b){
		for (int i = 0; i < buttons.Length; i++) {
			buttons [i].SetState (UIButtonColor.State.Normal, true);
			buttons [i].GetComponent<BoxCollider> ().enabled = true;
		}

		//buttons [b].SetState (UIButtonColor.State.Pressed, true);
		buttons [b].SetState(UIButtonColor.State.Pressed, true);
		buttons[b].GetComponent<BoxCollider> ().enabled = false;

	}
}
