using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Plate : KitchenObject
{
    private List<Ingredient> ingredients;
    public void AddIngredient(Ingredient ingredient)
    {
        //�P�˭����u��ˤ@�� && �O�w����������
        if (!ingredients.Contains(ingredient) && ingredient.IsProcessFinished())
        {
            ingredients.Add(ingredient);
        }
    }
    public void ClearIngredient()
    {
        ingredients.Clear();
    }
}
