using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_RightLeftDownMove : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerInputType myType;
    public GameObject child;
    public float arriveTime;
    private SpriteRenderer mySpriteRender;

    private float speed;
    private bool canMove;

    public void SetType(PlayerInputType type)
    {
        mySpriteRender = child.GetComponent<SpriteRenderer>();
        switch (type)
        {
            case PlayerInputType.LeftMove:
                mySpriteRender.color = new Color(1, 0, 0);
                transform.position = new Vector2(-9, 0);
                break;
            case PlayerInputType.RightMove:
                mySpriteRender.color = new Color(0, 0, 1);
                transform.position = new Vector2(9, 0);
                break;
            case PlayerInputType.DownMove:
                mySpriteRender.color = new Color(0, 1, 0);
                transform.position = new Vector2(0, -5);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                break;
        }
        myType = type;
        speed = (Vector2.Distance(transform.position, Vector2.zero) - 1.5f) / arriveTime;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, Vector2.zero) < .5f)
        {
            CS_PlayerControl.instance.Miss();
            Destroy(this.gameObject);
        }
    }


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (myType == CS_PlayerControl.instance.currentInputType && CS_PlayerControl.instance.isPlayAnima && CS_PlayerControl.instance.canDestroy)
            {
                CS_PlayerControl.instance.GetIt(Vector2.Distance(transform.position, Vector2.zero), myType);
                CS_PlayerControl.instance.canDestroy = false;
                Destroy(this.gameObject);
            }
        }
    }

}
