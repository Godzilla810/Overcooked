using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : BaseCounter
{
    private Ingredient ingredient;

    private void Update()
    {
        if (HasKitchenObject())
        {
            ingredient.Panfried();
        }
    }
    public override void Interact(Player player)
    {
        //��l�S�F��
        if (!HasKitchenObject())
        {
            //���a���F�� & �ӪF��O����
            if (player.HasKitchenObject() & player.GetKitchenObject() is Ingredient)
            {
                //�������
                ingredient = player.GetKitchenObject() as Ingredient;
                //�ӪF��i��
                if (ingredient.CanPanfried())
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
                else
                {
                    ingredient = null;
                }
            }
        }
        //��l���F��
        else
        {
            //���a�S�F��
            if (!player.HasKitchenObject()&& !ingredient.IsComplete())
            {
                //������
                ingredient = null;
                GetKitchenObject().SetKitchenObjectParent(player);
            }
            else if (player.GetKitchenObject() is Plate && ingredient.IsComplete())
            {
                //���L�l�˭���
                Plate plate = player.GetKitchenObject() as Plate;
                Ingredient ingredient = GetKitchenObject() as Ingredient;
                if (plate.AddIngredient(ingredient))
                {
                    GetKitchenObject().DestroySelf();
                }
            }
        }
    }
}
