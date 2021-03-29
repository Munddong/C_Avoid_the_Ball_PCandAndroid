using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Color color;
    public GameObject middleGround;
    public GameObject chartImage;
    public GameObject replayImage;
    public GameObject[] backGroundSize;

    public AudioClip itemGetSound;
    private AudioSource audioSource;

    public Score scorePanel;
    private int speed = 10;

    private int backGround;

    // Start is called before the first frame update
    void Start()
    {
        backGround = Random.Range(0, 4);
        backGroundSize[backGround].SetActive(true);

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        this.transform.Translate(new Vector3(xMove, 0, 0));
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            gameObject.SetActive(false);

            Score.isDead = true;

            middleGround.SetActive(true);
            chartImage.SetActive(true);
            replayImage.SetActive(true);

            scorePanel.ScoreEnd();
        }

        if (coll.gameObject.tag == "item")
        {
            StartCoroutine(invincibility());
        }

        IEnumerator invincibility()
        {
            audioSource.PlayOneShot(itemGetSound);

            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Yomi"), LayerMask.NameToLayer("Ball"), true);

            SpriteRenderer Yomi = gameObject.GetComponent<SpriteRenderer>();
            Yomi.color = new Color(Yomi.color.r, Yomi.color.g, Yomi.color.b, 0.5f);

            yield return new WaitForSeconds(3);

            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Yomi"), LayerMask.NameToLayer("Ball"), false);
            Yomi.color = new Color(Yomi.color.r, Yomi.color.g, Yomi.color.b, 1.0f);
        }
    }
}
