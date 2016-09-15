using UnityEngine;
using System.Collections;

public class ProductoComprado : MonoBehaviour {
    GameObject carr;
    // Use this for initialization
    void Awake () {
        carr = GameObject.FindGameObjectWithTag("Carro");
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("asfadfaSFAD");

    }
  void OnTriggerEnter(Collider Otro)
    {

        if (Otro.gameObject == carr)
        {
            Debug.Log("asfadfaSFAD");
            MarketMenu.compra = true;


        }





    }




}
