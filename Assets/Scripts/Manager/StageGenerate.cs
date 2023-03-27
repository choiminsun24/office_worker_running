using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class StageGenerate : MonoBehaviour
{
    const int MAPSIZE = 29;

    public GameObject moneyPrefab; //Items Prefabs
    public GameObject fileStackPrefab;
    public GameObject mailPrefab;
    public GameObject postItPrefab;
    public GameObject coffeePrefab;

    public float distance = 7.0f;
    public int stageIndex; //Stage selection
    public TextAsset stageFile;
    public int[,] mapData;
    
    private GameObject stageManager;
    private Transform player;
    private Transform playerTarget;

    private void Awake()
    {
        stageManager = GameObject.Find("StageManager");
        player = GameObject.FindWithTag("Player").transform;
        playerTarget = GameObject.Find("PlayerTarget").transform;

        if (stageManager != null)
            stageIndex = GameObject.Find("StageManager").GetComponent<LoadGame>().Index; //Stage Selection


        TextAsset stageData = Resources.Load<TextAsset>("Stage" + stageIndex); //Load Stage.text
        string[] lines = stageData.text.Split('\n');

        mapData = new int[MAPSIZE, MAPSIZE]; 

        for (int i = 0; i < MAPSIZE; i++) //Split stage data
        {
            for (int j = 0; j < MAPSIZE; j++)
            {
                int val = int.Parse(lines[i][j].ToString());
                mapData[i, j] = val;
            }
        }

      
        for (int i = 0; i < MAPSIZE; i++) //Create Stage
        {
            for (int j = 0; j < MAPSIZE; j++)
            {
                if (mapData[i, j] == 1) //Create money
                {
                   GameObject money = Instantiate(moneyPrefab, new Vector3(i * distance, 1.6f, j * distance), Quaternion.identity);
                    money.name = "(" + i + "," + j + ")";
                }
                else if (mapData[i, j] == 2) //Create fileStack
                {
                    Instantiate(fileStackPrefab, new Vector3(i * distance, 1.5f, j * distance), Quaternion.Euler(-90.0f, 0, 0));
                }
                else if (mapData[i, j] == 3) //Create mail
                {
                    Instantiate(mailPrefab, new Vector3(i * distance, 1.5f, j * distance), Quaternion.Euler(0, 90.0f, 0));
                }
                else if (mapData[i, j] == 4) //Create postIt
                {
                    Instantiate(postItPrefab, new Vector3(i * distance, 1.2f, j * distance), Quaternion.Euler(0, 90.0f, 0));
                }
                else if (mapData[i, j] == 5) //Create Coffee
                {
                    Instantiate(coffeePrefab, new Vector3(i * distance, 0.7f, j * distance), Quaternion.Euler(-90.0f, 0, 0));
                }
                else if(mapData[i, j] == 6)
                {
                    Vector3 playerPos = new Vector3(i * distance, 0.0f, j * distance);
                    player.position = playerPos;
                }
                else if(mapData[i, j] == 7)
                {
                    playerTarget.position = new Vector3(i * distance, 0.0f, j * distance);
                }
            }
        }

        player.LookAt(playerTarget);
    }


    void Start()
    {
       
        
    }

    void update()
    {

    }
}