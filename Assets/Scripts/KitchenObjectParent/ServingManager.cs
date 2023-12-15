using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class ServingManager : MonoBehaviour
{
    public event EventHandler RecipeSpawn;
    public event EventHandler RecipeComplete;
    public static ServingManager Instance { get; private set; }

    [SerializeField] private RecipeSOList recipeListSO;
    [SerializeField] private TextMeshProUGUI title;
    private List<RecipeSO> waitrecipeSOList; //�ݧ������
    private float generateRecipeTimer = 2f;
    private float generateRecipeMaxTimer = 5f;
    private int waitRecipeMax = 3;

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
                title.text = "�ݧ������...";
                RecipeSO waitrecipe = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];
                //Debug.Log(waitrecipe.recipeName);
                waitrecipeSOList.Add(waitrecipe);

                RecipeSpawn?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void ServingRecipeCorrect(Plate plate)
    {
       // bool allwrong = true;
        for (int i = 0; i < waitrecipeSOList.Count; i++) { 
            RecipeSO recipeSO = waitrecipeSOList[i];

            if(recipeSO.ingredients.Count == plate.GetIngredientList().Count) {
                bool deliverCorrect = true;
                foreach(IngredientSO ingredientSO in recipeSO.ingredients)
                {
                    bool ingredientFound = false;
                    foreach(IngredientSO ingredient in plate.GetIngredientList())
                    {
                        if(ingredient == ingredientSO)
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
                    if(waitrecipeSOList.Count <= 0)
                    {
                        title.text = "���ݭq�椤";
                    }
                    //allwrong = false;
                    //Debug.Log("Player delivered the correct recipe!");
                    waitrecipeSOList.RemoveAt(i);
                    RecipeComplete?.Invoke(this, EventArgs.Empty);
                    
                    return;
                }
            }
        }
    }

    public List<RecipeSO> GetWaitRecipeSOList()
    {
        return waitrecipeSOList;
    }
}
