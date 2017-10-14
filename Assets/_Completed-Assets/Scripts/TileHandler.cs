using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHandler : MonoBehaviour {

    // Use this for initialization
    public BoxCollider2D collider;
    public Sprite floorSpr;
    public Sprite wallSpr;

    private bool configured = false;

    void Start() {
        if(!configured) {
            SpriteRenderer sprRen = GetComponent<SpriteRenderer>();
            collider.enabled = false;
            sprRen.sprite = floorSpr;
        }
    }

    public void configure(int wall) {
        configured = true;
        SpriteRenderer sprRen = GetComponent<SpriteRenderer>();
        if(wall == 0) {
            collider.enabled = true;
            sprRen.sprite = wallSpr;

        }
        else {
            collider.enabled = false;
            sprRen.sprite = floorSpr;
        }
    }
}
