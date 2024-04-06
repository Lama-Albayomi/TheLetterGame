using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LetterSpacer : MonoBehaviour
{
    public GameObject[] letter;
    
    [SerializeField] private float LetterSpace;

    void Start()
    {
        foreach (GameObject letter in letter)
        {
            float spacing = letter.GetComponent<Letter>().size;
            // Set the position of the letter based on its size and the desired spacing.
            Vector3 postion = new Vector3(letter.transform.position.x + spacing * LetterSpace, letter.transform.position.y, letter.transform.position.z);
            Instantiate (letter, postion, quaternion.identity);
            
        }
    }
}
