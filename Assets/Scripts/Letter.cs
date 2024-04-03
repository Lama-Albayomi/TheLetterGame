using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour{
    public int size;
    public GameObject[] children;
    void Awake(){
        DontFall();
    }
    void Update(){
        
    }
    public void Fall(){
        if (children.Length!=0){
            foreach(GameObject child in children){
                child.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }else{
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    public void DontFall(){
        if (children.Length!=0){
            foreach(GameObject child in children){
                child.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }else{
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}
