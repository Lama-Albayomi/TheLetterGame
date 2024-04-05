using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Range (0, 10)]
    [SerializeField] private float LetterSpace;
    [SerializeField] private GameObject alf;
    [SerializeField] private GameObject alfHamza;
    [SerializeField] private GameObject baa;
    [SerializeField] private GameObject taa;
    [SerializeField] private GameObject thaa;
    [SerializeField] private GameObject Jeem;
    [SerializeField] private GameObject haa;
    [SerializeField] private GameObject Kaa;
    [SerializeField] private GameObject dal;
    [SerializeField] private GameObject zal;
    [SerializeField] private GameObject raa;
    [SerializeField] private GameObject zeen;
    [SerializeField] private GameObject seen;
    [SerializeField] private Transform startPos;
    private int numberofSpaces = 0;
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
        if (input == "ا"){
            LetterEntered(alf);
            Debug.Log("alf");
        } else if (input == "أ"){
            LetterEntered(alfHamza);
        }else if (input == "ب"){
            LetterEntered(baa);
        }else if (input == "ت"){
            LetterEntered(taa);
        }else if (input == "ث"){
            LetterEntered(thaa);
        }else if (input == "ج"){
            LetterEntered(Jeem);
        }else if (input == "ح"){
            LetterEntered(haa);
        }else if (input == "خ"){
            LetterEntered(Kaa);
        }else if (input == "د"){
            LetterEntered(dal); 
        }else if (input == "ذ"){
            LetterEntered(zal);
        }else if (input == "ر"){
            LetterEntered(raa);
        }else if (input == "ز"){
            LetterEntered(zeen);
        }else if (input == "س"){
            LetterEntered(seen);
        }
        
        
        
    }
    public void LetterEntered(GameObject letter){
        int size = letter.GetComponent<Letter>().size;
        numberofSpaces += size;
        Vector3 letterPosition = startPos.position + new Vector3(numberofSpaces * LetterSpace, 0, 0);
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
        numberofSpaces = 0;

        isEnded = true;
    }
}
