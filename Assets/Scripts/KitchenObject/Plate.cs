using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class Plate : KitchenObject
{
    public event EventHandler <OnIngredientAddEventArgs> OnIngredientAdd;
    public class OnIngredientAddEventArgs : EventArgs 
    { 
        public IngredientSO ingredientSO; 
    }
    private List<string> ingredients;
    public void Start()
    {
        ingredients = new List<string>();
    }
    public bool AddIngredient(Ingredient ingredient)
    {
        //�P�˭����u��ˤ@�� && �O�w����������
        if (!ingredients.Contains(ingredient.GetIngredientSO().objectName) && ingredient.IsComplete())
        {
            if (ingredient.GetIngredientSO().objectName == "Bun")
            {
                ingredients.Add(ingredient.GetIngredientSO().objectName);
                OnIngredientAdd?.Invoke(this, new OnIngredientAddEventArgs
                {
                    ingredientSO = ingredient.GetIngredientSO()
                });
                return true;
            }
            else if (ingredients.Contains("Bun"))
            {
                ingredients.Add(ingredient.GetIngredientSO().objectName);
                OnIngredientAdd?.Invoke(this, new OnIngredientAddEventArgs
                {
                    ingredientSO = ingredient.GetIngredientSO()
                });
                return true;
            }
        }
        return false;
    }
    //public void ClearIngredient()
    //{
    //    ingredients.Clear();
    //}
}
