using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    
    public static float Room;
    public GameObject Camera;
    //public string RoomName;
    public float thisRoomBarrier;
    bool GoingRight;
    public Collider2D player;

    public void Awake()
    {
        
        Room = 1f;
        
        //player = GameObject.Find("Player").GetComponent<Collider2D>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (player == other)
        {
            
            
            if (Room > thisRoomBarrier)
            {
                GoingRight = false;
            }
            else
            {
                GoingRight = true;
            }

            switch (GoingRight)
            {
                case true:
                    ///Debug.Log("You are going right.");
                    Room += 1;
                    Camera.GetComponent<ChangeCamera>().CameraMove(Room);
                    break;
                case false:
                    //Debug.Log("You are going left.");
                    Room -= 1;
                    Camera.GetComponent<ChangeCamera>().CameraMove(Room);
                    break;


            }
            
        }
        
    }
}
