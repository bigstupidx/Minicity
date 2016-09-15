using UnityEngine;
using System.Collections;

public class DetectedMainCHaracter : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider otro)
    {
       // Debug.Log(otro.gameObject.CompareTag("NPC"));

        if (otro.CompareTag("Player"))
        {
            Debug.Log("SOY UN NPC!");
        }
    }
}
