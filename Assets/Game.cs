using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class Game : MonoBehaviour
{
    public Queue<StoneMovement> Movements = new Queue<StoneMovement>();

    public GameObject PlayerAStone1;
    public GameObject PlayerAStone2;
    public GameObject PlayerAStartField;
    public GameObject PlayerAHouse1;
    public GameObject PlayerAHouse2;

    public GameObject PlayerBStone1;
    public GameObject PlayerBStone2;
    public GameObject PlayerBStartField;
    public GameObject PlayerBHouse1;
    public GameObject PlayerBHouse2;

    public GameObject[] Fields;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveStones();
    }

    private void MoveStones()
    {
        if (Movements.Any())
        {
            var currentPlayed = Movements.Peek();
            currentPlayed.Movement();
            if (currentPlayed.IsFinished())
            {
                Movements.Dequeue();
            }
        }
    }

    public struct StoneMovement
    {
        public Action Movement { get; set; }

        public Func<bool> IsFinished { get; set; }
    }

    public GameObject GetTargetPosition(GameObject currentPosition)
    {
        if (currentPosition == PlayerAHouse1 || currentPosition == PlayerAHouse2)
        {
            return PlayerAStartField;
        }

        if (currentPosition == PlayerBHouse1 || currentPosition == PlayerBHouse2)
        {
            return PlayerBStartField;
        }

        for (int i = 0; i < Fields.Length; i++)
        {
            if (currentPosition == Fields[i])
            {
                if (i == Fields.Length - 1)
                {
                    return Fields[0];
                }

                return Fields[i + 1];
            }
        }

        throw new InvalidOperationException("You can not come here.");
    }
}
