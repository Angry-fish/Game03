using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerInputType
{
    No, LeftMove, RightMove, DownMove, LeftDown, RightDown
}
public class CS_PlayerControl : MonoBehaviour
{
    public static CS_PlayerControl instance;
    
    public Vector2 nowMouseP;
    public Vector2 nextMouseP;
    public Animator myAnimator;
    public int combo;
    public int prefectNum;
    public PlayerInputType currentInputType;
    public bool isPlayAnima;
    public bool canDestroy = true;
    public float xOffset;
    public float yOffset;
    public float maxXOffset;
    public float maxYOffset;
    public int next;
    void Start()
    {
        if (instance == null) instance = this;

        myAnimator = GetComponent<Animator>();
    }

    public void SetMouse()
    {
        nowMouseP = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation=Quaternion.Euler(new Vector3(0,0,next*90));
        if (Input.GetKeyDown(KeyCode.N))
        {
            SetMouse();
        }
        CanDestroyColor();
        nextMouseP = Input.mousePosition;
        xOffset = nextMouseP.x - nowMouseP.x;
        yOffset = nextMouseP.y - nowMouseP.y;

        if (Mathf.Abs(xOffset) <= maxXOffset
        && Mathf.Abs(yOffset) <= maxYOffset
        && isPlayAnima)
        {
            AnimaEnd();
        }

        //if (isPlayAnima) return;
        if (yOffset < -maxYOffset)
        {
            if(currentInputType!=PlayerInputType.DownMove)AnimaEnd();
            AnimaBegin();
            currentInputType = PlayerInputType.DownMove;
            //myAnimator.Play("DownMove", 0, 0f);
        }
        if (xOffset < -maxXOffset)
        {
             if(currentInputType!=PlayerInputType.LeftMove)AnimaEnd();
            AnimaBegin();
            currentInputType = PlayerInputType.LeftMove;
            //myAnimator.Play("LeftMove", 0, 0f);
        }
        if (xOffset > maxXOffset)
        {
            if(currentInputType!=PlayerInputType.RightMove)AnimaEnd();
            AnimaBegin();
            currentInputType = PlayerInputType.RightMove;
            //myAnimator.Play("RightMove", 0, 0f);
        }

    }

    public void CanDestroyColor()
    {
        if (canDestroy)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 0);
        }
    }
    public void GetIt(float dis, PlayerInputType type)
    {
        combo++;
        switch (type)
        {
            case PlayerInputType.RightMove:
            case PlayerInputType.LeftMove:
            case PlayerInputType.DownMove:
                if (1.3f < dis && dis < 1.7f)
                {
                    CS_Line.instance.PlayPrefect();
                    prefectNum++;
                }
                else
                {
                    CS_Line.instance.PlayJustGet();
                }
                break;
        }
    }
    public void Miss()
    {
        CS_Line.instance.PlayMiss();
        combo = 0;
    }
    public void AnimaBegin()
    {
        isPlayAnima = true;
    }
    public void AnimaEnd()
    {
        isPlayAnima = false;
        //myAnimator.Play("Idle", 0, 0f);
        canDestroy = true;
    }
}
