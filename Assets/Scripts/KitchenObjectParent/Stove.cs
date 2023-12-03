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
        //��W�S�F��
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
}
