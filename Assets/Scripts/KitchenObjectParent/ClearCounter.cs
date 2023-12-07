using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            //���a���F��
            else
            {
                //���a���L�l
                if (player.GetKitchenObject() is Plate)
                {
                    //���L�l�˭���
                    Plate plate = player.GetKitchenObject() as Plate;
                    Ingredient ingredient = this.GetKitchenObject() as Ingredient;
                    if (plate.AddIngredient(ingredient))
                    {
                        this.GetKitchenObject().DestroySelf();
                    }
                }
                else if (this.GetKitchenObject() is Plate)
                {
                    Plate plate = this.GetKitchenObject() as Plate;
                    Ingredient ingredient = player.GetKitchenObject() as Ingredient;
                    if (plate.AddIngredient(ingredient))
                    {
                        player.GetKitchenObject().DestroySelf();
                    }
                }
            }
        }
    }
}
