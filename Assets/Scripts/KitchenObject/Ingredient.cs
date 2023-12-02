using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : KitchenObject
{
    [SerializeField] private IngredientSO ingredientSO;
    //切
    private bool needCut;
    private int maxCutCount = 10;
    private int cutCount = 0;
    //煎
    private bool needPanfried;
    private float maxPanfriedTime = 5.0f;
    private float panfriedTime = 0f;
    private MeshFilter ingredientMeshFilter;
    private bool isFinished = false;    // =true=>狀態對
    private void Start()
    {
        needCut = ingredientSO.cuttingMeshes.Count != 0;
        needPanfried = ingredientSO.panfriedMeshes.Count != 0;
        ingredientMeshFilter = this.gameObject.GetComponent<MeshFilter>();
        isFinished = !needCut && !needPanfried;
    }
    //紀錄切的次數
    public void Cut()
    {
        if (needCut)
        {
            cutCount++;
            //切好
            if (cutCount >= maxCutCount)
            {
                needCut = false;
                isFinished = !needCut && !needPanfried;
                ingredientMeshFilter.mesh = ingredientSO.cuttingMeshes[2];
            }
            //切到一半
            else if (cutCount >= maxCutCount / 2)
            {
                ingredientMeshFilter.mesh = ingredientSO.cuttingMeshes[1];
            }
            //還沒切
            else
            {
                ingredientMeshFilter.mesh = ingredientSO.cuttingMeshes[0];
            }
        }
    }
    //紀錄煎的秒數
    public void Panfried()
    {
        if (needPanfried  && !needCut)
        {
            panfriedTime += Time.deltaTime;
            //焦
            if (panfriedTime >= 2 * maxPanfriedTime)
            {
                needPanfried = true;
                isFinished = !needCut && !needPanfried;
                ingredientMeshFilter.mesh  = ingredientSO.panfriedMeshes[2];
            }
            //熟
            else if (panfriedTime >= maxPanfriedTime)
            {
                needPanfried = false;
                isFinished = !needCut && !needPanfried;
                ingredientMeshFilter.mesh = ingredientSO.panfriedMeshes[1];
            }
            //生
            else
            {
                ingredientMeshFilter.mesh = ingredientSO.panfriedMeshes[0];
            }
        }
    }
    //紀錄是否完成
}
