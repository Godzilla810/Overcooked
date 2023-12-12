using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    private Ingredient ingredient;
    public override void Interact(Player player)
    {
        //��W�S�F��
        if (!HasKitchenObject())
        {
            //���a���F�� & �ӪF��O����
            if (player.HasKitchenObject() & player.GetKitchenObject() is Ingredient)
            {
                //�񭹧�
                ingredient = player.GetKitchenObject() as Ingredient;
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        //��W���F��
        else
        {
            //���a�S�F��
            if (!player.HasKitchenObject())
            {
                //������
                ingredient = null;
                this.GetKitchenObject().SetKitchenObjectParent(player);
            }
            else if (player.GetKitchenObject() is Plate && ingredient.IsProcessFinished())
            {
                //���L�l�˭���
                Plate plate = player.GetKitchenObject() as Plate;
                Ingredient ingredient = this.GetKitchenObject() as Ingredient;
                if (plate.AddIngredient(ingredient))
                {
                    this.GetKitchenObject().DestroySelf();
                }
            }
            else if (player.GetKitchenObject() is Pan && ingredient.CanPanfried()) 
            {
                Pan pan = player.GetKitchenObject() as Pan;
                this.GetKitchenObject().SetKitchenObjectParent(pan);
            }
        }
    }
    public override void Cut()
    {
        //�������~���
        if (ingredient != null && ingredient.CanCut())
        {
            ingredient.Cut();
        }
    }
}
