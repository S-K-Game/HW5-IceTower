using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    [SerializeField] public float cameraDis = 30f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDis);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x,
            player.position.y , player.position.z); 
    }
}
