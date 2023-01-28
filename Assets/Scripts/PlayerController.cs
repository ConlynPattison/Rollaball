using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    
    private Rigidbody _rb; // Used to add force to the Player GameObject
    private int count;
    private float _movementX;
    private float _movementY; // In practice, used to apply force in the Z-direction
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>(); // Attach variable to Player component on first frame
        count = 0;
        
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); // Takes input movement data from the Player and stores as Vector2
        
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_movementX, 0f, _movementY);
        
        _rb.AddForce(movement * speed);
    }

    // Called when the Player GameObject first touches a trigger Collider 'other'
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false); // other.gameObject -> "The game object this component is attached to. A component is always attached to a game object."
            count++;
            
            SetCountText();
        }
    }
}
