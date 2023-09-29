using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool initialized = false;

    List<DoublyNode> roomDatabase = new List<DoublyNode>();

    DoublyNode tempDoubleNode;


    public int test;








    private void Awake()
    {

        //initialize doubly list room values
        //bool roomDefeated
        //string enemyName
        //int[3] position or Vector3 position
        //

        test = 1;

        Debug.Log(test);

        tempDoubleNode = new DoublyNode(test);


        DontDestroyOnLoad(this.gameObject);
    }

    public void UpdateRoomDatabase()
    {
        test--;
        if (test == 0)
        {

        }
        Debug.Log(test);
    }




}
