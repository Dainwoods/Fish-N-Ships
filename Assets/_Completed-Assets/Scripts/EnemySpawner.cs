using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject swordfish;
    public int[][] tileArr;
    public GameObject player;
    public GameObject point;
    public GameObject _hammerhead;

	// Use this for initialization
	void Start () {
        Invoke("spawnEnemies", .3f);
	}
	

    public void spawnEnemies() {
        int playX = (int)player.transform.position.x;
        int playY = (int)player.transform.position.y;
        //spawn a swordfish in a random location near the player
        float randX = Random.Range(-9, 9) + 0f;
        float randY = Random.Range(-7, 7) + 0f;
        this.spawnHammerhead(randX, randY, playX, playY);
        
        //if tile is a water tile, then call self again. else, spawn swordfish, then call self again.
        if (TileCreator.tileArr[58 + ((int)(playX + randX))][56 + ((int)(playY + randY))][0] == 0) {
            Invoke("spawnEnemies", Random.Range(0f, .4f));
        }
        else {
            GameObject sf = (GameObject)Instantiate(swordfish);
            sf.GetComponent<SwordfishAttack>().startPos(playX + randX + 0f, playY + randY + 0f, gameObject);
            Invoke("spawnEnemies", Random.Range(0f, .4f));
        }
        /*for(int x = -9; x < 9; x++) {
            for(int y = -7; y < 7; y++) {
                float rand = Random.Range(0, 4);
                if(rand > 1) {
                    GameObject sf = (GameObject)Instantiate(swordfish);
                    sf.GetComponent<SwordfishAttack>().startPos(playX + x + 0f, playY + y + 0f, this.gameObject);
                }
            }
        }*/
    }
    public void spawnHammerhead(float randX, float randY,float playX, float playY) {
        //spawn a hammerhead offscreen at either randX or randY.
        GameObject hammerhead = (GameObject)Instantiate(_hammerhead);
        //pass the random position relative to player to the HammerheadAttack
        hammerhead.GetComponent<HammerheadAttack>().aim(randX, randY, playX, playY, gameObject);
        //don't need to spawnenemies here. that'll be taken care of by swordfish.

    }
    public void tileUpdate(int[][][] tiles) {

    }
}
