using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All objects that are attackable must have this script attached

public class Health : MonoBehaviour
{
    public int health;
    protected List<GameObject> vegetableList;
    protected List<GameObject> animalList;
    protected RoundManager roundManager;

    protected virtual void Start()
    {
        try {
           CurrentAttackableObjects currentAttackableObjects = GameObject.FindWithTag("GameManager").GetComponent<CurrentAttackableObjects>();
           vegetableList = currentAttackableObjects.vegetableList;
           animalList = currentAttackableObjects.animalList;
        }
        catch {
            throw new System.ArgumentException("Couldn't find Vegetable List or Animal List. Make sure there exists a Game Object with the game object tag and a current attackable objects script is a component of the game manager");
        }
        try {
            roundManager = GameObject.FindWithTag("RoundManager").GetComponent<RoundManager>();
        } catch {
            throw new System.ArgumentException("Couldn't find round manager script. Make sure there is a round manager object with the proper tag and this object has a round manager script");
        }   
    }

    // This method runs when something attacks an object with this attribute 
    public virtual  void TakeDamage(int amount) {
        health -= amount;
        IsDead();
    }

    // Check if you are dead by running this method. Object is destroyed if dead
    public virtual bool IsDead() {
        if (health <= 0) {
            removeFromList();
            Destroy(gameObject);
            return true;
        } else {
            return false;
        }
    }

    // Remove dead enemy from vegetable list and animal list
    protected void removeFromList() {
        if (gameObject.tag == "Animal" ^ gameObject.tag == "Player" ^ gameObject.tag == "Farmhouse") {
            animalList.Remove(gameObject);
        } else if (gameObject.tag == "Enemy") {
            vegetableList.Remove(gameObject);
            roundManager.decreaseNumberOfEnemies();
        } else {
            throw new System.ArgumentException("Couldn't Remove Object From Vegetable or Animal List. Make sure this object is tagged properly");
        }
    }

}
