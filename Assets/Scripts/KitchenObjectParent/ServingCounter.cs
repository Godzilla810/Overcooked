using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingCounter : BaseCounter
{
    //�u��A�L�P�_
    public override void Interact(Player player)
    {
        if (player.GetKitchenObject() is Plate plate)
        {
            ServingManager.Instance.ServingRecipeCorrect(plate);
            player.GetKitchenObject().DestroySelf();
        }
    }
}
