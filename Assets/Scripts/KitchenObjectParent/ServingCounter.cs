using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.GetKitchenObject() is Plate plate)
        {
            ServingManager.Instance.ServingRecipeCorrect(plate);
            player.GetKitchenObject().DestroySelf();
        }
    }
}
