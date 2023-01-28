using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame -> fine to use; not dependent on prior physics updates
    void Update()
    {
        transform.Rotate(new Vector3(15f, 30f, 45f) * Time.deltaTime); // deltaTime -> "The interval in seconds from the last frame to the current one". -> acts per second, not per frame
    }
}
