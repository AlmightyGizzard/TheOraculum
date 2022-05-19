using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTracery;

public abstract class Person : MonoBehaviour
{
    int id;
    public int age, birthYear, currentYear;
    public string name, they, them, their, theirs;
    public List<string> coreProperties;
    public List<string> events;

    public Person(int id, TraceryGrammar tg, int numEvents=5){
        events = new List<string>();
        this.id = id;
        name = tg.ResolveSymbol("#name#");
        // Pick a birth year - rather than invent a new system I'm just gonna go for our calendar,
        // then add a small amount - babies don't usually remember major moments. 
        birthYear = Random.Range(1605, 1681);
        currentYear = birthYear + Random.Range(3, 25);
        age = currentYear - birthYear;
        
        // Future Dom here with a bitchin' solution - use the parse command to produce a set of properties
        // together, then print each of those properties in sequence during construction and pull from
        // the resulting string. This can be done for subclasses whenever additional compound properties 
        // are needed too!
        string pronounSet = "[#setPronouns#] #heroThey# #heroThem# #heroTheir# #heroTheirs#";
        string result = tg.Parse(pronounSet);
        they = result.Split(' ')[1];
        them = result.Split(' ')[2];
        their = result.Split(' ')[3];
        theirs = result.Split(' ')[4];

        // For future Dom - the fact that pronouns are in a nested Tracery unit
        // screws up the assignment of each of the 4 variants. 
        // I THINK .PushAction can solve this by resolving setPronouns and assigning
        // the results of each to a different property, like a multiples version of
        // resolveSymbol. No docs on it though, so who knows.
        //tg.PushAction("#setPronouns#", they, them, their, theirs);



    }
}

public class Arcanist : Person
{
    public string school, specialty, schoolPronoun;

    public Arcanist(int id, TraceryGrammar tg, int numEvents=5):base(id, tg, numEvents)
    {
        string arcanistProperties = "[#setSchool#] #school# #specialty# #schoolPronoun#";
        string result = tg.Parse(arcanistProperties);
        school = result.Split(' ')[1];
        specialty = result.Split(' ')[2];
        schoolPronoun = result.Split(' ')[3];

        string birth = tg.Parse(string.Format("[archivist:{0}][heroThey:{1}][heroThem:{2}][heroTheir:{3}][heroTheirs:{4}][school:{5}][specialty:{6}][schoolPronoun:{7}][age:{8}] #birthSequence# age:{8}", name, they, them, their, theirs, school, specialty, schoolPronoun, age));
        
        events.Add(birth);
        age += Random.Range(1, 30);

        // fill the middle section with events. 
        for (int i = 0; i < numEvents-2; i++)
        {
            string newEvent = tg.Parse(string.Format("[archivist:{0}][heroThey:{1}][heroThem:{2}][heroTheir:{3}][heroTheirs:{4}][school:{5}][specialty:{6}][schoolPronoun:{7}][age:{8}] #sequence#", name, they, them, their, theirs, school, specialty, schoolPronoun, age));
            //Debug.Log(newEvent);
            events.Add(newEvent);
            age += Random.Range(1, 30);
        }

        string death = tg.Parse(string.Format("[archivist:{0}][heroThey:{1}][heroThem:{2}][heroTheir:{3}][heroTheirs:{4}][school:{5}][specialty:{6}][schoolPronoun:{7}][age:{8}] #deathSequence#", name, they, them, their, theirs, school, specialty, schoolPronoun, age));
        events.Add(death);

    }
}
