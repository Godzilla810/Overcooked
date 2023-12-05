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
