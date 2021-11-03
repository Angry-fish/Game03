using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_LittleLeftDownMove : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerInputType myType;
    public float arriveTime;
    public bool isTheEnd;
    public float offSet;
    private SpriteRenderer mySpriteRender;
    private float speed;
    private bool canMove;
    private Vector2 pos;



    public void SetType(PlayerInputType type,float offset,bool isend)
    {
        mySpriteRender = GetComponent<SpriteRenderer>();
        this.offSet=offset;
        isTheEnd=isend;
        switch (type)
        {
            case PlayerInputType.LeftMove:
                mySpriteRender.color = new Color(1, 0, 0);
                transform.position = new Vector2(-9, offSet);
                pos=new Vector2(0, offSet);
                break;
            case PlayerInputType.RightMove:
                mySpriteRender.color = new Color(0, 0, 1);
                transform.position = new Vector2(9, offSet);
                 pos=new Vector2(0, offSet);
                break;
            case PlayerInputType.DownMove:
                mySpriteRender.color = new Color(0, 1, 0);
                transform.position = new Vector2(offSet, -5);
                 pos=new Vector2(offSet,0);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                break;
        }
        myType = type;
        speed = (Vector2.Distance(transform.position, pos) - 1.5f) / arriveTime;
        canMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, pos) < .3f)
        {
            CS_PlayerControl.instance.Miss();
            Destroy(this.gameObject);
        }
    }


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (myType == CS_PlayerControl.instance.currentInputType && CS_PlayerControl.instance.isPlayAnima 
            && CS_PlayerControl.instance.canDestroy&& Vector2.Distance(transform.position, pos)<1.6f)
            {
                CS_PlayerControl.instance.GetIt(Vector2.Distance(transform.position, pos), myType);
                if(isTheEnd)CS_PlayerControl.instance.canDestroy = false;
                Destroy(this.gameObject);
            }
        }
    }

}
