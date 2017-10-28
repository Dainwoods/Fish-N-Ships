using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreator : MonoBehaviour {

    public static int[][][] tileArr;
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

    private int width = 116;
    private int height = 112;

    // Use this for initialization
    void Start() {
        int edgeWidth = 9; //8
        int edgeHeight = 7; //6

        tileArr = new int[width][][];
        tiles = new GameObject[width][];
        
        createOuterWater(edgeWidth, edgeHeight);
        createIslandShape(edgeWidth, edgeHeight);
        //placeLakes(edgeWidth, edgeHeight);
        createSandTiles(edgeWidth, edgeHeight);
        setTileImage(edgeWidth, edgeHeight);
        //createTreesRocks(edgeWidth, edgeHeight);

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
                int[] con = tileArr[(int)trTileArr.x + 1][i];
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
                int[] con = tileArr[(int)tlTileArr.x - 1][i];
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
                int[] con = tileArr[i][(int)blTileArr.y - 1];
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
                int[] con = tileArr[i][(int)tlTileArr.y + 1];
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

    private void createOuterWater(int edgeWidth, int edgeHeight) {
        for(int i = 0; i < width; i++) {
            tiles[i] = new GameObject[height];
            tileArr[i] = new int[height][];
            for(int j = 0; j < edgeHeight; j++) {
                tileArr[i][j] = new int[3];
                tileArr[i][j][0] = 0;
            }
            for(int j = height - edgeHeight; j < height; j++) {
                tileArr[i][j] = new int[3];
                tileArr[i][j][0] = 0;
            }
        }
        for(int i = 0; i < edgeWidth; i++) {
            for(int j = edgeHeight; j < height - edgeHeight; j++) {
                tileArr[i][j] = new int[3];
                tileArr[i][j][0] = 0;
            }
        }
        for(int i = width - edgeWidth; i < width; i++) {
            for(int j = edgeHeight; j < height - edgeHeight; j++) {
                tileArr[i][j] = new int[3];
                tileArr[i][j][0] = 0;
            }
        }
    }

    private void createIslandShape(int edgeWidth, int edgeHeight) {
        int x = edgeWidth + (int)Random.Range(0, 10);
        int startX = x;
        int y = edgeHeight + (int)Random.Range(0, 10);
        int startY = y;

        for(int i = edgeWidth; i <= x; i++) {
            for(int j = edgeHeight; j <= y; j++) {
                tileArr[i][j] = new int[3];
                tileArr[i][j][0] = 0;
            }
        }
        int endY = height - edgeHeight - (int)Random.Range(0, 10);
        for(int j = y; j < endY; j++) {
            tileArr[x][j] = new int[3];
            tileArr[x][j][0] = 1;
            for(int i = edgeWidth; i < x; i++) {
                tileArr[i][j] = new int[3];
                tileArr[i][j][0] = 0;
            }
            x += (int)Random.Range(-2, 3);
            x = Mathf.Clamp(x, edgeWidth, edgeWidth + 10);
        }
        y = endY;

        for(int i = edgeWidth; i <= x; i++) {
            for(int j = height - edgeHeight; j >= endY; j--) {
                tileArr[i][j] = new int[3];
                tileArr[i][j][0] = 0;
            }
        }
        int endX = width - edgeWidth - (int)Random.Range(0, 10);
        for(int i = x; i < endX; i++) {
            tileArr[i][y] = new int[3];
            tileArr[i][y][0] = 1;
            for(int j = height - edgeHeight; j > y; j--) {
                tileArr[i][j] = new int[3];
                tileArr[i][j][0] = 0;
            }
            y += (int)Random.Range(-2, 3);
            y = Mathf.Clamp(y, height - edgeHeight - 10, height - edgeHeight);
        }
        x = endX;

        for(int i = width - edgeWidth; i >= endX; i--) {
            for(int j = height - edgeHeight; j >= y; j--) {
                tileArr[i][j] = new int[3];
                tileArr[i][j][0] = 0;
            }
        }
        endY = edgeHeight + (int)Random.Range(0, 10);
        for(int j = y; j > endY; j--) {
            tileArr[x][j] = new int[3];
            tileArr[x][j][0] = 1;
            for(int i = x; i < width - edgeWidth; i++) {
                tileArr[i][j] = new int[3];
                tileArr[i][j][0] = 0;
            }
            x += (int)Random.Range(-2, 3);
            x = Mathf.Clamp(x, width - edgeWidth - 10, width - edgeWidth);
        }
        y = endY;

        for(int i = width - edgeWidth; i >= x; i--) {
            for(int j = edgeHeight; j <= y; j++) {
                tileArr[i][j] = new int[3];
                tileArr[i][j][0] = 0;
            }
        }
        endX = startX;
        for(int i = x; i > endX; i--) {
            tileArr[i][y] = new int[3];
            tileArr[i][y][0] = 1;
            for(int j = y; j >= edgeHeight; j--) {
                tileArr[i][j] = new int[3];
                tileArr[i][j][0] = 0;
            }
            y += (int)Random.Range(-2, 3);
            y = Mathf.Clamp(y, edgeHeight, edgeHeight + 10);
            int dif = x - startX;
            y = Mathf.Clamp(y, startY - dif, startY + dif);
        }
    }

    private void createSandTiles(int edgeWidth, int edgeHeight) {
        for(int i = edgeWidth; i < width - edgeWidth; i++) {
            for(int j = edgeHeight; j < height - edgeHeight; j++) {
                if(tileArr[i][j] == null) {
                    tileArr[i][j] = new int[3];
                    if(checkForWater(i, j)) {
                        tileArr[i][j][0] = 1;
                    }
                    else {
                        tileArr[i][j][0] = 2;
                    }
                }
            }
        }
    }

    private bool checkForWater(int xPos, int yPos) {
        int checkDistance = 3;
        for(int i = -checkDistance; i <= checkDistance; i++) {
            for(int j = -checkDistance + Mathf.Abs(i); j <= checkDistance - Mathf.Abs(i); j++) {
                if((i != 0 || j != 0) && tileArr[xPos + i][yPos + j] != null && tileArr[xPos + i][yPos + j][0] == 0) {
                    return true;
                }
            }
        }
        
        return false;
    }

    private void setTileImage(int edgeWidth, int edgeHeight) {

        int[] binArr = new int[4];
        for(int i = edgeWidth; i < width - edgeWidth; i++) {
            for(int j = edgeHeight; j < height - edgeHeight; j++) {
                if(tileArr[i][j][0] == 1) {
                    if(tileArr[i + 1][j][0] == 0 || tileArr[i + 1][j][0] == 2) {
                        if(tileArr[i + 1][j][0] == 0) {
                            tileArr[i][j][2] = 0;
                        }
                        else {
                            tileArr[i][j][2] = 1;
                        }
                        binArr[0] = 1;
                    }
                    else {
                        binArr[0] = 0;
                    }
                    if(tileArr[i][j - 1][0] == 0 || tileArr[i][j - 1][0] == 2) {
                        if(tileArr[i][j - 1][0] == 0) {
                            tileArr[i][j][2] = 0;
                        }
                        else {
                            tileArr[i][j][2] = 1;
                        }
                        binArr[3] = 1;
                    }
                    else {
                        binArr[3] = 0;
                    }
                    if(tileArr[i - 1][j][0] == 0 || tileArr[i - 1][j][0] == 2) {
                        if(tileArr[i - 1][j][0] == 0) {
                            tileArr[i][j][2] = 0;
                        }
                        else {
                            tileArr[i][j][2] = 1;
                        }
                        binArr[2] = 1;
                    }
                    else {
                        binArr[2] = 0;
                    }
                    if(tileArr[i][j + 1][0] == 0 || tileArr[i][j + 1][0] == 2) {
                        if(tileArr[i][j][0] == 0) {
                            tileArr[i][j][2] = 0;
                        }
                        else {
                            tileArr[i][j][2] = 1;
                        }
                        binArr[1] = 1;
                    }
                    else {
                        binArr[1] = 0;
                    }
                    tileArr[i][j][1] = (1 * binArr[0]) + (2 * binArr[1]) + (4 * binArr[2]) + (8 * binArr[3]);
                }
                else {
                    tileArr[i][j][1] = 0;
                }
            }
        }
    }
}