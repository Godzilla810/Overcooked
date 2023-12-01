using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Crate : BaseCounter
{
    [SerializeField] private KichenObjectSO KichenObjectSO;

    public override void Interact(Player player)
    {
        //���a�S�F��
        if (!player.HasKitchenObject())
        {
            //�����a�F��
            KitchenObject kitchenObject = Instantiate(KichenObjectSO.prefab).GetComponent<KitchenObject>();
            kitchenObject.SetKitchenObjectParent(player);
        }
        //���a���F��
        else
        {
            Debug.LogError("Already had KitchenObject");
        }
    }
}
