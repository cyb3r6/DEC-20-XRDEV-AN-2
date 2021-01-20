using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    private List<int> keypadSequence = new List<int>();
    
    void Start()
    {
        keypadSequence.Add(4);
        keypadSequence.Add(4);
        keypadSequence.Add(4);
        keypadSequence.Add(4);
    }

    public void SendKeypad(int value)
    {
        
    }
   
}
