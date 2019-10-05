using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;

    private void start(){
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            for(int i = 0; i < inventory.slots.Length; i++){
                if(inventory.isFull[i] == false){
                    //item can be picked up
                    //item is now equal true
                    inventory.isFull[i] = true;
                    break;
                }else{
                    //inventory is full
                    break;
                }
            }
        }
    }
}
