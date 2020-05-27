using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All objects that are attackable must have this script attached

public class Health : MonoBehaviour
{
    public int health;
    private List<GameObject> vegetableList;
    private List<GameObject> animalList;

    void Start()
    {
        try {
           CurrentAttackableObjects currentAttackableObjects = GameObject.FindWithTag("GameManager").GetComponent<CurrentAttackableObjects>();
           vegetableList = currentAttackableObjects.vegetableList;
           animalList = currentAttackableObjects.animalList;
        }
        catch {
            throw new System.ArgumentException("Couldn't find Vegetable List or Animal List. Make sure there exists a Game Object with the game object tag and a current attackable objects script is a component of the game manager");
        }
    }

    // This method runs when something attacks an object with this attribute 
    public void TakeDamage(int amount) {
        health -= amount;
    }

    // Check if you are dead by running this method. Object is destroyed if dead
    public bool IsDead() {
        if (health <= 0) {
            removeFromList();
            Destroy(gameObject);
            return true;
        } else {
            return false;
        }
    }

    // Remove dead enemy from vegetable list and animal list
    private void removeFromList() {
        if (gameObject.tag == "Animal" ^ gameObject.tag == "Player" ^ gameObject.tag == "Farmhouse") {
            animalList.Remove(gameObject);
        } else if (gameObject.tag == "Enemy") {
            vegetableList.Remove(gameObject);
        } else {
            throw new System.ArgumentException("Couldn't Remove Object From Vegetable or Animal List. Make sure this object is tagged properly");
        }
    }

}
