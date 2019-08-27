using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //eventID based on index 
    [SerializeField] bool[] events;
    public static EventManager instance = null;
    /****
     * List Of Events
     * 0 = shroom, set color on screen to blue on forrest scene and activate hidden items.
     * 1 = remove first boulder and third boulder in maze
     * 2 = remove second boulder and fourth boulder
     * 3 = replace third boulder
     * 4 = ShapePuzzle was solved correctly
     * 5 = Get rid of rocks blocking maze
     * 6 = Forest Chicken Found
     * 7 = Player found bucket of water
     * 8 = Pour Cup of Water into trophy
     * 9 = Lava Puzzle Solved
     * 10 = Sea/Beach Level Puzzle Solved
     * 11 = Lava Chicken Found
     * 12 = Final Chicken Found
     * 13 = All Three Chickens were found
     * 14 = Secret Event for Forest, blocking chicken
     * 15 = Secret Event for Lava Scene
     * 16 = Shovel Found for Beach scene / found in lava scene
     * 17 = Shovel Found for Beach scene / found in lava scene
     * 18 = Found Axe for Forest Maze Entrance/ Found in in Beach Scene
     * 19 = rock puzzle west side
     * 20 = rock puzzle east side
     * 21 = rock puzzle south side
     * 22 = rock puzzle north side
     * 23 = Beach Puzzle Solved
     * 24 = Beach Gate 1
     * 25 = Beach Gate 2
     * 26 = pillar 1
     * 27 = pillar 2
     * 28 = pillar 3
     * 29 = pillar 4
     *
     * 30 = Hallway spanwer
     */
    

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(this);
    }
     public void ActivateEvent(int eventID)
    {
        if(eventID >= 0 || eventID < events.Length)
        {
            events[eventID] = true;
        }
    }

    public void DisableEvent(int eventID)
    {
        if (eventID >= 0 || eventID < events.Length)
        {
            events[eventID] = false;
        }
    }

    public bool IsEventActivated(int eventID)
    {
        return events[eventID];
    }
}
