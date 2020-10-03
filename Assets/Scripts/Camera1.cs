using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera1 : MonoBehaviour
{
    static public Camera1 S;
    public UnityEngine.UI.Text countText;
    public UnityEngine.UI.Text shotText;
    public GameObject winTextObject;
    private int count;
    private int shotTaken;
 
    void Start()
    {
        shotTaken = 0;
        count = 0;
        winTextObject.SetActive(false);
    }

    void Awake()
    {
        S = this;
    }
    void ShowText()
    {
        shotText.text = "Shots Taken: " + shotTaken;
        countText.text = "Count: " + count.ToString();
        if (count == 6)
        {
            winTextObject.SetActive(true);
        }
    }

    public void SetCountText()
    {
        count++;
    }

    public static void shotFired()
    {
        S.shotTaken++;
    }

    void Update()
    {
        ShowText();
    }
}

