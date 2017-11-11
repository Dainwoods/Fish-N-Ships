using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHandler : MonoBehaviour {

    // Use this for initialization
    public BoxCollider2D collider;
    public Sprite grassSpr;
    public Sprite waterSpr;

    private bool configured = false;
    private SpriteRenderer sprRen;
    private Sprite[] sandToWater;

    public GameObject rock;
    public GameObject tree;


    void Start() {
        

        if(!configured) {
            sprRen = GetComponent<SpriteRenderer>();
            collider.enabled = false;
            sprRen.sprite = grassSpr;
        }
    }

    public void setUpSprites(Sprite[] wSprite) {
        sandToWater = wSprite;
    }

    public void configure(int[] wall) {
        configured = true;
        sprRen = GetComponent<SpriteRenderer>();
        if(wall[0] == 0) {
            collider.enabled = true;
            sprRen.sprite = waterSpr;
        }
        else if(wall[0] == 1){
            collider.enabled = false;
            if(wall[2] == 0) {
                sprRen.sprite = sandToWater[wall[1]];
            }
            else {
                sprRen.sprite = sandToWater[255];
            }
        }
        else {
            collider.enabled = false;
            sprRen.sprite = grassSpr;
        }

        if(wall[3] == 1) {
            GameObject rockObj = (GameObject)Instantiate(rock);
            Vector2 pos = transform.position;
            rockObj.transform.position = pos;
            collider.enabled = true;
            rockObj.name = "rock" + pos.x + pos.y;
        }
        else if(wall[3] == 2) {
            GameObject treeObj = (GameObject)Instantiate(tree);
            Vector2 pos = transform.position;
            treeObj.transform.position = pos;
            collider.enabled = true;
            treeObj.name = "tree" + pos.x + pos.y;
        }
    }
}
