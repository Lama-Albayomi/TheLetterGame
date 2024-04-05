using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject alf;
    [SerializeField] private GameObject baa;
    [SerializeField] private GameObject taa;
    [SerializeField] private GameObject thaa;
    [SerializeField] private GameObject Jeem;
    [SerializeField] private GameObject haa;
    [SerializeField] private GameObject Kaa;
    [SerializeField] private GameObject dal;
    [SerializeField] private GameObject zal;
    [SerializeField] private Transform startPos;
    private int numberofLetters = 0;
    private bool isEnded= false;
    private List<Letter> letters = new List<Letter>();
    void Start(){
        
    }
    void Update(){

        if (Input.GetKeyDown(KeyCode.Return)){
            SwitchGameState();
        }

        if(isEnded) return;
        // Get input from the user
        string input = Input.inputString;

        // Check if the input matches the Arabic character "أ"
        if (input == "أ"){
            LetterEntered(alf);
            Debug.Log("alf");
        } else if (input == "ب"){
            LetterEntered(baa);
            Debug.Log("baa");
        }else if (input == "ت"){
            LetterEntered(taa);
            Debug.Log("baa");
        }else if (input == "ث"){
            LetterEntered(thaa);
            Debug.Log("baa");
        }else if (input == "ج"){
            LetterEntered(Jeem);
            Debug.Log("baa");
        }else if (input == "ح"){
            LetterEntered(haa);
            Debug.Log("baa");
        }else if (input == "خ"){
            LetterEntered(Kaa);
            Debug.Log("baa");
        }else if (input == "د"){
            LetterEntered(dal); 
            Debug.Log("baa");
        }else if (input == "ذ"){
            LetterEntered(zal);
            Debug.Log("baa");
        }
        
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
        
        
        
    }
    public void LetterEntered(GameObject letter){
        numberofLetters++;
        int size = letter.GetComponent<Letter>().size;
        Vector3 letterPosition = startPos.position + new Vector3(numberofLetters + size, 0, 0);
        Letter inst =  Instantiate(letter, letterPosition, Quaternion.identity).GetComponent<Letter>();
        letters.Add(inst);
        
    }
    public void SwitchGameState(){
        if (isEnded){
            GameReset();
        }
        else{
            GameEnded();
        }
    
    }
    public void GameReset(){
        foreach(Letter letter in letters){
            Destroy(letter.gameObject);
        }
        letters.Clear();
        isEnded = false;
    }

    public void GameEnded(){
        foreach(Letter letter in letters){
            letter.Fall();
        }

        Debug.Log("Game Ended");
        numberofLetters = 0;

        isEnded = true;
    }
}
