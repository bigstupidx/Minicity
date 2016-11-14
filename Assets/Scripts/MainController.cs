using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {
	public bool testing = true;
	public Building[] buildings;
	int _currentSceneIndex = -1;
	Vector3 positionInCity;

	// Use this for initialization
	void OnEnable () {
		#if UNITY_EDITOR
		if (!testing || GameObject.FindObjectsOfType<MainController>().Length > 1) Destroy(gameObject);
		#else
		if(SceneManager.GetActiveScene().name != "Preload") Destroy(gameObject);
		#endif
		DontDestroyOnLoad(gameObject);

		if (SceneManager.GetActiveScene ().name == "Map" && (buildings == null || buildings.Length <= 0)) {
			GetBuildings ();
		}
		if (SceneManager.GetActiveScene ().name == "Map")
			UpdateBuildings ();
	}

	void GetBuildings(){
		buildings = GameObject.FindObjectsOfType<Building> ();
	}

	void UpdateBuildings (){
		foreach (Building b in buildings) {
			b.minigame.score = PlayerPrefs.GetInt ("scoreMinigame" + _currentSceneIndex, 0);
			b.ShowStars ();
		}
	}

	public void LaunchScene(Building b) {
		_currentSceneIndex = -1;
		for (int i = 0; i < buildings.Length; i++) {
			if (buildings [i] == b)
				_currentSceneIndex = i;
		}
		if (_currentSceneIndex < 0)
			print ("The building does not exists");
		else {
			positionInCity = b.transform.position - b.transform.forward * 3f;
			SceneManager.LoadScene (b.minigame.nameMinigame);
		}
	}

	public void OnLevelWasLoaded(int level)
	{
		if (SceneManager.GetActiveScene ().name == "Map" && (buildings == null || buildings.Length <= 0 || buildings [0] == null)) {
			GetBuildings ();
		}
		if (SceneManager.GetActiveScene ().name == "Map") {
			UpdateBuildings ();
			StartCoroutine (repositionPlayer ());
		}
	}

	IEnumerator repositionPlayer(){
		yield return new WaitForEndOfFrame ();
		print ("repositioning");
		if (positionInCity != null && positionInCity != Vector3.zero) {
			print ("repositioning2");
			GameObject.FindGameObjectWithTag ("Player").GetComponent<NavMeshAgent> ().Warp (positionInCity);
		}
	}

	public void SaveScore(int score) { 
		int currentScore = buildings[_currentSceneIndex].minigame.score;
		if (currentScore < score) {
			buildings[_currentSceneIndex].minigame.score = score;
			PlayerPrefs.SetInt ("scoreMinigame" + _currentSceneIndex, score);
		}
	}
	/*
	public void Load() { 
		for (int i = 0; i < buildings.Length; i++) {
			buildings[i].minigame.score = PlayerPrefs.GetInt ("scoreMinigame" + i, 0);
		}
	}
	public void Save() { }*/
	public void EraseMemory() { 
		PlayerPrefs.DeleteAll ();
	}
	public void ExitGame() { }
	public void ShowInstructions() { }
	public void Pause(bool pause) { }

	public void BackToMap(){
		SceneManager.LoadScene("Map");
	}

	// Update is called once per frame
	void Update () {

	}
}

