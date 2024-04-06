using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Range (0, 10)]
    [SerializeField] private float LetterSpace;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject alfHamza;
    [SerializeField] private GameObject alf;
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
    [SerializeField] private GameObject sheen;
    [SerializeField] private GameObject sad;
    [SerializeField] private GameObject dad;
    [SerializeField] private GameObject tahh;
    [SerializeField] private GameObject dahh;
    [SerializeField] private GameObject ayn;
    [SerializeField] private GameObject kyn;
    [SerializeField] private GameObject faa;
    [SerializeField] private GameObject khaf;
    [SerializeField] private GameObject kaf;
    [SerializeField] private GameObject lam;
    [SerializeField] private GameObject meem;
    [SerializeField] private GameObject noon;
    [SerializeField] private GameObject haaa;
    [SerializeField] private GameObject waw;
    [SerializeField] private GameObject yaa;
    [SerializeField] private Transform startPos;
    [SerializeField] private int numberofSpaces = 0;
    private bool isEnded= false;
    private int TargetPoints;
    private bool TouchedTargetPoint=false;
    private bool lost = false;
    [SerializeField] private float timer = 1f;
    private List<Letter> letters = new List<Letter>();
    private void Awake(){
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    void Start(){
        TargetPoints = FindObjectsOfType<EndPoint>().Length;
    }
    void Update(){

        if (Input.GetKeyDown(KeyCode.Return)){
            SwitchGameState();
        }

        if (lost) return;
        
        if (TouchedTargetPoint){
            timer -= Time.deltaTime;
            if (timer <= 0 && TargetPoints>0){
                Debug.Log("Lose");
                lost = true;
            }
        }


        if(isEnded) return;
        
        // Get input from the user
        string input = Input.inputString;

        // Check if the input matches the Arabic character "أ"
        if (input == "ا"){
            LetterEntered(alf);
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
        }else if (input == "ش"){
            LetterEntered(sheen);
        }else if (input == "ص"){
            LetterEntered(sad);
        }else if (input == "ض"){
            LetterEntered(dad);
        }else if (input == "ط"){
            LetterEntered(tahh);
        }else if (input == "ظ"){
            LetterEntered(dahh);
        }else if (input == "ع"){
            LetterEntered(ayn);
        }else if (input == "غ"){
            LetterEntered(kyn);
        }else if (input == "ف"){
            LetterEntered(faa);
        }else if (input == "ق"){
            LetterEntered(kaf);
        }else if (input == "ك"){
            LetterEntered(khaf);
        }else if (input == "ل"){
            LetterEntered(lam);
        }else if (input == "م"){
            LetterEntered(meem);
        }else if (input == "ن"){
            LetterEntered(noon);
        }else if (input == "ه"){
            LetterEntered(haaa);
        }else if (input == "و"){
            LetterEntered(waw);
        }else if (input == "ي"){
            LetterEntered(yaa);
        }
        
        // space
        else if (input == " "){
            AddSpace();
        }
        
        
        
    }
    public void TouchTargetPoint(){
        if (TargetPoints>1){
            TargetPoints--;
            TouchedTargetPoint = true;

        }
        else{
            Debug.Log("End");
        }
    }
    private void LetterEntered(GameObject letter){
        int size = letter.GetComponent<Letter>().size;
        if (numberofSpaces + size > levelManager.LetterSpaceLimit){
            Debug.Log("cant Enter");
            return;
        }
        else{
            numberofSpaces += size;
            Vector3 letterPosition = startPos.position + new Vector3(numberofSpaces * LetterSpace, 0, 0);
            Letter inst =  Instantiate(letter, letterPosition, Quaternion.identity).GetComponent<Letter>();
            letters.Add(inst);
        }
    }
    private void AddSpace(){
        if (numberofSpaces + 1 > levelManager.LetterSpaceLimit){
            Debug.Log("cant Enter");
            return;
        }
        else{
            numberofSpaces += 1;
        }
    }
    private void SwitchGameState(){
        if (isEnded){
            GameReset();
        }
        else{
            GameEnded();
        }
    
    }
    private void GameReset(){
        foreach(Letter letter in letters){
            Destroy(letter.gameObject);
        }
        letters.Clear();
        isEnded = false;
        lost = false;
    }
    private void GameEnded(){
        foreach(Letter letter in letters){
            letter.Fall();
        }

        numberofSpaces = 0;

        isEnded = true;
    }
}
