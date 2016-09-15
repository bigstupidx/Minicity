using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    
     
        public float rango = 10;
        public Transform target;
        public float smoothing = 5f;
        Vector3 offset;

        void Start()
        {
            offset = transform.position - target.position;
        }


        void FixedUpdate()
        {
                

            Vector3 targetCampos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCampos, smoothing * Time.deltaTime);

        }
    }
