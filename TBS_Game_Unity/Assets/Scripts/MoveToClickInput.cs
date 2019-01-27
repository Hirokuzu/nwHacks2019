using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            //float a = Vector3.Distance(clickedPos, transform.position);
           // if (a <= unitData.Mov) {
            transform.position = clickedPos;
            Debug.Log(transform.position);
           // }
        }
    }
}
