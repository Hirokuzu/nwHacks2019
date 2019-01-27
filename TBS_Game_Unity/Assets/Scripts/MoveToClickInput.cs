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
            if (a <= unitData.Mov) {
                if (Math.Abs(Math.Abs(clickedPos.x) - Math.Abs(transform.position.x)) > Math.Abs(Math.Abs(clickedPos.y) - Math.Abs(transform.position.y))) 
                {
                    clickedPos.x = (int)clickedPos.x;
                    clickedPos.y = transform.position.y;
                }
                else
                {
                    clickedPos.x = transform.position.x;
                    clickedPos.y = (int)clickedPos.y;
                }
                transform.position = clickedPos;
                Debug.Log(transform.position);
            }
        }
    }
}
