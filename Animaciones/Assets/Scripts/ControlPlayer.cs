using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    private Vector3 direccion;
    private CharacterController controlador;
    public float walkingSpeed;
    public float runningSpeed;
    public bool isWalking;
    private Vector3 momentoSpeed;


    Animator animador;
    Vector3 rotacion;
    public float rotationSpeed;
    public bool isRunning;
    public bool reloadd;
    public bool fire;
    
    
    void Start()
    {
        controlador = gameObject.GetComponent<CharacterController>();
        animador = gameObject.GetComponent<Animator>();
    }

    void Animate(){
        animador.SetBool ("Walking", isWalking);
        animador.SetFloat ("Speed", momentoSpeed.magnitude);
        animador.SetBool ("Running", isRunning);
        animador.SetBool ("Reload", reloadd);
        animador.SetBool ("Firing", fire);
        
    }

    // Update is called once per frame
    void Update()
    {
        direccion = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rotacion = new Vector3 (0f, Input.GetAxis("Horizontal"), 0f) * rotationSpeed;
        isWalking = !Input.GetKey(KeyCode.LeftShift);

        


        if(Input.GetKey(KeyCode.R)){
            reloadd = true; 
            isRunning = false;
        }
        if(Input.GetKeyUp(KeyCode.R)){
            reloadd = false;
        }

        if(Input.GetKey(KeyCode.T)){
            fire = true; 
            isRunning = false;
        }

        if(Input.GetKeyUp(KeyCode.T)){
            fire = false;;
        }

        if(isWalking){
            momentoSpeed=walkingSpeed * direccion;
            isRunning = false;
           
        } 
      
        else {
            if(reloadd == true | fire == true){

            }
            else{
                momentoSpeed=runningSpeed * direccion;
                isRunning = true;
                reloadd = false;
                fire = false; 
            }
            
        }
        
        controlador.transform.Rotate(rotacion);
        controlador.SimpleMove(momentoSpeed);

        Animate();
    }
}
