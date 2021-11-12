using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LoadLevel : MonoBehaviour
{
    /*
    When the player destroys the battleship, a new scene must be generated with a random distance between the
    player and computer battleships.
    */

    public float distance;
    public float distanceInMeters;
    public GameObject playerBattleship;
    public GameObject computerBattleship;

    public GameObject player;
    public GameObject computer;

    public GameObject destroyer;
    public GameObject battleship;
    public GameObject aircraftCarrier;
    public GameObject fighterJet;

    public static int score = -1;
    private float offset;

    // Start is called before the first frame update
    void Start(){
        IncrementScore();
        CalculateDistance();
        SpawnBattleships();
        SpawnEnemyShip();
    }

    
    // Update is called once per frame
    void Update(){
    }

    public void IncrementScore(){
        score = score + 1;
    }

    public void CalculateDistance(){
        distance = UnityEngine.Random.Range(8.0000f, 15.0000f);
        distanceInMeters = Mathf.Ceil(distance * 100);
        offset = UnityEngine.Random.Range(-2f, 2f);
       
    }

    void SpawnBattleships(){
        
        float fromCenter = distance / 2;
        Vector2 playerPos = new Vector2(-fromCenter + offset, -3.92f);
        player = Instantiate(playerBattleship, playerPos, playerBattleship.transform.rotation); // Player
    }

    public void SpawnEnemyShip()
    {
       
        float fromCenter = distance / 2;
        Vector2 computerPos = new Vector2(fromCenter + offset, -3.92f);
        computer = Instantiate(computerBattleship, computerPos, computerBattleship.transform.rotation); // Computer
        EnemyScript ascript = computer.GetComponentInChildren<EnemyScript>();
        ascript.enabled = true;
    }

    void SpawnBackgroundShips(){

    }

    void SpawnFighterJets(){
        
    }
}
