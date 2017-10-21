using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject swordfish;
    public int[][] tileArr;
    public GameObject player;
    public GameObject point;

    private float timer;

	// Use this for initialization
	void Start () {
        Invoke("spawnEnemies", .3f);
	}
	

    public void spawnEnemies() {
        timer = Time.deltaTime;
        int playX = (int)player.transform.position.x;
        int playY = (int)player.transform.position.y;
        float randX = (int)Random.Range(-9, 9) + 0f;
        float randY = (int)Random.Range(-7, 7) + 0f;
        GameObject sf = (GameObject)Instantiate(swordfish);
        sf.GetComponent<SwordfishAttack>().startPos(playX + randX + 0f, playY + randY + 0f, gameObject);
        
        /*for(int x = -9; x < 9; x++) {
            for(int y = -7; y < 7; y++) {
                float rand = Random.Range(0, 4);
                if(rand > 1) {
                    GameObject sf = (GameObject)Instantiate(swordfish);
                    sf.GetComponent<SwordfishAttack>().startPos(playX + x + 0f, playY + y + 0f, this.gameObject);
                }
            }
        }*/
        Invoke("spawnEnemies", Random.Range(0f, .4f));
    }

    public void tileUpdate(int[][] tiles) {

    }
}
