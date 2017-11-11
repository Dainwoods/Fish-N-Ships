using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerheadAttack : MonoBehaviour {
    public Collider2D hammerheadCol;
    private GameObject _player;

    private Collider2D playCol;
    private bool hit;
    // 0 is right, 1 is left
    private int direction;

    // Use this for initialization
    void Start () {
        hit = false;
        Invoke("Disappear", 2);
       
      
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 newPos = new Vector2();
		if (direction == 0)
        {
            newPos.Set(transform.position.x + 1, transform.position.y);
        }
        else
        {
            newPos.Set(transform.position.x - 1, transform.position.y);
        }
        //TODO: if this tile contains tree,rock 
        //if (TileCreator.tileArr[(int)newPos.x][(int)newPos.y][0] != 0)
        //{
        //    Invoke("Disappear", 2);
        //}

        //move the hammerhead
        transform.position = newPos;
        hammerheadCol.isTrigger = true;
        //if the hammerhead hits the player, they take damage and it dissappears
        if (hammerheadCol.IsTouching(playCol))
        {
            _player.GetComponent<PlayerState>().takeDamage();
            Invoke("Disappear", 0);
        }
        //if it goes offscreen, it disappears
        int playX = (int)_player.transform.position.x;
        if (transform.position.x < playX-10 || transform.position.x >playX+ 10)
        {
            Invoke("Disappear", 0);
        }
    }
    public void aim(float x, float y, float playX, float playY, GameObject player)
    {
        _player = player;
        playCol = player.GetComponent<Collider2D>();
        //for now only horizontal hammerhead strike. random decides direction.
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            Vector2 startPos = new Vector2( playX-10, playY + y);
            transform.position = startPos;
            direction = 0;
        }
        else
        {
            Vector2 startPos = new Vector2(playX+10, y);
            transform.position = startPos;
            direction = 1;
        }
        
    }
    private void Disappear()
    {
        Destroy(this.gameObject);
    }
}
