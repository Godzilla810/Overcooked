using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KichenObjectSO kichenObjectSO;
    private IKitchenObjectParent KitchenObjectParent;

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
            Debug.LogError("Already had KitchenObject");
        }
        //Parent�S�F��
        else
        {
            //��Parent�F��
            KitchenObjectParent.SetKitchenObject(this);
            transform.parent = KitchenObjectParent.GetPoint();//���KitchenObject�������� = ���i��l
            transform.localPosition = Vector3.zero;
        }
    }
}
