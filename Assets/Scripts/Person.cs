using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTracery;

public abstract class Person
{
    public int id;
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

    public string PullEvent(int index)
    {
        return events[index];
    }

    public void PullHistory(List<string> list)
    {
        foreach(string e in events)
        {
            list.Add(e);
        }
    }
}

public class Arcanist : Person
{
    public string school, specialty, schoolPronoun;

    public Arcanist(int id, TraceryGrammar tg, int numEvents=5, bool pcg = true):base(id, tg, numEvents)
    {
        if (!pcg)
        {
            string eventSet = "[#setArchivist#] #event1#\n#event2#\n#event3#\n#event4#\n#name#";
            string parsedData = tg.Parse(eventSet);


            name = parsedData.Split('\n')[4];

            // Alternate method for a more linear generation
            //events.Add(parsedData.Split('\n')[0]);
            //age += Random.Range(1, 30);
            //currentYear = birthYear + age;
            //events.Add(parsedData.Split('\n')[1]);
            //age += Random.Range(1, 30);
            //currentYear = birthYear + age;
            //events.Add(parsedData.Split('\n')[2]);
            //age += Random.Range(1, 30);
            //currentYear = birthYear + age;
            //events.Add(parsedData.Split('\n')[3]);

            // Method closer to that of the PCG - would have problems if introduced to a generator of more events than have been written
            for (int i = 0; i < numEvents; i++)
            {

                events.Add(parsedData.Split('\n')[i]);
                age += Random.Range(1, 30);
                currentYear = birthYear + age;
            }
        }
        else
        {
            string arcanistProperties = "[#setSchool#] #school# #specialty# #schoolPronoun#";
            string result = tg.Parse(arcanistProperties);
            school = result.Split(' ')[1];
            specialty = result.Split(' ')[2];
            schoolPronoun = result.Split(' ')[3];

            // Set up a single event from the #birthSequence# set, and add it to the beginning of the list.
            string birth = tg.Parse(string.Format("[archivist:{0}][heroThey:{1}][heroThem:{2}][heroTheir:{3}][heroTheirs:{4}][school:{5}][specialty:{6}][schoolPronoun:{7}][age:{8}][year:{9}] Year {9}: #birthSequence#", name, they, them, their, theirs, school, specialty, schoolPronoun, age, currentYear));
            events.Add(birth);
            age += Random.Range(1, 30);
            currentYear = birthYear + age;

            // fill the middle section with events. 
            for (int i = 0; i < numEvents - 2; i++)
            {
                string newEvent = tg.Parse(string.Format("[archivist:{0}][heroThey:{1}][heroThem:{2}][heroTheir:{3}][heroTheirs:{4}][school:{5}][specialty:{6}][schoolPronoun:{7}][age:{8}][year:{9}] Year {9}: #sequence#", name, they, them, their, theirs, school, specialty, schoolPronoun, age, currentYear));
                //Debug.Log(newEvent);
                events.Add(newEvent);
                age += Random.Range(1, 30);
                currentYear = birthYear + age;
            }

            // Set up a single event from the #deathSequence# set, and add it to the end of the list.
            string death = tg.Parse(string.Format("[archivist:{0}][heroThey:{1}][heroThem:{2}][heroTheir:{3}][heroTheirs:{4}][school:{5}][specialty:{6}][schoolPronoun:{7}][age:{8}][year:{9}] Year {9}: #deathSequence#", name, they, them, their, theirs, school, specialty, schoolPronoun, age, currentYear));
            events.Add(death);
        }
    }
}
