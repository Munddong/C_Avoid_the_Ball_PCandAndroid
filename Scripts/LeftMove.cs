using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMove : MonoBehaviour
{
    private float moveSpeed = 5f;
    public GameObject player;
    private bool move;


    public void LeftButtonTrue()
    {
        move = true;
    }

    public void LeftButtonFalse()
    {
        move = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            if (Input.GetMouseButton(0))
            {
                player.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            }
        }
    }
}
