using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_UI : MonoBehaviour
{
    public static CS_UI instance;
    public GameObject Control;
    public CS_PlayerControl theControl;
    public Text comboText;
    public Text prefectText;
    void Start()
    {
        if(instance==null)instance=this;
        theControl = Control.GetComponent<CS_PlayerControl>();
    }

    private void Update()
    {
        comboText.text = theControl.combo.ToString();
        prefectText.text = theControl.prefectNum.ToString(); 
    }

}
