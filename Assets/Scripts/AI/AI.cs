using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIStateNamespace;

public class AI : StateMachine
{

    public AIState<AI> temporaryObject;

    #region Variable Declarations
    // These are the varaibles all AI must have
    // The name of the AI
    public string name;
    // How much health a AI currently has
    public int health;
    // How strong an AIs attacks are
    public int attackPower;
    // How fast an enemy attacks
    public float attackSpeed;
    // Reference to the state machine
    #endregion

    #region Constructors
    public AI(string n, int h, int ap, float asp) {
        this.name = n;
        this.health = h;
        this.attackPower = ap;
        this.attackSpeed = asp;
    }

    public AI() {
        this.name = "Default Constructor";
        this.health = 0;
        this.attackPower = 0;
        this.attackSpeed = 0f;
    }
    #endregion

    private void Start()
    {
        ChangeState(new SpawnState(this));
    }
}