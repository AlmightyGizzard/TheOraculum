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
    public GameObject trigger;
    string st = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
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
    // Start is called before the first frame update
    void Start()
    {
        sequence = GenerateSequence();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
