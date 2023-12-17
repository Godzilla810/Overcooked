using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�����C�ӭ��������A
public class Ingredient : KitchenObject
{
    [SerializeField] private IngredientSO ingredientSO;
    [SerializeField] private GameObject progressUI;
    [SerializeField] private GameObject waringPart;
    private MeshFilter ingredientMeshFilter;
    private Progress progress;
    //��
    private bool needCut;
    private int maxCutCount = 10;
    private int cutCount = 0;
    //��
    private bool needPanfried;
    private float maxPanfriedTime = 5.0f;
    private float panfriedTime = 0f;

    private void Start()
    {
        progressUI.SetActive(false);
        needCut = ingredientSO.cuttingMeshes.Count != 0;
        needPanfried = ingredientSO.panfriedMeshes.Count != 0;
        ingredientMeshFilter = this.gameObject.GetComponent<MeshFilter>();
        progress = progressUI.GetComponent<Progress>();
    }
    //������������
    public void Cut()
    {
        progressUI.SetActive(true);
        progress.SetColorFillAmount((float)cutCount / maxCutCount);
        cutCount++;
        //���n
        if (cutCount >= maxCutCount)
        {
            progressUI.SetActive(false);
            needCut = false;
            SetMesh(ingredientSO.cuttingMeshes[2]);
        }
        //����@�b
        else if (cutCount >= maxCutCount / 2)
        {
            SetMesh(ingredientSO.cuttingMeshes[1]);
        }
        //�٨S��
        else
        {
            SetMesh(ingredientSO.cuttingMeshes[0]);
        }
    }
    //�����Ϊ����
    public void Panfried()
    {
        progressUI.SetActive(true);
        progress.SetColorFillAmount((panfriedTime / maxPanfriedTime) % 1.0f);
        panfriedTime += Time.deltaTime;
        //�J
        if (panfriedTime >= 2 * maxPanfriedTime)
        {
            progressUI.SetActive(false);
            needPanfried = true;
            SetMesh(ingredientSO.panfriedMeshes[2]);
        }
        //��
        else if (panfriedTime > maxPanfriedTime)
        {
            progress.SwitchToWarnColor();
            needPanfried = false;
            SetMesh(ingredientSO.panfriedMeshes[1]);
            if (panfriedTime > maxPanfriedTime + 2.5f)
            {
                waringPart.SetActive(true);
            }
        }
        //��
        else
        {
            SetMesh(ingredientSO.panfriedMeshes[0]);
        }
    }
    public IngredientSO GetIngredientSO()
    {
        return ingredientSO;
    }
    public bool CanCut()
    {
        //�ݭn��
        return needCut;
    }
    public bool CanPanfried()
    {
        //���n�B�ݭn��
        return !needCut && needPanfried;
    }
    public bool IsComplete()
    {
        return !needCut && !needPanfried;
    }
    private void SetMesh(Mesh mesh)
    {
        ingredientMeshFilter.mesh = mesh;
    }
}
