using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private enum counterTypes { Counter, Crate, Stove, Dishrack, Cuttingboard }
    [SerializeField] private counterTypes counterType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact()
    {
        Debug.Log(counterType.ToString());
    }
}
