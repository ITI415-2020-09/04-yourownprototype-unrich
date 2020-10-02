using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PickUpPrefabs;
    public static System.Random rnd = new System.Random();

        void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            int x = rnd.Next(-8, 8);
            int y = rnd.Next(2, 9);
            Instantiate(PickUpPrefabs, new Vector3(x, y, 0),  Quaternion.identity);
            Debug.Log("aaaaaa");
        }   
    }
}
