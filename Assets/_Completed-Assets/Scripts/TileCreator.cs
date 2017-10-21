using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreator : MonoBehaviour {

    private int[][] tileArr;
    private GameObject[][] tiles;
    public GameObject tile;

    private Vector2 tlTilePos;
    private Vector2 trTilePos;
    private Vector2 blTilePos;
    private Vector2 brTilePos;

    private Vector2 tlTileArr;
    private Vector2 trTileArr;
    private Vector2 blTileArr;
    private Vector2 brTileArr;

    private float leftTileDis;
    private float rightTileDis;
    private float upTileDis;
    private float downTileDis;

    private int width = 100;
    private int height = 100;

    // Use this for initialization
    void Start() {
        tileArr = new int[width][];
        tiles = new GameObject[width][];
        for(int i = 0; i < width; i++) {
            tileArr[i] = new int[height];
            tiles[i] = new GameObject[height];
            for(int j = 0; j < height; j++) {
                tiles[i][j] = null;
                if(i == 0 || i == width - 1 || j == 0 || j == height - 1) {
                    tileArr[i][j] = 0;
                }
                else {
                    tileArr[i][j] = Random.Range(0, 100);
                }
            }
        }

        GetComponent<EnemySpawner>().tileUpdate(tileArr);

        int maxX = 16;
        leftTileDis = ((maxX / 2) + 2.5f);
        rightTileDis = ((maxX / 2) + 1.5f);

        int maxY = 12;
        upTileDis = ((maxY / 2) + 2.5f);
        downTileDis = ((maxY / 2) + 1.5f);

        for(int i = -(maxX / 2) - 2; i <= (maxX / 2) + 1; i++) {
            for(int j = -(maxY / 2) - 1; j <= (maxY / 2) + 2; j++) {
                GameObject obj = (GameObject)Instantiate(tile);
                tiles[(width / 2) + i][(height / 2) + j] = obj;
                obj.GetComponent<TileHandler>().configure(tileArr[(width / 2) + i][(height / 2) + j]);
                Vector2 pos;
                pos.x = transform.position.x + i;
                pos.y = transform.position.y + j;
                obj.transform.position = pos;
                if(i == (-(maxX / 2)) - 2 && j == (maxY / 2) + 2) {
                    tlTilePos = pos;
                    tlTileArr.x = (width / 2) + i;
                    tlTileArr.y = (height / 2) + j;
                }
                else if(i == (maxX / 2) + 1 && j == (maxY / 2) + 2) {
                    trTilePos = pos;
                    trTileArr.x = (width / 2) + i;
                    trTileArr.y = (height / 2) + j;
                }
                else if(i == (-(maxX / 2)) - 2 && j == (-(maxY / 2)) - 1) {
                    blTilePos = pos;
                    blTileArr.x = (width / 2) + i;
                    blTileArr.y = (height / 2) + j;
                }
                else if(i == (maxX / 2) + 1 && j == (-(maxY / 2)) - 1) {
                    brTilePos = pos;
                    brTileArr.x = (width / 2) + i;
                    brTileArr.y = (height / 2) + j;
                }
            }
        }
    }

    private void Update() {
        float x = transform.position.x;
        float y = transform.position.y;
        if(Mathf.Abs(x - tlTilePos.x) > leftTileDis && trTileArr.x < width - 1) {
            for(int i = (int)tlTileArr.y; i >= (int)blTileArr.y; i--) {
                GameObject obj = tiles[(int)tlTileArr.x][i];
                Vector3 pos = new Vector3(trTilePos.x + 1, obj.transform.position.y, 0);
                obj.transform.position = pos;
                int con = tileArr[(int)trTileArr.x + 1][i];
                obj.GetComponent<TileHandler>().configure(con);
                tiles[(int)trTileArr.x + 1][i] = obj;
                tiles[(int)tlTileArr.x][i] = null;
            }
            tlTileArr.x += 1;
            trTileArr.x += 1;
            blTileArr.x += 1;
            brTileArr.x += 1;

            tlTilePos.x += 1;
            trTilePos.x += 1;
            blTilePos.x += 1;
            brTilePos.x += 1;
        }

        if(Mathf.Abs(x - trTilePos.x) > rightTileDis && tlTileArr.x > 0) {
            for(int i = (int)trTileArr.y; i >= (int)brTileArr.y; i--) {
                GameObject obj = tiles[(int)trTileArr.x][i];
                Vector3 pos = new Vector3(tlTilePos.x - 1, obj.transform.position.y, 0);
                obj.transform.position = pos;
                int con = tileArr[(int)tlTileArr.x - 1][i];
                obj.GetComponent<TileHandler>().configure(con);
                tiles[(int)tlTileArr.x - 1][i] = obj;
                tiles[(int)trTileArr.x][i] = null;
            }
            tlTileArr.x -= 1;
            trTileArr.x -= 1;
            blTileArr.x -= 1;
            brTileArr.x -= 1;

            tlTilePos.x -= 1;
            trTilePos.x -= 1;
            blTilePos.x -= 1;
            brTilePos.x -= 1;
        }

        if(Mathf.Abs(y - tlTilePos.y) > upTileDis && blTileArr.y > 0) {
            for(int i = (int)tlTileArr.x; i <= (int)trTileArr.x; i++) {
                GameObject obj = tiles[i][(int)tlTileArr.y];
                Vector3 pos = new Vector3(obj.transform.position.x, blTilePos.y - 1, 0);
                obj.transform.position = pos;
                int con = tileArr[i][(int)blTileArr.y - 1];
                obj.GetComponent<TileHandler>().configure(con);
                tiles[i][(int)blTileArr.y - 1] = obj;
                tiles[i][(int)tlTileArr.y] = null;
            }
            tlTileArr.y -= 1;
            trTileArr.y -= 1;
            blTileArr.y -= 1;
            brTileArr.y -= 1;

            tlTilePos.y -= 1;
            trTilePos.y -= 1;
            blTilePos.y -= 1;
            brTilePos.y -= 1;
        }

        if(Mathf.Abs(y - blTilePos.y) > downTileDis && tlTileArr.y < height - 1) {
            for(int i = (int)blTileArr.x; i <= (int)brTileArr.x; i++) {
                GameObject obj = tiles[i][(int)blTileArr.y];
                Vector3 pos = new Vector3(obj.transform.position.x, tlTilePos.y + 1, 0);
                obj.transform.position = pos;
                int con = tileArr[i][(int)tlTileArr.y + 1];
                obj.GetComponent<TileHandler>().configure(con);
                tiles[i][(int)tlTileArr.y + 1] = obj;
                tiles[i][(int)blTileArr.y] = null;
            }
            tlTileArr.y += 1;
            trTileArr.y += 1;
            blTileArr.y += 1;
            brTileArr.y += 1;

            tlTilePos.y += 1;
            trTilePos.y += 1;
            blTilePos.y += 1;
            brTilePos.y += 1;
        }
    }
}
