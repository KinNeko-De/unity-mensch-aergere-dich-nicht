using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Result { get; private set; }

    public void Roll()
    {
        Result = Random.Range(1, 7);
        Debug.Log($"Rolled: {Result}");
    }
}
