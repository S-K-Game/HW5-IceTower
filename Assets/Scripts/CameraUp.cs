using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUp : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    public Transform camera;
    [SerializeField] public float distance = 0.09f;
    [SerializeField]  Collider2D other;
    [SerializeField] bool isTriggering = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggering == true)
        {
            camera.transform.position += new Vector3(0,distance, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            isTriggering = true;
        }
    }
}
