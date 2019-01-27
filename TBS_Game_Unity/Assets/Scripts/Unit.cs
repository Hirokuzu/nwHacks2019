using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private UnitData unitData;

    // Update is called once per frame
    private void OnMouseDown()
    {
        Debug.Log(unitData.Name);
        Debug.Log(unitData.HP);
        Debug.Log(unitData.Attack);
        Debug.Log(unitData.Mov);
        Debug.Log(unitData.Special);
    }
}
