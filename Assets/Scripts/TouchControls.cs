using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TouchControls : MonoBehaviour
{

    private PlayerMove PlayerMove;


    void Start()
    {
        PlayerMove = GetComponent<PlayerMove>();




        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            UnityEngine.Touch touch = Input.GetTouch(0);
            Vector3 touch_Pos = Camera.main.ScreenToWorldPoint(touch.position);


            if (touch_Pos.x > 0)
            {

                PlayerMove.MoveRight();
            }
            else if (touch_Pos.x < 0)
            {
                PlayerMove.MoveLeft();

            }

            else
            {
                PlayerMove.StopMoving();

            }

        }

    }


}//class
