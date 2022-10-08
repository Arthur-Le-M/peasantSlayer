using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private Vector2 movement;
    public Camera cam;

     private Vector2 playerDir;
    private Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Déplacement perso
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movement = new Vector2(horizontalInput, verticalInput);
        //Fin Déplacement perso
    }

    void FixedUpdate() {
        //Déplacement perso
        if(Input.GetKey(KeyCode.LeftShift)){
            //Cas de l'accélération
            rb.MovePosition((Vector2)transform.position + movement * (speed*2f) * Time.deltaTime);
        }
        else{
            //Cas par défaut
            rb.MovePosition((Vector2)transform.position + movement * speed * Time.deltaTime);
        }
        //Fin Déplacement perso

        //Caméra
        cam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, cam.transform.position.z);

        //Rotation Perso
       
        mousePos =  cam.ScreenToWorldPoint(Input.mousePosition);
        playerDir = mousePos - rb.position;

        float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        //Fin Rotation perso
    }
}
