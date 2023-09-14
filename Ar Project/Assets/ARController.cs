using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    [SerializeField] private GameObject MyObject; // Serialized field
    [SerializeField] private ARRaycastManager RaycastManager; // Serialized field

    public void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            RaycastManager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
            if (hits.Count > 0)
            {
                GameObject.Instantiate(MyObject, hits[0].pose.position, hits[0].pose.rotation);
            }
        }
    }
}
