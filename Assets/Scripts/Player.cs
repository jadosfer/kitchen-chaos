using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    private bool isWalking;
    
    private void Update() {

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y); //indica la dir del movimiento
        transform.position += moveDir * moveSpeed * Time.deltaTime; //multiplicar por deltaTime normaliza la velocidad

        isWalking = moveDir != Vector3.zero;
        //transform.forward = moveDir;// para que mire hacia donde se mueve
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime* rotateSpeed);// para sea suave el giro

    }

    public bool IsWalking() {
        return isWalking;
    }
}
