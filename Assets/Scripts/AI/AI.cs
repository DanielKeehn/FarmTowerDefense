using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIStateNamespace;

public abstract class AI : StateMachine
{
    #region Variable Declarations
    // These are the varaibles all AI must have
    // The name of the AI
    public new string name;
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

    // Reference to the animator
    public Animator animator;

    public UnityEngine.AI.NavMeshAgent agent;
    #endregion

    private void Start()
    {
        ChangeState(new SearchState(this));
        currentTarget = null;
    }

    // Check what type AI is and find list of targets AI can search for
    public List<GameObject> getTargetList() {
        
        if (this.GetType().IsSubclassOf(typeof(Animal))) {
            try {
                return GameObject.FindWithTag("GameManager").GetComponent<CurrentAttackableObjects>().vegetableList;
            } catch {
                throw new System.ArgumentException("Couldn't find list of vegetables to target, make sure current attackable object script is attached to game manager and game manager has a gamemanager tag");
            }
        } else if (this.GetType().IsSubclassOf(typeof(Enemy))) {
            try {
                return GameObject.FindWithTag("GameManager").GetComponent<CurrentAttackableObjects>().animalList;
            } catch {
                throw new System.ArgumentException("Couldn't find list of animals to target, make sure current attackable object script is attached to game manager and game manager has a gamemanager tag");
            }
        } else {
            throw new System.ArgumentException("The AI is not a vegetable or animal so a target list cannot be created");
        }
    }
}