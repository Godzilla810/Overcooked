using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KichenObjectSO KichenObjectSO;
    private IKitchenObjectParent KitchenObjectParent;

    public KichenObjectSO KichenObject_return(IKitchenObjectParent KitchenObjectParent)
    {
        return KichenObjectSO;
    }
    //�T�{KitchenObject��m(�����Ӯ�l�W)
    public void SetKitchenObjectParent(IKitchenObjectParent KitchenObjectParent)
    {
        if (this.KitchenObjectParent != null)
        {
            this.KitchenObjectParent.ClearKitchenObject();
        }
        this.KitchenObjectParent = KitchenObjectParent;
        if (KitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("Already had KitchenObject");
        }
        else
        {
            KitchenObjectParent.SetKichenObject(this);
            transform.parent = KitchenObjectParent.countertransform();//���KitchenObject�������� =���i��l
            transform.localPosition = Vector3.zero;
        }
    }
    public IKitchenObjectParent ReturnCounter()
    {
        return KitchenObjectParent;
    }
}
