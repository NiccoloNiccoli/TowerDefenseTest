using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GridController : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tile hoverTile = null;
    [SerializeField] private Tile hoverTileNotAv = null;

    [SerializeField] private GameObject[] spawners = null;
    List<Vector2> occupiedPositions = new List<Vector2>();
    private GameObject selectedHero = null;
    int highlighterZHeight = 10;


    private Vector2 correctiveOffset;
    [SerializeField] private Transform left_top, right_bottom;
    private Vector3 LT, RB;
    private Vector3Int previousMousePos;

    public Tilemap InteractiveMap { get => interactiveMap; set => interactiveMap = value; }

    void Start()
    {
        correctiveOffset = new Vector2(1, 0.5f);
        grid = gameObject.GetComponent<Grid>();
        previousMousePos = new Vector3Int(0,0,highlighterZHeight);
        //structureHeight = highlighterZHeight + 1;
        LT = left_top.position;
        RB = right_bottom.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse over -> highlight tile
        Vector3Int mousePos = GetMousePosition();
        if (isInArea(mousePos, LT, RB)) {
            if (!mousePos.Equals(previousMousePos)) {
                mousePos = new Vector3Int(mousePos.x, mousePos.y, highlighterZHeight);
                interactiveMap.SetTile(previousMousePos, null); // Remove old hoverTile
                if(isFreeInt(new Vector2Int(mousePos.x, mousePos.y))){
                    interactiveMap.SetTile(mousePos, hoverTile);
                }
                else {
                    interactiveMap.SetTile(mousePos, hoverTileNotAv);
                }
                
                previousMousePos = mousePos;
            }

            // Left mouse click -> add path tile
            if (Input.GetMouseButton(0)) {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 pos2 = new Vector2(Mathf.Floor(pos.x), Mathf.Floor(pos.y));
                pos2 += correctiveOffset;
                int cost = selectedHero.GetComponent<Hero>().GetCost();
                GameObject game = GameObject.FindGameObjectWithTag("GameController");
                if (!occupiedPositions.Contains(pos2) && selectedHero!=null && cost <= game.GetComponent<GameData>().Money) {
                    GameObject currentObj = Instantiate(selectedHero, pos2, Quaternion.identity);
                    occupiedPositions.Add(pos2);
                    currentObj.GetComponent<Hero>().SetPos(pos2);

                    //pays the hero
                   
                   
                    game.GetComponent<GameData>().Earn(-cost);

                    //discovers in which row it has instantiated the object and set its sorting layer properly
                    int i = 0;
                    while ( i < spawners.Length && Mathf.FloorToInt(pos2.y) != Mathf.FloorToInt(spawners[i].transform.position.y) ) {
                        i++;
                    }
                    currentObj.GetComponent<SpriteRenderer>().sortingOrder = 1 + i;
                    selectedHero = null;

                }
            }

            // Right mouse click -> remove path tile
            /*if (Input.GetMouseButton(1)) {
                //pathMap.SetTile(mousePos, null);
                mousePos = new Vector3Int(mousePos.x, mousePos.y, structureHeight);
                interactiveMap.SetTile(mousePos, null);
                Debug.Log("dx");
            }*/
        }

    }

    Vector3Int GetMousePosition() {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }

    bool isInArea(Vector3Int mousePos, Vector3 LT, Vector3 RB) {
        if (mousePos.x >= LT.x && mousePos.x < RB.x && mousePos.y >= RB.y && mousePos.y < LT.y)
            return true;
        else
            return false;
    }

    public void selectHero(int h) {
        selectedHero = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameData>().GetHero(h);
    }

    public void FreePos(Vector2 pos) {
        if (occupiedPositions.Contains(pos)) {
            occupiedPositions.Remove(pos);
        }
    }

    private bool isFreeInt(Vector2Int mPos) {
        for(int i = 0; i < occupiedPositions.Count; i++) {
            if (Vector2Int.CeilToInt(occupiedPositions[i]) - new Vector2Int(1,1) == mPos) { //funziona, non so come :)
                print("pos2: " + occupiedPositions[i].x + " " + occupiedPositions[i].y);
                return false;
            }
                
        }
        return true;
    }

    public void reset()
    {
        occupiedPositions.Clear();
        selectedHero = null;
    }
}


