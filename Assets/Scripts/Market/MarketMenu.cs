using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MarketMenu : MonoBehaviour {
    float smoothing = 9f; 
    public GameObject producto01;
    public GameObject menuCompra;
    bool pro;
    Vector3 targetCampos;
    Vector3 targetCarroCompras;
    private bool comprado;
    bool productoEnCarro;
    public static bool compra;

    public Rigidbody body;

    public void Start() {
        targetCampos.x = 1.411831f;
        targetCampos.y = -0.4784083f;
        targetCampos.z = -3.785f;

        targetCarroCompras.x = 4.15f;
        targetCarroCompras.y = 0.44f;
        targetCarroCompras.z = 0.37f;



    }
    public void Exit () {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(0);

	}


    void Awake()
    {
        Rigidbody body = producto01.GetComponent<Rigidbody>();
    }


    public void Update () {

      


        if (pro) { 
        StartCoroutine("MostrarProducto", producto01);
            MenuComprar();
        }



        if (comprado && compra == false)
        {

            menuCompra.SetActive(false);
            StartCoroutine("GuardarProducto", producto01);


 
         }
        if (compra)
        {



        }





}



    public IEnumerator MostrarProducto(GameObject producto)
    {

        body.useGravity = false;
        producto.transform.position = Vector3.Lerp(producto.transform.position, targetCampos, smoothing * Time.deltaTime * 0.5f);
       
            yield return null;
     

    }

    public IEnumerator GuardarProducto(GameObject producto)
    {

        comprado = true;


        producto.transform.position = Vector3.Lerp(producto.transform.position, targetCarroCompras, smoothing * Time.deltaTime * 0.5f);
        yield return null;
    }






    public void Product()
    {

        pro = true;

    }
    void MenuComprar()
    {

        menuCompra.SetActive(true);

    }


    public void ProductoComprado() {

        comprado = true;


    }



}