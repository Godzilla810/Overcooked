using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        //��W�S�F��
        if (!HasKitchenObject())
        {
            //���a���F��
            if (player.HasKitchenObject())
            {
                //��F��
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        //��W���F��
        else
        {
            //���a�S�F��
            if (!player.HasKitchenObject())
            {
                //���F��
                this.GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
