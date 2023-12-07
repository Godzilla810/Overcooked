using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    private IKitchenObjectParent KitchenObjectParent;

    private Ingredient ingredient;

    //�B�z����
    public void SetKitchenObjectParent(IKitchenObjectParent _KitchenObjectParent)
    {
        //���M��Parent�F����
        if (KitchenObjectParent != null)
        {
            KitchenObjectParent.ClearKitchenObject();
        }

        KitchenObjectParent = _KitchenObjectParent;
        //Parent���F��
        if (KitchenObjectParent.HasKitchenObject())
        {
            Debug.Log("Already had KitchenObject");
        }
        //Parent�S�F��
        else
        {
            //��Parent�F��
            KitchenObjectParent.SetKitchenObject(this);
            transform.parent = KitchenObjectParent.GetPoint();//���KitchenObject�������� = ���i��l
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
