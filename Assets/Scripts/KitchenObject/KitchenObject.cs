using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    private IKitchenObjectParent KitchenObjectParent;

    private Ingredient ingredient;

    //處理拿放
    public void SetKitchenObjectParent(IKitchenObjectParent _KitchenObjectParent)
    {
        //先清空Parent東西資料
        if (KitchenObjectParent != null)
        {
            KitchenObjectParent.ClearKitchenObject();
        }

        KitchenObjectParent = _KitchenObjectParent;
        //Parent有東西
        if (KitchenObjectParent.HasKitchenObject())
        {
            Debug.Log("Already had KitchenObject");
        }
        //Parent沒東西
        else
        {
            //給Parent東西
            KitchenObjectParent.SetKitchenObject(this);
            transform.parent = KitchenObjectParent.GetPoint();//更改KitchenObject的父物件 = 哪張桌子
            transform.localPosition = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }
    }
    public void DestroySelf()
    {
        KitchenObjectParent.ClearKitchenObject() ;
        Destroy(gameObject);
    }
}
