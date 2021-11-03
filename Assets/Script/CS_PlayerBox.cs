using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PlayerBox : MonoBehaviour
{
    public GameObject child;
    public CS_PlayerControl player;

    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        player = CS_PlayerControl.instance;
        if (player)
        {
            player = child.GetComponent<CS_PlayerControl>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player==null)player = child.GetComponent<CS_PlayerControl>();
        //Old();
        New();

    }

    void Old(){
        x=player.xOffset / player.maxXOffset;
        if(x>1)x=1;
        if(x<-1)x=-1;

        y=player.yOffset / player.maxYOffset;
        if(y>1)y=1;
        if(y<-1)y=-1;

        transform.position = new Vector2(x,y);
    }

    void New(){
         x=player.xOffset / player.maxXOffset;
        if(x>1.5f)x=1.5f;
        if(x<-1.5f)x=-1.5f;

        y=player.yOffset / player.maxYOffset;
        if(y>1.5f)y=1.5f;
        if(y<-1.5f)y=-1.5f;

        transform.position = new Vector2(x,y);
    }
}
