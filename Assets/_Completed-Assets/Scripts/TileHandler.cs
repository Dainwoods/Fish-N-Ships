using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHandler : MonoBehaviour {

    // Use this for initialization
    public BoxCollider2D collider;
    public Sprite grassSpr;
    public Sprite waterSpr;
    public Sprite S0000;
    public Sprite S0001;
    public Sprite S0010;
    public Sprite S0011;
    public Sprite S0100;
    public Sprite S0101;
    public Sprite S0110;
    public Sprite S0111;
    public Sprite S1000;
    public Sprite S1001;
    public Sprite S1010;
    public Sprite S1011;
    public Sprite S1100;
    public Sprite S1101;
    public Sprite S1110;
    public Sprite S1111;

    private bool configured = false;
    private SpriteRenderer sprRen;

    void Start() {
        if(!configured) {
            sprRen = GetComponent<SpriteRenderer>();
            collider.enabled = false;
            sprRen.sprite = grassSpr;
        }
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
                switch(wall[1]) {
                    case 0:
                        sprRen.sprite = S0000;
                        break;
                    case 1:
                        sprRen.sprite = S0001;
                        break;
                    case 2:
                        sprRen.sprite = S0010;
                        break;
                    case 3:
                        sprRen.sprite = S0011;
                        break;
                    case 4:
                        sprRen.sprite = S0100;
                        break;
                    case 5:
                        sprRen.sprite = S0101;
                        break;
                    case 6:
                        sprRen.sprite = S0110;
                        break;
                    case 7:
                        sprRen.sprite = S0111;
                        break;
                    case 8:
                        sprRen.sprite = S1000;
                        break;
                    case 9:
                        sprRen.sprite = S1001;
                        break;
                    case 10:
                        sprRen.sprite = S1010;
                        break;
                    case 11:
                        sprRen.sprite = S1011;
                        break;
                    case 12:
                        sprRen.sprite = S1100;
                        break;
                    case 13:
                        sprRen.sprite = S1101;
                        break;
                    case 14:
                        sprRen.sprite = S1110;
                        break;
                    case 15:
                        sprRen.sprite = S1111;
                        break;
                    default:
                        break;
                }
            }
            else {
                sprRen.sprite = S0000;
            }
        }
        else {
            collider.enabled = false;
            sprRen.sprite = grassSpr;
        }
    }
}
