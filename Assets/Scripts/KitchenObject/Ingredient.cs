using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����C�ӭ��������A
public class Ingredient : KitchenObject
{
    [SerializeField] private IngredientSO ingredientSO;
    //��
    private bool needCut;
    private int maxCutCount = 10;
    private int cutCount = 0;
    //��
    private bool needPanfried;
    private float maxPanfriedTime = 5.0f;
    private float panfriedTime = 0f;

    private MeshFilter ingredientMeshFilter;
    private bool isFinished = false;    // =true=>���A��
    private void Start()
    {
        needCut = ingredientSO.cuttingMeshes.Count != 0;
        needPanfried = ingredientSO.panfriedMeshes.Count != 0;
        ingredientMeshFilter = this.gameObject.GetComponent<MeshFilter>();
        isFinished = !needCut && !needPanfried;
    }
    public IngredientSO GetIngredientSO()
    {
        return ingredientSO;
    }
    public bool CanCut()
    {
        return needCut;
    }
    public bool CanPanfried()
    {
        //���n�B�ݭn��
        return !needCut && needPanfried;
    }
    public bool IsProcessFinished()
    {
        return isFinished;
    }
    //������������
    public void Cut()
    {
        cutCount++;
        //���n
        if (cutCount >= maxCutCount)
        {
            needCut = false;
            isFinished = !needCut && !needPanfried;
            ingredientMeshFilter.mesh = ingredientSO.cuttingMeshes[2];
        }
        //����@�b
        else if (cutCount >= maxCutCount / 2)
        {
            ingredientMeshFilter.mesh = ingredientSO.cuttingMeshes[1];
        }
        //�٨S��
        else
        {
            ingredientMeshFilter.mesh = ingredientSO.cuttingMeshes[0];
        }
    }
    //�����Ϊ����
    public void Panfried()
    {
        panfriedTime += Time.deltaTime;
        //�J
        if (panfriedTime >= 2 * maxPanfriedTime)
        {
            needPanfried = true;
            isFinished = !needCut && !needPanfried;
            ingredientMeshFilter.mesh  = ingredientSO.panfriedMeshes[2];
        }
        //��
        else if (panfriedTime >= maxPanfriedTime)
        {
            needPanfried = false;
            isFinished = !needCut && !needPanfried;
            ingredientMeshFilter.mesh = ingredientSO.panfriedMeshes[1];
        }
        //��
        else
        {
            ingredientMeshFilter.mesh = ingredientSO.panfriedMeshes[0];
        }
    }
    //�����O�_����
}
