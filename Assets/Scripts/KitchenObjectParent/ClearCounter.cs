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
                if (GetKitchenObject() is Pan)
                {
                    Pan pan = GetKitchenObject() as Pan;
                    if (!pan.HasKitchenObject())
                    {
                        pan.SetKitchenObjectParent(player);
                    }
                    else
                    {
                        Ingredient ingredient = pan.GetKitchenObject() as Ingredient;
                        if (!ingredient.IsProcessFinished())
                        {
                            pan.GetKitchenObject().SetKitchenObjectParent(player);
                        }
                    }

                }
                else
                {
                    //���F��
                    this.GetKitchenObject().SetKitchenObjectParent(player);
                }
            }
            //���a���F��
            else
            {
                //���a���L�l
                if (player.GetKitchenObject() is Plate)
                {
                    Plate plate = player.GetKitchenObject() as Plate;
                    if (GetKitchenObject() is Pan)
                    {
                        Pan pan = GetKitchenObject() as Pan;
                        if (pan.HasKitchenObject())
                        {
                            Ingredient ingredient = pan.GetKitchenObject() as Ingredient;
                            if (ingredient.IsProcessFinished())
                            {
                                if (plate.AddIngredient(ingredient))
                                {
                                    pan.GetKitchenObject().DestroySelf();
                                }
                            }
                        }
                    }
                    else
                    {
                        Ingredient ingredient = GetKitchenObject() as Ingredient;
                        if (plate.AddIngredient(ingredient))
                        {
                            this.GetKitchenObject().DestroySelf();
                        }
                    }
                }
                else if (this.GetKitchenObject() is Plate && player.GetKitchenObject() is Ingredient)
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
