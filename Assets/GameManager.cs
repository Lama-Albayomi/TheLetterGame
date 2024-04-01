using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject alf;
    [SerializeField] private GameObject baa;
    [SerializeField] private GameObject taa;
    [SerializeField] private Transform startPos;
    private int numberofLetters = 0;
    private bool isEnded= false;
    private List<GameObject> letters = new List<GameObject>();
    void Start(){
        
    }
    void Update(){
        if(isEnded) return;
        
        if(Input.GetKeyDown(KeyCode.A)){
            Debug.Log("A");
            LetterEntered(alf);
        }
        if(Input.GetKeyDown(KeyCode.B)){
            Debug.Log("B");
            LetterEntered(baa);
        }
        if(Input.GetKeyDown(KeyCode.T)){
            Debug.Log("T");
            LetterEntered(taa);
        }
        if (Input.GetKeyDown(KeyCode.Return)){
            GameEnded();
        }
        
    }
    public void LetterEntered(GameObject letter){
        numberofLetters++;
        Vector3 letterPostion = startPos.position + new Vector3(numberofLetters, 0, 0);
        GameObject inst =  Instantiate(letter, letterPostion, Quaternion.identity);
        letters.Add(inst);
        
    }
    public void GameEnded(){
        foreach(GameObject letter in letters){
            letter.GetComponent<Rigidbody2D>().gravityScale = 1;

            Debug.Log("letter Fall");

        }

        Debug.Log("Game Ended");
        letters.Clear();
        numberofLetters = 0;

        isEnded = true;
    
    }
}
