using UnityEngine;
using System.Collections;

public class MapCameraControl : MonoBehaviour {
	public Camera camera;
	public Vector2 orbitSpeed;
	private float rotateSpeed;
	private float zoomSpeed;

	public float orbitSpeedModifier=2;
	public float zoomSpeedModifier=5;
	public float rotateSpeedModifier=2;

	Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void OnEnable(){
		Gesture.onDraggingE += OnDragging;
		//Gesture.onRotateE += OnRotate;
		Gesture.onPinchE += OnPinch;
	}

	void OnDisable(){
		Gesture.onDraggingE -= OnDragging;
		//Gesture.onRotateE += OnRotate;
		Gesture.onPinchE += OnPinch;
	}

	void OnDragging(DragInfo dragInfo){
		orbitSpeed = dragInfo.delta * orbitSpeedModifier;
	}


	void OnPinch(float val){
		zoomSpeed -= val * zoomSpeedModifier;
	}
	
	// Update is called once per frame
	void Update () {
		//print (Input.mouseScrollDelta);
		OnPinch(Input.mouseScrollDelta.y);
		if (player == null)
			player = GameObject.FindGameObjectWithTag ("Player").transform;
		else {
			transform.position = player.position;
			transform.Rotate (orbitSpeed.y, -orbitSpeed.x, 0f);
			transform.rotation = Quaternion.Euler (new Vector3 (Mathf.Clamp (transform.rotation.eulerAngles.x, 310f, 355f), transform.rotation.eulerAngles.y, 0f));
			camera.fieldOfView = Mathf.Clamp (camera.fieldOfView + zoomSpeed, 30f, 80f);
		}
		//transform.rotation = Quaternion.Euler(new Vector3 (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f));
		//transform.rotation *= Quaternion.Euler (-orbitSpeed.y, orbitSpeed.x, rotateSpeed);
		//transform.position=transform.TransformPoint(new Vector3(0, 0, dist));

		orbitSpeed*=(1-Time.deltaTime*3);
		rotateSpeed*=(1-Time.deltaTime*4f);
		zoomSpeed*=(1-Time.deltaTime*4);
	}
}
