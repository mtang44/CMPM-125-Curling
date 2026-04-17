using System.Diagnostics;
using UnityEngine;  

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Trigger detected:" + gameObject.name);

        UnityEngine.Debug.Log("Trigger Detected with " + other.gameObject.name);
    }
}
