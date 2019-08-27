using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    //object arrays
    PuzzleObject[] puzzleObjects;
    // Start is called before the first frame update
    void Start()
    {
        puzzleObjects = FindObjectsOfType<PuzzleObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            ResetPuzzle();
        }
    }

    public void ResetPuzzle()
    {
        foreach(PuzzleObject puzzleObject in puzzleObjects)
        {
            puzzleObject.ResetObject();
            puzzleObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
    }
}
