using UnityEngine;
using System.Collections;

public class CamaraSigue : MonoBehaviour {

    public Transform player;
    public Vector3 desplazamiento;
    
	// Use this for initialization
	void Start ()
    {
        desplazamiento.x = 0;
        desplazamiento.y = 20;
        desplazamiento.z = -20;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position = new Vector3(player.position.x + desplazamiento.x, desplazamiento.y, player.position.z + desplazamiento.z);

	}
}
