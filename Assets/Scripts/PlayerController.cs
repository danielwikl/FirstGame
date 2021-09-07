using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 5;
    private float verticalController;
    private float horizontalController;
    private float jump;
    Vector3 vectorMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        verticalController = Input.GetAxis("Vertical");

        horizontalController = Input.GetAxis("Horizontal");

        var delta = new Vector3(horizontalController, 0f, verticalController);

        transform.Translate(delta * speed * Time.deltaTime);

        //transform.Translate(new Vector3(horizontalController, 0, verticalController));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }



    }
}
