using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Anima : MonoBehaviour
{
    public static CS_Anima instance;
    public GameObject BoardParent;
    public GameObject Control;
    public CS_PlayerControl theControl;

    public GameObject MoveBoard;
    private GameObject tempMoveBoard;

    public GameObject LittleMoveBoard;
    private GameObject tempLittleMoveBoard;


    public float LittleMoveWaitTime;


    public float leftLittleOffset;
    public float leftLittleOffsetSpeed;
    public int leftLittleIndex;
    private IEnumerator LeftLittleIE;


    public float rightLittleOffset;
    public float rightLittleOffsetSpeed;
    public int rightLittleIndex;
    private IEnumerator RightLittleIE;

    public float downLittleOffset;
    public float downLittleOffsetSpeed;
    public int downLittleIndex;
    private IEnumerator DownLittleIE;





    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            theControl.combo=0;
            theControl.prefectNum=0;
            while(BoardParent.transform.childCount >= 1){
                Destroy(BoardParent.transform.GetChild(0));
            }
            GetComponent<Animator>().Play("Game", 0, 0f);
        }
        if (BoardParent.transform.childCount == 0) return;
        if (BoardParent.transform.GetChild(0).GetComponent<CS_LittleLeftDownMove>() != null)
        {
            switch (BoardParent.transform.GetChild(0).GetComponent<CS_LittleLeftDownMove>().myType)
            {
                case PlayerInputType.RightMove:
                    theControl.next = 0;
                    break;
                case PlayerInputType.LeftMove:
                    theControl.next = 2;
                    break;
                case PlayerInputType.DownMove:
                    theControl.next = -1;
                    break;
            }
        }
        if (BoardParent.transform.GetChild(0).GetComponent<CS_RightLeftDownMove>() != null)
        {
            switch (BoardParent.transform.GetChild(0).GetComponent<CS_RightLeftDownMove>().myType)
            {
                case PlayerInputType.RightMove:
                    theControl.next = 0;
                    break;
                case PlayerInputType.LeftMove:
                    theControl.next = 2;
                    break;
                case PlayerInputType.DownMove:
                    theControl.next = -1;
                    break;
            }
        }
    }
    void Start()
    {
        if (instance == null) instance = this;
        theControl = Control.GetComponent<CS_PlayerControl>();

        RightLittleIE = IErightMove();
        LeftLittleIE = IEleftMove();
        DownLittleIE = IEdownMove();
    }
    public void RightMove()
    {
        tempMoveBoard = Instantiate(MoveBoard);
        tempMoveBoard.transform.SetParent(BoardParent.transform);
        tempMoveBoard.GetComponent<CS_RightLeftDownMove>().SetType(PlayerInputType.RightMove);
    }
    public void LeftMove()
    {
        tempMoveBoard = Instantiate(MoveBoard);
        tempMoveBoard.transform.SetParent(BoardParent.transform);
        tempMoveBoard.GetComponent<CS_RightLeftDownMove>().SetType(PlayerInputType.LeftMove);
    }
    public void DownMove()
    {
        tempMoveBoard = Instantiate(MoveBoard);
        tempMoveBoard.transform.SetParent(BoardParent.transform);
        tempMoveBoard.GetComponent<CS_RightLeftDownMove>().SetType(PlayerInputType.DownMove);
    }




    public void RightLittleMoveBegin()
    {
        if (RightLittleIE != null) StopCoroutine(RightLittleIE);
        StartCoroutine(RightLittleIE);
    }
    public void RightLittleMoveEnd()
    {
        if (RightLittleIE != null) StopCoroutine(RightLittleIE);
        tempLittleMoveBoard = Instantiate(LittleMoveBoard);
        tempLittleMoveBoard.transform.SetParent(BoardParent.transform);
        tempLittleMoveBoard.GetComponent<CS_LittleLeftDownMove>().SetType(PlayerInputType.RightMove, rightLittleOffset, true);
    }
    public void RightLittleDown(float speed)
    {
        rightLittleIndex = -1;
        rightLittleOffsetSpeed = speed;
    }
    public void RightLittleUp(float speed)
    {
        rightLittleIndex = 1;
        rightLittleOffsetSpeed = speed;
    }
    public void RightNoOffset()
    {
        rightLittleIndex = 0;
        rightLittleOffsetSpeed = 0;
    }
    public void RightSetOffset(float offset)
    {
        rightLittleOffset = offset;
    }


    public void LeftLittleMoveBegin()
    {
        if (LeftLittleIE != null) StopCoroutine(LeftLittleIE);
        StartCoroutine(LeftLittleIE);
    }
    public void LeftLittleMoveEnd()
    {
        if (LeftLittleIE != null) StopCoroutine(LeftLittleIE);
        tempLittleMoveBoard = Instantiate(LittleMoveBoard);
        tempLittleMoveBoard.transform.SetParent(BoardParent.transform);
        tempLittleMoveBoard.GetComponent<CS_LittleLeftDownMove>().SetType(PlayerInputType.LeftMove, leftLittleOffset, true);
    }
    public void LeftLittleDown(float speed)
    {
        leftLittleIndex = -1;
        leftLittleOffsetSpeed = speed;
    }
    public void LeftLittleUp(float speed)
    {
        leftLittleIndex = 1;
        leftLittleOffsetSpeed = speed;
    }
    public void LeftNoOffset()
    {
        rightLittleIndex = 0;
        rightLittleOffsetSpeed = 0;
    }
    public void LeftSetOffset(float offset)
    {
        leftLittleOffset = offset;
    }

    public void DownLittleMoveBegin()
    {
        if (DownLittleIE != null) StopCoroutine(DownLittleIE);
        StartCoroutine(DownLittleIE);
    }
    public void DownLittleMoveEnd()
    {
        if (DownLittleIE != null) StopCoroutine(DownLittleIE);
        tempLittleMoveBoard = Instantiate(LittleMoveBoard);
        tempLittleMoveBoard.transform.SetParent(BoardParent.transform);
        tempLittleMoveBoard.GetComponent<CS_LittleLeftDownMove>().SetType(PlayerInputType.DownMove, downLittleOffset, true);
    }
    public void DownLittleLeft(float speed)
    {
        downLittleIndex = -1;
        downLittleOffsetSpeed = speed;
    }
    public void DownLittleRight(float speed)
    {
        downLittleIndex = 1;
        downLittleOffsetSpeed = speed;
    }
    public void DownNoOffset()
    {
        downLittleIndex = 0;
        downLittleOffsetSpeed = 0;
    }
    public void DownSetOffset(float offset)
    {
        downLittleOffset = offset;
    }
    IEnumerator IErightMove()
    {
        while (true)
        {
            tempLittleMoveBoard = Instantiate(LittleMoveBoard);
            tempLittleMoveBoard.transform.SetParent(BoardParent.transform);
            tempLittleMoveBoard.GetComponent<CS_LittleLeftDownMove>().SetType(PlayerInputType.RightMove, rightLittleOffset, false);
            rightLittleOffset += rightLittleOffsetSpeed * rightLittleIndex;
            if (rightLittleOffset > 1) rightLittleOffset = 1;
            if (rightLittleOffset < -1) rightLittleOffset = -1;
            yield return new WaitForSecondsRealtime(LittleMoveWaitTime);
        }
    }
    IEnumerator IEleftMove()
    {
        while (true)
        {
            tempLittleMoveBoard = Instantiate(LittleMoveBoard);
            tempLittleMoveBoard.transform.SetParent(BoardParent.transform);
            tempLittleMoveBoard.GetComponent<CS_LittleLeftDownMove>().SetType(PlayerInputType.LeftMove, leftLittleOffset, false);
            leftLittleOffset += leftLittleOffsetSpeed * leftLittleIndex;
            if (leftLittleOffset > 1) leftLittleOffset = 1;
            if (leftLittleOffset < -1) leftLittleOffset = -1;
            yield return new WaitForSecondsRealtime(LittleMoveWaitTime);
        }
    }
    IEnumerator IEdownMove()
    {
        while (true)
        {
            tempLittleMoveBoard = Instantiate(LittleMoveBoard);
            tempLittleMoveBoard.transform.SetParent(BoardParent.transform);
            tempLittleMoveBoard.GetComponent<CS_LittleLeftDownMove>().SetType(PlayerInputType.DownMove, downLittleOffset, false);
            downLittleOffset += downLittleOffsetSpeed * downLittleIndex;
            if (downLittleOffset > 1) downLittleOffset = 1;
            if (downLittleOffset < -1) downLittleOffset = -1;
            yield return new WaitForSecondsRealtime(LittleMoveWaitTime);
        }
    }
}
