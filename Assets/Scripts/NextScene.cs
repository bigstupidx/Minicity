using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
	public string sceneName = "Title";
	public float delay = 3f;
	// Use this for initialization
	void Start () {
		if (delay > 0)
			StartCoroutine (NextSceneDelay (delay));
		else
			LoadLevel ();
	}

	IEnumerator NextSceneDelay(float delay){
		yield return new WaitForSeconds (delay);
		LoadLevel ();
	}

	public void LoadLevel(){
		SceneManager.LoadScene(sceneName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
