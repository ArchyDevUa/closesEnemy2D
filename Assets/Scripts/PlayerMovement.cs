using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float VerticalInput;
    private float HorizontalInput;
    [SerializeField] private float speed = 5;

    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxisRaw("Vertical");
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        transform.position = transform.position + new Vector3(HorizontalInput, VerticalInput,0) * speed * Time.deltaTime;
    }
}
