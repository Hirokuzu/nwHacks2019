using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveToClickInput : MonoBehaviour
{
    [SerializeField]
    private UnitData unitData;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var clickedPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int a = (int)Vector3.Distance(clickedPos, transform.position);
            if (Math.Abs((int)clickedPos.x - (int)transform.position.x + (int)clickedPos.y - (int)transform.position.y) <= unitData.Mov) {
                clickedPos.x = (int)clickedPos.x;
                clickedPos.y = (int)clickedPos.y;
                transform.position = clickedPos;
                Debug.Log(transform.position);
                Debug.Log(unitData.Mov);
            }
           
        }
    }
}
