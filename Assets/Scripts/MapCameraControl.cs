using UnityEngine;
using System.Collections;

public class MapCameraControl : MonoBehaviour {
	public AC.GameCamera camera;
	private Vector2 orbitSpeed;
	private float rotateSpeed;
	private float zoomSpeed;

	public float orbitSpeedModifier=1;
	public float zoomSpeedModifier=5;
	public float rotateSpeedModifier=1;
	// Use this for initialization
	void Start () {
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
		orbitSpeed=dragInfo.delta*orbitSpeedModifier;
	}


	void OnPinch(float val){
		zoomSpeed-=val*zoomSpeedModifier;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position=center;
		transform.rotation*=Quaternion.Euler(-orbitSpeed.y, orbitSpeed.x, rotateSpeed);
		//transform.position=transform.TransformPoint(new Vector3(0, 0, dist));

		orbitSpeed*=(1-Time.deltaTime*3);
		rotateSpeed*=(1-Time.deltaTime*4f);
		zoomSpeed*=(1-Time.deltaTime*4);
	}
}
