using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIStateNamespace;

public class AI : MonoBehaviour
{

    // These are the varaibles all AI must have
    public string name;
    public int health;
    public bool switchState = false;
    public int attackPower;
    public float attackSpeed;

    public AIStateMachine<AI> stateMachine { get; set; }

    private void Start()
    {
        stateMachine = new AIStateMachine<AI>(this);
        //stateMachine.ChangeState(FirstState.Instance);
    }

    private void Update()
    {
        // if(Time.time > gameTimer + 1)
        // {
        //     gameTimer = Time.time;
        //     seconds++;
        //     Debug.Log(seconds);
        // }

        // if(seconds == 5)
        // {
        //     seconds = 0;
        //     switchState = !switchState;
        // }

        // stateMachine.Update();
    }
}