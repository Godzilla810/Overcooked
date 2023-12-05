using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Crate : BaseCounter
{
    [SerializeField] private GameObject prefab;
    public override void Interact(Player player)
    {
        //���a�S�F��
        if (!player.HasKitchenObject())
        {
            //�����a�F��
            KitchenObject kitchenObject = Instantiate(prefab).GetComponent<KitchenObject>();
            kitchenObject.SetKitchenObjectParent(player);
        }
    }
}
