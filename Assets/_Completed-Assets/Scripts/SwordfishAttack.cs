using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordfishAttack : MonoBehaviour {

    public Collider2D swordCol;
    private GameObject player;
    public Sprite swordfish;

    private Collider2D playCol;
    private bool grounded;
    SpriteRenderer sprRen;

    void Start() {
        grounded = false;
        transform.localScale = new Vector3(0, 0, 0);
        sprRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        float timer = Time.deltaTime;
        if(transform.localScale.x < 1) {
            timer += Time.deltaTime;
            transform.localScale += new Vector3(1, 1, 1) * .5f * Time.deltaTime;
        }
        else if(!grounded) {
            timer = Time.deltaTime;
            grounded = true;
            sprRen.sprite = swordfish;
            swordCol.isTrigger = true;
            if(swordCol.IsTouching(playCol)) {
                player.GetComponent<PlayerState>().takeDamage();
            }
            Invoke("Disappear", 2);
        }
        else if(Time.deltaTime > 3) {
            Destroy(this.gameObject);
        }
	}

    private void Disappear() {
        Destroy(this.gameObject);
    }

    public void startPos(float x, float y, GameObject play) {
        player = play;
        playCol = player.GetComponent<Collider2D>();
        Vector2 pos = new Vector2(x, y);
        transform.position = pos;
    }
}
