using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dishrack : Counter
{
    [SerializeField] private GameObject plate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public override void Interact()
    {
        //�I�s�����O���禡
        base.Interact();
        //�ۤv���禡
        Debug.Log("ChildClass - Interact");

    }*/
    public void GeneratePlate()
    {
        Instantiate(plate, this.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
    }

}
