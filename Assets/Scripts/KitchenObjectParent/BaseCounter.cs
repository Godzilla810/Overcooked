using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IKitchenObjectParent
{
    [SerializeField] private Transform topPoint;
    [SerializeField] private GameObject visualObject;
    private KitchenObject KitchenObject;

    //�B�z����
    public virtual void Interact(Player player){}
    //�B�z��
    public virtual void Cut(Player player){}

    //�w�qKitchenObjectParent����
    public Transform GetPoint()
    {
        return topPoint;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.KitchenObject = kitchenObject;
    }
    public void ClearKitchenObject()
    {
        KitchenObject = null;
    }
    public KitchenObject GetKitchenObject()
    {
        return KitchenObject;
    }
    public bool HasKitchenObject()
    {
        return this.KitchenObject != null;
    }
    public void HideVisualObject()
    {
        visualObject.SetActive(false);
    }
    public void ShowVisualObject()
    {
        visualObject.SetActive(true);
    }
}
