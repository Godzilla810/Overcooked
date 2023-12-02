using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : KitchenObject
{
    [SerializeField] private IngredientSO ingredientSO;
    [SerializeField] private int maxCutCount = 10;
    [SerializeField] private float maxPanfriedTime = 5.0f;
    private bool needCut;
    private bool needPanfried;
    private int cutCount = 0;
    private float panfriedTime = 0f;
    private bool isFinished = false;
    private void Start()
    {
        needCut = ingredientSO.cuttingMeshes.Count != 0;
        needPanfried = ingredientSO.panfriedMeshes.Count != 0;
        isFinished = !needCut && !needPanfried;
    }
    //������������
    public void Cut()
    {
        if (needCut)
        {
            cutCount++;
            if (cutCount == maxCutCount / 2)
            {
                this.gameObject.GetComponent<MeshFilter>().mesh = ingredientSO.cuttingMeshes[1];
            }
            else if (cutCount == maxCutCount)
            {
                needCut = false;
                isFinished = !needCut && !needPanfried;
                this.gameObject.GetComponent<MeshFilter>().mesh = ingredientSO.cuttingMeshes[2];
            }
        }
    }
    //�����Ϊ����
    //�����O�_����
}
