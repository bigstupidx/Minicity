using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Market : MonoBehaviour {
    public Animator anim;
    public Camera Camara;
    public GameObject uiMarket;
    public GameObject player;
    Vector3 posicionCamara;
    public float smoothing = 9f;
    bool zoom = false;
    bool CamaraPos = false;


    void Awake () {
        posicionCamara  = Camara.transform.position ;
     
    }

     
    void  FixedUpdate()
          
    {

        if (CamaraPos)
        {
            Camara.transform.position = Vector3.Lerp(Camara.transform.position, posicionCamara, smoothing * Time.deltaTime * 0.3f);
        }
        if (zoom)
        {

            Vector3 targetCampos;
            targetCampos.x =- 2.47f;
            targetCampos.y = 4.36f;
            targetCampos.z = -3.21f;
            Camara.transform.position = Vector3.Lerp(Camara.transform.position, targetCampos, smoothing * Time.deltaTime * 0.3f);
        }
    }

    void OnTriggerEnter(Collider Otro)
    {
        if (Otro.CompareTag("Player"))
        {
            zoom = true;
            CamaraPos = false;

            anim.SetBool("IsWalking", false);


            uiMarket.SetActive(true);
           
        }

    }


    void OnTriggerExit(Collider Otro)
    {
        if (Otro.CompareTag("Player"))
        {
            CamaraPos = true;

            anim.SetBool("IsWalking", true);
            zoom = false;

            uiMarket.SetActive(false);

        }

    }



    public void Enter()

    {

        SceneManager.LoadScene(1);

    }
    public void Exit()

    {
        CamaraPos = true;
        uiMarket.SetActive(false);
        zoom = false;

    }
}
