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
        Invoke("spawnEnemies", 5);
	}
	

    public void spawnEnemies() {
        point.transform.position = player.transform.position;
        timer = Time.deltaTime;
        int playX = (int)player.transform.position.x;
        int playY = (int)player.transform.position.y;
        for(int x = -9; x < 9; x++) {
            for(int y = -7; y < 7; y++) {
                float rand = Random.Range(0, 4);
                if(rand > 1) {
                    GameObject sf = (GameObject)Instantiate(swordfish);
                    sf.GetComponent<SwordfishAttack>().startPos(playX + x + 0f, playY + y + 0f, this.gameObject);
                }
            }
        }
    }

    public void tileUpdate(int[][] tiles) {

    }
}
