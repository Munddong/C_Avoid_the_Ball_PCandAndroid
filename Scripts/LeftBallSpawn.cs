using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBallSpawn : MonoBehaviour
{
    public GameObject[] ballCount;
    public GameObject[] itemCount;
    private int ball;
    private int item;
    private float ballSize = 0f;
    private float ballSpawn = 0f;
    private float itemSpawn = 0f;
    private float interval = 0f;

    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        StartCoroutine(Spawn());
        StartCoroutine(iTemSpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawn()
    {
        while (true)
        {
            ballSize = Random.Range(0.5f, 1.0f); // 볼 크기
            ballSpawn = Random.Range(3.0f, 5.0f); // 볼이 생성되는 위치

            itemSpawn = Random.Range(0.5f, 1.0f); // 아이템이 생성되는 위치

            interval = Random.Range(3.0f, 5.0f); // 간격
            ball = Random.Range(0, 6);

            ballCount[ball].gameObject.transform.localScale = new Vector3(ballSize, ballSize, 0f);

            GameObject spawn = Instantiate(ballCount[ball], this.transform.position + new Vector3(2.0f, ballSpawn, 0f), Quaternion.identity);


            spawn.GetComponent<Rigidbody2D>().AddForce(transform.right * interval, ForceMode2D.Impulse);

            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator iTemSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            GameObject spawn1 = Instantiate(itemCount[item], this.transform.position + new Vector3(2.0f, itemSpawn, 0f), Quaternion.identity);
            spawn1.GetComponent<Rigidbody2D>().AddForce(transform.right * interval, ForceMode2D.Impulse);

            yield return new WaitForSeconds(11.0f);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            coll.gameObject.SetActive(false);
        }
    }
}
