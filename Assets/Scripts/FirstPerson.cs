using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    float TranslationVectorVerticalJump = 6;
    float TranslationVectorVertical = 0;
    float RotationVertically = 0;
    public float RealMovmentTranslationVector = 4.0f;
    public float ViewableVerticleRange = 65.0f;
    public float MouseSensitvityFactor = 3.8f;

    void Start()
    {
        Cursor.visible = false; // used to remove the cursor for screen
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape")) // allows the user to exit even with the cursor hidden
        {
            Application.Quit(); // quit the applicaiton command 
        }
        CharacterController PlayerCharacter = GetComponent<CharacterController>(); // attach a charactercontroller

        //Display for the point of view of the user
        float HorzRot = Input.GetAxis("Mouse X") * MouseSensitvityFactor;
        transform.Rotate(0, HorzRot, 0);
        RotationVertically -= Input.GetAxis("Mouse Y") * MouseSensitvityFactor; // use MouseSensitvityFactor and input value to get roation value
        RotationVertically = Mathf.Clamp(RotationVertically, -ViewableVerticleRange, ViewableVerticleRange); // use clamping to limit to viewable vertical range
        Camera.main.transform.localRotation = Quaternion.Euler(RotationVertically, 0, 0); // set the camera's roation using the rotation value previously set.

        float forwardTranslationVector = 0;
        float sideTranslationVector = 0; 
        if (!PlayerCharacter.isGrounded)
        {
            forwardTranslationVector = Input.GetAxis("Vertical") * (RealMovmentTranslationVector / 10); // Using the builtin inputs for vertical
            sideTranslationVector = Input.GetAxis("Horizontal") * (RealMovmentTranslationVector /10); // and horizontal
            TranslationVectorVertical += Physics.gravity.y * Time.deltaTime; // using the phyciscs gravity value with time since previous frame to set the vertical TranslationVector 
            if (TranslationVectorVertical < -10) {
                TranslationVectorVertical = -10;
            }
        }   
        else {
            forwardTranslationVector  = Input.GetAxis("Vertical") * RealMovmentTranslationVector; // Using the builtin inputs for vertical
            sideTranslationVector = Input.GetAxis("Horizontal") * RealMovmentTranslationVector; // and horizontal
            TranslationVectorVertical = 0; // Stops from applying gravity even when standing on a plane ... really should be 9.81 m/s/s 
        }
        if (PlayerCharacter.isGrounded && Input.GetButtonDown("Jump"))
        { // check if the user is on the ground and if the jump input has been pressed, 
            //stops the user from jumping while jumping
            TranslationVectorVertical = TranslationVectorVerticalJump; // set the jump to the correct velocity with physics / real world aPlayerCharactereleration  
        }

        Vector3 TranslationVector = new Vector3(sideTranslationVector, TranslationVectorVertical, forwardTranslationVector); // finally create a new matrix to apply to the transformation to the character
        TranslationVector = transform.rotation * TranslationVector; // applying the roational matrix
        PlayerCharacter.Move(TranslationVector * Time.deltaTime); // move the character using above multipled matrix

    }
}
