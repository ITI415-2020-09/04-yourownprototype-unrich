using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Slingshot : MonoBehaviour
{
    public GameObject prefabsProjectile;
    public float speed = 0;
    public float velocityMult = 4f;
    public bool _____________________________;
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    static public Slingshot S;
    private float movementX;
    private float movementY;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("1");
    }
    
    void Awake()
    {
        S = this;
        Debug.Log("3");
    }

    void OnMouseEnter()
    {
        launchPoint.SetActive(true);
        Debug.Log("4");
    }

    void OnMouseExit()
    {
        launchPoint.SetActive(false);
        Debug.Log("5");
    }

    void OnMouseDown()
    {
        aimingMode = true;
        projectile = Instantiate(prefabsProjectile) as GameObject;
        projectile.transform.position = launchPos;
        projectile.GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log("6");
    }

    // Update is called once per frame
    void Update()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
        //Debug.Log("7");
        if (!aimingMode) return;
        Debug.Log("14");
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 mouseDelta = mousePos3D - launchPos;
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        Debug.Log("8");
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
            Debug.Log("9");
        }
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;
        Debug.Log("10");

        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectile.GetComponent<Rigidbody>().isKinematic = false;
            projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;
            projectile = null;
            Debug.Log("11");
        }
        Debug.Log("12");
    }

}

