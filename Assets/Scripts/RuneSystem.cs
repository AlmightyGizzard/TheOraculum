using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sequence
{
    public int length;
    public List<char> symbols;
}
public class RuneSystem : MonoBehaviour
{
    public List<GameObject> runes;
    public List<string> words;
    public string answer;
    public GameObject trigger;
    public string st = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private Sequence sequence;

    public Sequence GenerateSequence()
    {
        Sequence result = new Sequence();
        result.length = 0;
        result.symbols = new List<char>();
        foreach(GameObject g in runes)
        {
            char c = st[Random.Range(0, st.Length)];
            result.symbols.Add(c);
            result.length++;
            g.GetComponentInChildren<TextMeshPro>().SetText(c.ToString());

            Debug.Log(c);
        }
        return result;
    }


    public void Guess()
    {
        bool correct = true;
        int index = 0;
        foreach(GameObject g in runes)
        {
            TextMeshPro letterText = g.GetComponentInChildren<TextMeshPro>();
            char guessLetter = char.Parse(letterText.GetParsedText());

            if(answer[index] == guessLetter)
            {
                letterText.color = Color.green;
            }
            else if (answer.Contains(guessLetter.ToString()))
            {
                letterText.color = Color.yellow;
                correct = false;
            }
            else
            {
                Debug.Log(guessLetter + " is not equal to " + answer[index]);
                correct = false;
            }
            index++;
        }
        if (correct)
        {
            Debug.Log("Correct!!!");
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        sequence = GenerateSequence();
        answer = words[Random.Range(0, words.Count)];
    }
}
