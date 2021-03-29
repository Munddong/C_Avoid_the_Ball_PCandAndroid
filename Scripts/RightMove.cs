using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMove : MonoBehaviour
{
    private float moveSpeed = 5f;
    public GameObject player;
    private bool move;


    public void RightButtonTrue()
    {
        move = true;
    }

    public void RightButtonFalse()
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
                player.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }
        }
    }
}
