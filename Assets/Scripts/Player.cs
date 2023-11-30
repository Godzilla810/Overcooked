using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask;
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float rotate_speed = 25.0f;
    [SerializeField] private float interactDistance = 1f;
    [SerializeField] private Transform holdpoint;
    private Vector3 interactDir;
    private bool isWalking;
    private KitchenObject KitchenObject;
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }
    void Update()
    {
        PlayerMovement();
    }
    //��e����Interact
    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        if (moveDir != Vector3.zero)
        {
            interactDir = moveDir;
        }
        //Debug.DrawRay(transform.position, interactDir * interactDistance, Color.red);
        if (Physics.Raycast(transform.position, interactDir, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter basecounter))
            {
                basecounter.Interact(this);
            }
        }
    }
    //private void PlayerInteract()
    //{
    //    Vector2 inputVector = gameInput.GetMovementVectorNormalized();
    //    Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
    //    if (moveDir != Vector3.zero)
    //    {
    //        interactDir = moveDir;
    //    }
    //    Debug.DrawRay(transform.position, interactDir * interactDistance, Color.red);
    //    if (Physics.Raycast(transform.position, interactDir, out RaycastHit raycastHit, interactDistance, counterLayerMask))
    //    {
    //        if (raycastHit.transform.TryGetComponent(out Counter counter))
    //        {
    //            counter.Interact();
    //        }
    //    }
    //}
    private void PlayerMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        if (moveDir != Vector3.zero)
        {
            interactDir = moveDir;
        }

        transform.position += moveDir * moveSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotate_speed);
        isWalking = moveDir != Vector3.zero;
    }
    private void GetPlate()
    {

    }
    public Transform countertransform()
    {
        return holdpoint;
    }
    public void SetKichenObject(KitchenObject kitchenObject)
    {
        this.KitchenObject = kitchenObject;
    }
    public void ClearKitchenObject()
    {
        KitchenObject = null;
    }
    public KitchenObject ReturnKitchenObject()
    {
        return KitchenObject;
    }
    public bool HasKitchenObject()
    {
        return this.KitchenObject != null;
    }
}
