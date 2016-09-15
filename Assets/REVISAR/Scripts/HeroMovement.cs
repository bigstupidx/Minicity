using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour
{
    GameObject curTag;
    public GameObject cur;
    Animator anim;
    int floorMask;
    public float camRayLenght = 1f;

    public Transform player;
    public NavMeshAgent nav;
    Rigidbody playerRigidBody;
    
    void Awake()
    {
        curTag = GameObject.FindGameObjectWithTag("Destino");
        playerRigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        floorMask = LayerMask.GetMask("StreetMask");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Turning();
    }
    
    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLenght, floorMask))
        {
            Vector3 playerToMouse = floorHit.point ;
            playerToMouse.y = 0;
            //     Quaternion NewRotation = Quaternion.LookRotation(playerToMouse);
            //  playerRigidBody.MoveRotation(NewRotation);
               
            if (Input.GetMouseButton(0))
            {
                cur.transform.position = playerToMouse;
                anim.SetBool("IsWalking", true);
                nav.SetDestination(playerToMouse);
                /*if (nav.pathEndPosition == playerToMouse)
                {
                   anim.SetBool("IsWalking", false);
                }*/
            }
        }
    }
    void OnTriggerEnter(Collider Otro) {
        
        if (Otro.gameObject == curTag)
        {
            //Debug.Log("asxasx");
            anim.SetBool("IsWalking", false);
        }
    }
}
