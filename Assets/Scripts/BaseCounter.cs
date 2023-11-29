using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IKitchenObjectParent
{
    [SerializeField] private Transform countertop;
    private KitchenObject KitchenObject;
    public virtual void Interact(Player player)
    {
        Debug.LogError("Basecounter interact!");
    }
    //��basecounter�s��counter�Mclearcounter��Interact�\��
    //override�h�����̤��@��Interact
    public Transform countertransform()
    {
        return countertop;
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
