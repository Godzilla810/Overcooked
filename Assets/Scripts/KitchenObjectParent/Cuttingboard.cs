using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttingboard : BaseCounter
{
    [SerializeField] private List<IngredientSO> CanCutIngredientSO;
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
                player.GetKitchenObject().SetKitchenObjectParent(this);
                ingredient = (Ingredient)player.GetKitchenObject();
            }
        }
        //��W���F��
        else
        {
            //���a�S�F��
            if (!player.HasKitchenObject())
            {
                //������
                this.GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    public override void Cut()
    {
        Debug.Log("cut");
    }
}
