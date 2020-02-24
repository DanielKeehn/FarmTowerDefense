using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Camera camera;
    public Weapon weaponScript;

    // Start is called before the first frame update
    void Start()
    {
        weaponScript = gameObject.GetComponent<Weapon>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack")) {
            DoAttack();
        }
    }

    // This method runs when a player attacks
    private void DoAttack(){
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, weaponScript.attackRange)) {
            if (hit.collider.tag == "Enemy") {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                enemy.TakeDamage(weaponScript.attackDamage);
            }
        }
    }
}
