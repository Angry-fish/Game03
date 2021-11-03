using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Line : MonoBehaviour
{
    public static CS_Line instance;

    public GameObject rightLine;
    public GameObject leftLine;
    public GameObject downLine;

    public GameObject checkBox;
    public Animator checkBoxAnimator;

    private void Start()
    {
        if(instance==null)instance=this;
        checkBoxAnimator = checkBox.GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (checkBoxAnimator == null) checkBoxAnimator = checkBox.GetComponent<Animator>();
    }

    public void PlayJustGet()
    {
        checkBoxAnimator.Play("JustGet", 0, 0f);
    }
    public void PlayPrefect()
    {
        checkBoxAnimator.Play("Prefect", 0, 0f);
    }
    public void PlayMiss()
    {
        checkBoxAnimator.Play("Miss", 0, 0f);
    }

}
