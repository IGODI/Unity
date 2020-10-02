using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public GameObject player;

    public bool checkPoint;
    public Transform checkpointPos;
   

   
    private void Awake()
    {
        instance = this;
    }
   
    public void SetcheckPoint(CheckPoint NewCheckpoint)
    {
        if(NewCheckpoint != null)
        {
            checkPoint = true;
            checkpointPos = NewCheckpoint.transform;
        }
    }
    public void Restart()
    {
        player.transform.position = checkpointPos.position;

    }
    

}
