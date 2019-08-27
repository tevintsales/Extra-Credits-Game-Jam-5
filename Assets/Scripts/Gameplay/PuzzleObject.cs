using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    Vector3 startingPosition;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetObject()
    {
        gameObject.transform.position = startingPosition;
    }

}
