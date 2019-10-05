using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inv;
    
    public GameObject item;
    private void Start(){
        // private GameObject player = GameObject.Find
        // player.tag 
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        print(inv.isFull);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            int i;
            for(i = 0; i < inv.slots.Length; i++){
                if(inv.isFull[i] == false){
                    //item can be picked up
                    //item is now equal true
                    inv.isFull[i] = true;
                    Instantiate(item, inv.slots[i].transform, false);
                    Destroy(item);
                    break;
                }
            }
        }
    }
}
