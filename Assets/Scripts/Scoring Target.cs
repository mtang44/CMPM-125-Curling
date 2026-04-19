using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> collisions;
    private Vector3 target_center;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target_center = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Calculate_Closest_Collision();
    }
    void OnTriggerEnter(Collider other)
    {
        collisions.Add(other.gameObject);
        UnityEngine.Debug.Log("Trigger Detected with " + other.gameObject.name);
       
    }
    void OnTriggerExit(Collider other)
    {
        collisions.Remove(other.gameObject);
        UnityEngine.Debug.Log("Trigger Exit Detected with " + other.gameObject.name);
    }
    GameObject Calculate_Closest_Collision()
    {
        if(collisions.Count == 0)
        {
            return null;
        }
        else
        {
            GameObject closest = collisions[0];
            float closest_distance = Vector3.Distance(closest.transform.position, target_center);
            foreach(GameObject currentCollision in collisions)
            {
                if(Vector3.Distance(currentCollision.transform.position, target_center) < closest_distance)
                {
                    closest = currentCollision.gameObject;
                    closest_distance = Vector3.Distance(currentCollision.transform.position, target_center);
                }
            }
            UnityEngine.Debug.Log("Closest Cllision is " + closest.name);
            return closest;
        }
    }
}
