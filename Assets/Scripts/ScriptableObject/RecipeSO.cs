using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
//��@���
public class RecipeSO : ScriptableObject
{
    public List<IngredientSO> ingredients;
    public Sprite RecipeFoodSprite;
    public string recipeName;
    public string recipeChineseName;
}
