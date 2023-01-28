using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 _offset; // Used to move camera based on transform of the Player; doesn't consider rotation
    
    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - player.transform.position;
    }

    // Update is called once per frame -> Late Update is run after other updates have finished (physics)
    void LateUpdate()
    {
        transform.position = player.transform.position + _offset; // won't be set until the Player has moved for any given frame
    }
}
