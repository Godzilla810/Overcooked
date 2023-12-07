using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class CuttingCounter : ClearCounter
{
    private Ingredient ingredient;
    public delegate void CutEventHandler(bool isCutting);
    public static event CutEventHandler CutBool;

    public override void Cut()
    {
        //�չ�����ӭ���
        ingredient = this.GetKitchenObject() is Ingredient ? this.GetKitchenObject() as Ingredient : null;
        //�������~���
        if (ingredient != null && ingredient.CanCut())
        {
            ingredient.Cut();
            CutBool?.Invoke(true);
        }
        else
        {
            CutBool?.Invoke(false);
        }
    }
}
