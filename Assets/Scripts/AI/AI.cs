using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIStateNamespace;

public abstract class AI : StateMachine
{
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
    // How far an enemy can attack from
    public float attackRange;
      // Object an AI is targeting
    public GameObject currentTarget;
    // Objects an AI can target
    public List<GameObject> targets;
    public UnityEngine.AI.NavMeshAgent agent;
    #endregion

    public GameObject tempObject;
    private void Start()
    {
        ChangeState(new SearchState(this));
        targets.Add(tempObject);
        currentTarget = null;
    }
}