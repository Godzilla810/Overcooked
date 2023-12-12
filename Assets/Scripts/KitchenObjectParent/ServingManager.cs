using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ServingManager : MonoBehaviour
{
    public static ServingManager Instance { get; private set; }

    [SerializeField] private RecipeSOList recipeListSO;
    private List<RecipeSO> waitrecipeSOList; //�ݧ������
    private float generateRecipeTimer;
    private float generateRecipeMaxTimer = 5f;
    private int waitRecipeMax = 4;

    private void Awake()
    {
        Instance = this;
        waitrecipeSOList = new List<RecipeSO>();
    }

    private void Update()
    {
        generateRecipeTimer -= Time.deltaTime;
        if (generateRecipeTimer <= 0f) {
            generateRecipeTimer = generateRecipeMaxTimer;

            //�Y����٨S�F�̤j�ƶq�h�s�W���
            if(waitrecipeSOList.Count < waitRecipeMax)
            {
                RecipeSO waitrecipe = recipeListSO.recipeSOList[Random.Range(0, recipeListSO.recipeSOList.Count)];
                Debug.Log(waitrecipe.recipeName);
                waitrecipeSOList.Add(waitrecipe);
            }
        }
    }

    public void ServingRecipeCorrect(Plate plate)
    {
        bool allwrong = true;
        for (int i = 0; i < waitrecipeSOList.Count; i++) { 
            RecipeSO recipeSO = waitrecipeSOList[i];

            if(recipeSO.ingredients.Count == plate.GetIngredientList().Count) {
                bool deliverCorrect = true;
                foreach(IngredientSO ingredientSO in recipeSO.ingredients)
                {
                    bool ingredientFound = false;
                    foreach(string ingredient in plate.GetIngredientList())
                    {
                        if(ingredient == ingredientSO.objectName)
                        {
                            ingredientFound = true;
                            break;
                        }
                    }
                    if (!ingredientFound)
                    {
                        deliverCorrect = false;
                    }
                }

                if (deliverCorrect)
                {
                    allwrong = false;
                    Debug.Log("Player delivered the correct recipe!");
                    waitrecipeSOList.RemoveAt(i);
                    return;
                }
            }
        }

        if (allwrong)
        {
            Debug.Log("YOU ARE STUPID!!!!!!!!");
        }
    }
}
