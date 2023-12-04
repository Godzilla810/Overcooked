using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�W����@�ӪF��:�@���i�l������
public class InitialCounter : ClearCounter
{
    [SerializeField] private GameObject prefab;
    private void Start()
    {
        KitchenObject kitchenObject = Instantiate(prefab).GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(this);
    }
}
