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
        setTileImageNew(edgeWidth, edgeHeight);
        //createTreesRocks(edgeWidth, edgeHeight);

        GetComponent<EnemySpawner>().tileUpdate(tileArr);

        Sprite[] sandToWater = new Sprite[256];
        sandToWater[2] = Resources.Load<Sprite>("Sprites/1");
        sandToWater[8] = Resources.Load<Sprite>("Sprites/2");
        sandToWater[10] = Resources.Load<Sprite>("Sprites/3");
        sandToWater[11] = Resources.Load<Sprite>("Sprites/4");
        sandToWater[16] = Resources.Load<Sprite>("Sprites/5");
        sandToWater[18] = Resources.Load<Sprite>("Sprites/6");
        sandToWater[22] = Resources.Load<Sprite>("Sprites/7");
        sandToWater[24] = Resources.Load<Sprite>("Sprites/8");
        sandToWater[26] = Resources.Load<Sprite>("Sprites/9");
        sandToWater[27] = Resources.Load<Sprite>("Sprites/10");
        sandToWater[30] = Resources.Load<Sprite>("Sprites/11");
        sandToWater[31] = Resources.Load<Sprite>("Sprites/12");
        sandToWater[64] = Resources.Load<Sprite>("Sprites/13");
        sandToWater[66] = Resources.Load<Sprite>("Sprites/14");
        sandToWater[72] = Resources.Load<Sprite>("Sprites/15");
        sandToWater[74] = Resources.Load<Sprite>("Sprites/16");
        sandToWater[75] = Resources.Load<Sprite>("Sprites/17");
        sandToWater[80] = Resources.Load<Sprite>("Sprites/18");
        sandToWater[82] = Resources.Load<Sprite>("Sprites/19");
        sandToWater[86] = Resources.Load<Sprite>("Sprites/20");
        sandToWater[88] = Resources.Load<Sprite>("Sprites/21");
        sandToWater[90] = Resources.Load<Sprite>("Sprites/22");
        sandToWater[91] = Resources.Load<Sprite>("Sprites/23");
        sandToWater[94] = Resources.Load<Sprite>("Sprites/24");
        sandToWater[95] = Resources.Load<Sprite>("Sprites/25");
        sandToWater[104] = Resources.Load<Sprite>("Sprites/26");
        sandToWater[106] = Resources.Load<Sprite>("Sprites/27");
        sandToWater[107] = Resources.Load<Sprite>("Sprites/28");
        sandToWater[120] = Resources.Load<Sprite>("Sprites/29");
        sandToWater[122] = Resources.Load<Sprite>("Sprites/30");
        sandToWater[123] = Resources.Load<Sprite>("Sprites/31");
        sandToWater[126] = Resources.Load<Sprite>("Sprites/32");
        sandToWater[127] = Resources.Load<Sprite>("Sprites/33");
        sandToWater[208] = Resources.Load<Sprite>("Sprites/34");
        sandToWater[210] = Resources.Load<Sprite>("Sprites/35");
        sandToWater[214] = Resources.Load<Sprite>("Sprites/36");
        sandToWater[216] = Resources.Load<Sprite>("Sprites/37");
        sandToWater[218] = Resources.Load<Sprite>("Sprites/38");
        sandToWater[219] = Resources.Load<Sprite>("Sprites/39");
        sandToWater[222] = Resources.Load<Sprite>("Sprites/40");
        sandToWater[223] = Resources.Load<Sprite>("Sprites/41");
        sandToWater[248] = Resources.Load<Sprite>("Sprites/42");
        sandToWater[250] = Resources.Load<Sprite>("Sprites/43");
        sandToWater[251] = Resources.Load<Sprite>("Sprites/44");
        sandToWater[254] = Resources.Load<Sprite>("Sprites/45");
        sandToWater[255] = Resources.Load<Sprite>("Sprites/46");
        sandToWater[0] = Resources.Load<Sprite>("Sprites/47");

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
                obj.GetComponent<TileHandler>().setUpSprites(sandToWater);
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
                obj.GetComponent<TileHandler>().configure(tileArr[(width / 2) + i][(height / 2) + j]);
            }
        }
    }

    private void Update() {
        float x = transform.position.x;
        float y = transform.position.y;
        if(Mathf.Abs(x - tlTilePos.x) > leftTileDis && trTileArr.x < width - 1) {
            for(int i = (int)tlTileArr.y; i >= (int)blTileArr.y; i--) {
                removeRockTree((int)tlTileArr.x, i, (int)tlTilePos.x, i);
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
                removeRockTree((int)trTileArr.x, i, (int)trTilePos.x, i);
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
                removeRockTree(i, (int)tlTileArr.y, i, (int)tlTilePos.y);
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
                removeRockTree(i, (int)blTileArr.y, i, (int)blTilePos.y);
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

    private void removeRockTree(int xArr, int yArr, int xPos, int yPos) {
        if(tileArr[xArr][yArr][3] == 1) {
            Destroy(GameObject.Find("rock" + xPos + yPos));
        }
        else if(tileArr[xArr][yArr][3] == 2) {
            Destroy(GameObject.Find("tree" + xPos + yPos));
        }
    }

    private void createOuterWater(int edgeWidth, int edgeHeight) {
        for(int i = 0; i < width; i++) {
            tiles[i] = new GameObject[height];
            tileArr[i] = new int[height][];
            for(int j = 0; j < edgeHeight; j++) {
                tileArr[i][j] = new int[4];
                tileArr[i][j][0] = 0;
                tileArr[i][j][1] = 0;
                tileArr[i][j][2] = 0;
                tileArr[i][j][3] = 0;
            }
            for(int j = height - edgeHeight; j < height; j++) {
                tileArr[i][j] = new int[4];
                tileArr[i][j][0] = 0;
                tileArr[i][j][1] = 0;
                tileArr[i][j][2] = 0;
                tileArr[i][j][3] = 0;
            }
        }
        for(int i = 0; i < edgeWidth; i++) {
            for(int j = edgeHeight; j < height - edgeHeight; j++) {
                tileArr[i][j] = new int[4];
                tileArr[i][j][0] = 0;
                tileArr[i][j][1] = 0;
                tileArr[i][j][2] = 0;
                tileArr[i][j][3] = 0;
            }
        }
        for(int i = width - edgeWidth; i < width; i++) {
            for(int j = edgeHeight; j < height - edgeHeight; j++) {
                tileArr[i][j] = new int[4];
                tileArr[i][j][0] = 0;
                tileArr[i][j][1] = 0;
                tileArr[i][j][2] = 0;
                tileArr[i][j][3] = 0;
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
                tileArr[i][j] = new int[4];
                tileArr[i][j][0] = 0;
                tileArr[i][j][1] = 0;
                tileArr[i][j][2] = 0;
                tileArr[i][j][3] = 0;
            }
        }
        int endY = height - edgeHeight - (int)Random.Range(0, 10);
        for(int j = y; j < endY; j++) {
            tileArr[x][j] = new int[4];
            tileArr[x][j][0] = 1;
            tileArr[x][j][1] = 0;
            tileArr[x][j][2] = 0;
            tileArr[x][j][3] = 0;
            for(int i = edgeWidth; i < x; i++) {
                tileArr[i][j] = new int[4];
                tileArr[i][j][0] = 0;
                tileArr[i][j][1] = 0;
                tileArr[i][j][2] = 0;
                tileArr[i][j][3] = 0;
            }
            x += (int)Random.Range(-2, 3);
            x = Mathf.Clamp(x, edgeWidth, edgeWidth + 10);
        }
        y = endY;

        for(int i = edgeWidth; i <= x; i++) {
            for(int j = height - edgeHeight; j >= endY; j--) {
                tileArr[i][j] = new int[4];
                tileArr[i][j][0] = 0;
                tileArr[i][j][1] = 0;
                tileArr[i][j][2] = 0;
                tileArr[i][j][3] = 0;
            }
        }
        int endX = width - edgeWidth - (int)Random.Range(0, 10);
        for(int i = x; i < endX; i++) {
            tileArr[i][y] = new int[4];
            tileArr[i][y][0] = 1;
            tileArr[i][y][1] = 0;
            tileArr[i][y][2] = 0;
            tileArr[i][y][3] = 0;
            for(int j = height - edgeHeight; j > y; j--) {
                tileArr[i][j] = new int[4];
                tileArr[i][j][0] = 0;
                tileArr[i][j][1] = 0;
                tileArr[i][j][2] = 0;
                tileArr[i][j][3] = 0;
            }
            y += (int)Random.Range(-2, 3);
            y = Mathf.Clamp(y, height - edgeHeight - 10, height - edgeHeight);
        }
        x = endX;

        for(int i = width - edgeWidth; i >= endX; i--) {
            for(int j = height - edgeHeight; j >= y; j--) {
                tileArr[i][j] = new int[4];
                tileArr[i][j][0] = 0;
                tileArr[i][j][1] = 0;
                tileArr[i][j][2] = 0;
                tileArr[i][j][3] = 0;
            }
        }
        endY = edgeHeight + (int)Random.Range(0, 10);
        for(int j = y; j > endY; j--) {
            tileArr[x][j] = new int[4];
            tileArr[x][j][0] = 1;
            tileArr[x][j][1] = 0;
            tileArr[x][j][2] = 0;
            tileArr[x][j][3] = 0;
            for(int i = x; i < width - edgeWidth; i++) {
                tileArr[i][j] = new int[4];
                tileArr[i][j][0] = 0;
                tileArr[i][j][1] = 0;
                tileArr[i][j][2] = 0;
                tileArr[i][j][3] = 0;
            }
            x += (int)Random.Range(-2, 3);
            x = Mathf.Clamp(x, width - edgeWidth - 10, width - edgeWidth);
        }
        y = endY;

        for(int i = width - edgeWidth; i >= x; i--) {
            for(int j = edgeHeight; j <= y; j++) {
                tileArr[i][j] = new int[4];
                tileArr[i][j][0] = 0;
                tileArr[i][j][1] = 0;
                tileArr[i][j][2] = 0;
                tileArr[i][j][3] = 0;
            }
        }
        endX = startX;
        for(int i = x; i > endX; i--) {
            tileArr[i][y] = new int[4];
            tileArr[i][y][0] = 1;
            tileArr[i][y][1] = 0;
            tileArr[i][y][2] = 0;
            tileArr[i][y][3] = 0;
            for(int j = y; j >= edgeHeight; j--) {
                tileArr[i][j] = new int[4];
                tileArr[i][j][0] = 0;
                tileArr[i][j][1] = 0;
                tileArr[i][j][2] = 0;
                tileArr[i][j][3] = 0;
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
                    tileArr[i][j] = new int[4];
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
        int checkDistance = 4;
        for(int i = -checkDistance; i <= checkDistance; i++) {
            for(int j = -checkDistance + Mathf.Abs(i); j <= checkDistance - Mathf.Abs(i); j++) {
                if((i != 0 || j != 0) && tileArr[xPos + i][yPos + j] != null && tileArr[xPos + i][yPos + j][0] == 0) {
                    return true;
                }
            }
        }
        
        return false;
    }

    private void setTileImageNew(int edgeWidth, int edgeHeight) {
        int[] binArr = new int[8];
        for(int i = edgeWidth - 1; i < width - edgeWidth + 1; i++) {
            for(int j = edgeHeight - 1; j < height - edgeHeight + 1; j++) {
                if(tileArr[i][j][0] == 1) {
                    int binCounter = 0;
                    int curTile;
                    tileArr[i][j][2] = 0;
                    //Loops through the 8 surrounding tiles and if they are sand tiles, will set a position of binArr to 1
                    for(int yOffset = 1; yOffset > -2; yOffset--) {
                        for(int xOffset = -1; xOffset < 2; xOffset++) {
                            if(xOffset != 0 || yOffset != 0) {
                                curTile = tileArr[i + xOffset][j + yOffset][0];
                                if(curTile == 1) {
                                    if(binCounter == 5) {
                                        if(tileArr[i][j - 1][0] == 1 && tileArr[i - 1][j][0] == 1) {
                                            binArr[binCounter] = 1;
                                        }
                                        else {
                                            binArr[binCounter] = 0;
                                        }
                                    }
                                    else if(binCounter == 7) {
                                        if(tileArr[i][j - 1][0] == 1 && tileArr[i + 1][j][0] == 1) {
                                            binArr[binCounter] = 1;
                                        }
                                        else {
                                            binArr[binCounter] = 0;
                                        }
                                    }
                                    else if(binCounter == 0) {
                                        if(tileArr[i][j + 1][0] == 1 && tileArr[i - 1][j][0] == 1) {
                                            binArr[binCounter] = 1;
                                        }
                                        else {
                                            binArr[binCounter] = 0;
                                        }
                                    }
                                    else if(binCounter == 2) {
                                        if(tileArr[i][j + 1][0] == 1 && tileArr[i + 1][j][0] == 1) {
                                            binArr[binCounter] = 1;
                                        }
                                        else {
                                            binArr[binCounter] = 0;
                                        }
                                    }
                                    else {
                                        binArr[binCounter] = 1;
                                    }
                                    binCounter++;
                                }
                                else {
                                    binArr[binCounter] = 0;
                                    binCounter++;
                                    if(curTile == 2) {
                                        tileArr[i][j][2] = 1;
                                    }
                                }
                            }
                        }
                    }
                    tileArr[i][j][1] = (1 * binArr[0]) + (2 * binArr[1]) + (4 * binArr[2]) + (8 * binArr[3]) + (16 * binArr[4]) + (32 * binArr[5]) + (64 * binArr[6]) + (128 * binArr[7]);
                }
                else {
                    tileArr[i][j][1] = 0;
                }

                //Sets a sand or grass tile to hold trees/rocks
                if(tileArr[i][j][0] != 0) {
                    tileArr[i][j][3] = 0;
                    int rockChance = Random.Range(0, 100);
                    if(rockChance < 10) {
                        tileArr[i][j][3] = 1;
                    }
                    int treeChance = Random.Range(0, 100);
                    if(treeChance < 5 && tileArr[i][j][3] == 0) {
                        tileArr[i][j][3] = 2;
                    }
                }
            }
        }
    }

    private void setTileImage(int edgeWidth, int edgeHeight) {

        int[] binArr = new int[4];
        for(int i = edgeWidth - 1; i < width - edgeWidth + 1; i++) {
            for(int j = edgeHeight - 1; j < height - edgeHeight + 1; j++) {
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
                        if(tileArr[i][j + 1][0] == 0) {
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