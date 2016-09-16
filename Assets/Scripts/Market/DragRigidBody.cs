using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.Utility
{
    public class DragRigidBody : MonoBehaviour
    {

        const float k_Spring = 5000.0f;
        const float k_Damper = 5.0f;
        const float k_Drag = 10.0f;
        const float k_AngularDrag = 5.0f;
        const float k_Distance = 0.2f;
        const bool k_AttachToCenterOfMass = false;

        private SpringJoint m_SpringJoint;

        private void Update()
        {

            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }


            var mainCamera = FindCamera();


            RaycastHit hit = new RaycastHit();

            if (
                !Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition).origin,
                mainCamera.ScreenPointToRay(Input.mousePosition).direction, out hit, 100, Physics.DefaultRaycastLayers))


            {
                return;


            }


            if (!hit.rigidbody || hit.rigidbody.isKinematic)

            {


                return;
            }

            if (!m_SpringJoint)
            {

                var go = new GameObject("RigidBody dragger");
                Rigidbody body = go.AddComponent<Rigidbody>();
                m_SpringJoint = go.AddComponent<SpringJoint>();
              

            }
            m_SpringJoint.transform.position = hit.point;
            m_SpringJoint.anchor = Vector3.zero;

            m_SpringJoint.spring = k_Spring;
            m_SpringJoint.damper = k_Damper;
            m_SpringJoint.connectedBody = hit.rigidbody;

            StartCoroutine("DragObject", hit.distance);
        }

        private IEnumerator DragObject(float distance)

        {
            var olddrag = m_SpringJoint.connectedBody.drag;
            var oldAngularDrag = m_SpringJoint.connectedBody.angularDrag;
            m_SpringJoint.connectedBody.drag = k_Drag;
            m_SpringJoint.connectedBody.angularDrag = k_AngularDrag;
            var mainCamera = FindCamera();
            while (Input.GetMouseButton(0))
            {
                var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                m_SpringJoint.transform.position = ray.GetPoint(distance);
                yield return null;
            }



            if (m_SpringJoint.connectedBody)
            {
                m_SpringJoint.connectedBody.drag = olddrag;
                m_SpringJoint.connectedBody.angularDrag = oldAngularDrag;
                m_SpringJoint.connectedBody = null;



            }
        }





        private Camera FindCamera()
        {
            if (GetComponent<Camera>())
            {

                return GetComponent<Camera>();
            }
            return Camera.main;
        }






    }
}












