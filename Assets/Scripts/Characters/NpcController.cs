using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NpcState { Idle, Walking, Talking }

public class NpcController : MonoBehaviour, InteractableInterface
{

    [SerializeField] private Dialog dialog;
    private NpcState state;
    [SerializeField] private float idleTime = 3f;
    private float idleTimer = 0f;
    [SerializeField] List<Vector2> moveDirections;
    private int currentDirection;

 
    private Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    //Makes the npc interacts with the player when it is demand.
    public void Interact(Vector3 source)
    {
        if (state == NpcState.Idle)
        {
            state = NpcState.Talking;
            character.LookTowards(source);
            DialogManager.SharedInstance.ShowDialog(dialog,() => 
            { 
                idleTimer = 0f;
                state = NpcState.Idle; 
            
            });
        }
        


    }

    private void Update()
    {
        
        if (state == NpcState.Idle)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer > idleTime)
            {
                idleTimer = 0f;
                StartCoroutine(Walk());                        
                
            }

        }


 
    }

    //Allows the npc to travel along a predetermined path
    IEnumerator Walk()
    {
        state = NpcState.Walking;
        var oldPos = transform.position;
        
        var direction = Vector2.zero;
        if (moveDirections.Count > 0)
        {
            direction = moveDirections[currentDirection];
            
        }
        else
        {
            direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
        }

        yield return character.MoveTowards(direction);
        if (moveDirections.Count > 0 &&  transform.position != oldPos )
        {
            currentDirection = (currentDirection + 1) % moveDirections.Count;
        }
       

        state = NpcState.Idle;
    }
}


