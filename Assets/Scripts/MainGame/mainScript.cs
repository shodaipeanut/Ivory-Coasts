using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mainScript : MonoBehaviour
{
    public static TMP_Text dialogue, stats, Fate;
    public static TMP_Text opt1, opt2, opt3;
   
    public static int curEvent = 1, day = 1, time = 0;

    public static int health = 100, happiness = 100, reputation = 100;
    public static float pay = 4.5f, wealth = 0f;
    public static bool caught = false, onMinigame = false, onEvent = false;
    
    public static float cocoaLoc = 0f;
    public static string fate = "";

    void Start()
    {
        dialogue = GameObject.FindWithTag("Dialogue").GetComponent<TMP_Text>();
        stats = GameObject.FindWithTag("Stats").GetComponent<TMP_Text>();
        Fate = GameObject.FindWithTag("Fate").GetComponent<TMP_Text>();
        opt1 = GameObject.FindWithTag("Opt1").GetComponent<TMP_Text>();
        opt2 = GameObject.FindWithTag("Opt2").GetComponent<TMP_Text>();
        opt3 = GameObject.FindWithTag("Opt3").GetComponent<TMP_Text>();
        fate = "";
        day = 1;
        update();
        farm(); 
    }

    static void farm()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<Transform>().position = new Vector3(0,2,-10);
        dialogue.text = "Time for work! Click repeatedly to harvest cocoa.";
        opt1.text = "";
        opt2.text = "";
        opt3.text = "";
        Fate.text = "";
        time = 0;
        onMinigame = true;
    }

    void Update()
    {
        
        if (onMinigame)
        {
            time++;
            GameObject.FindWithTag("Cocoa").GetComponent<Transform>().position = new Vector3(0.365f,2.014f + cocoaLoc,-1f);
            if (time > 1500 || cocoaLoc <= -0.2f)
            {
                onMinigame = false;
                GameObject.FindWithTag("MainCamera").GetComponent<Transform>().position = new Vector3(0,0,-10);
                randomEvent();
            }
        }
    }

    static void randomEvent()
    {   
        cocoaLoc = 0f;
        onEvent = true;
        int num = (int)Random.Range(1,10);
        switch (num) 
        {
            case 1:
                curEvent = 1;
                dialogue.text = "You overhear a conversation between your boss and someone you have never met before about the falling cocoa sales.";
                opt1.text = "Continue to listen in";
                opt2.text = "Run away from the farm";
                opt3.text = "Go back to farming";
            break;

            case 2:
                curEvent = 2;
                dialogue.text = "You get sick.";
                opt1.text = "Tell others and get help";
                opt2.text = "Continue working";
                opt3.text = "Tell the boss that you're sick";
            break;

            case 3:
                curEvent = 3;
                dialogue.text = "Another boy gets sick. Everyone is pooling their pay for his pharmacy visit.";
                opt1.text = "Pay for his amount";
                opt2.text = "Pay for two people";
                opt3.text = "Refuse to pay";
            break;

            case 4:
                curEvent = 4;
                dialogue.text = "You get hurt.";
                opt1.text = "Sneak out and buy a first aid kit";
                opt2.text = "Deal with it";
                opt3.text = "Rip off the hem of a shirt and use it to wrap your wound";
            break;

            case 5:
                curEvent = 5;
                dialogue.text = "Someone gets hurt from farming. They ask for some first aid equipment.";
                opt1.text = "Refuse";
                opt2.text = "Give needed bandages";
                opt3.text = "Give bandages in exchange for money";
            break;
            
            case 6:
                curEvent = 6;
                dialogue.text = "You are given corn paste again for dinner. Corn makes your stomach hurt, and you are tired of it.";
                opt1.text = "Sneak out and buy banana";
                opt2.text = "Sneak out to town to buy food";
                opt3.text = "Eat it";
            break;

            case 7:
                curEvent = 7;
                dialogue.text = "You have the opportunity to send money to your family.";
                opt1.text = "Send $10 to family";
                opt2.text = "Send $20 to family";
                opt3.text = "Send nothing to family";
            break;

            case 8:
                curEvent = 8;
                dialogue.text = "You recieve extra money this day.";
                opt1.text = "Save all of it";
                opt2.text = "Buy a toy";
                opt3.text = "Give some money to your siblings";
            break;
        
            case 9:
                curEvent = 9;
                dialogue.text = "Your boss tells you to carry a bag of cacao that is larger than your entire body. You think you will fall by carrying it.";
                opt1.text = "Refuse to carry it";
                opt2.text = "Ask someone else for help";
                opt3.text = "Carry it";
            break;

            case 10:
                curEvent = 10;
                dialogue.text = "A journalist goes to your farm and asks you how old you are while you are working. Your boss is right next to you, and you shuffle a little nervously.";
                opt1.text = "Tell him your actual age";
                opt2.text = "Lie";
                opt3.text = "Tell him your actual age after your boss leaves";
            break;
        }

    }

    public static void do1()
    {
        onEvent = false;
        switch(curEvent)
        {
            case 1:
                dialogue.text = "You hear voices. *I don’t have any more money.* *Then you must make some.* *I can’t even send my own children to school,* his voice clings with desperation, as he raises his voice... you hear a clop of hollow shoes. In fear, you run back to your room, and end the night.";
            break;
            case 2:
                pay -= 3f;
                if (chance(90))
                    health = 100;
            break;
            case 3:
                pay -= 3f;
            break;
            case 4:
                if (chance(50))
                    caught = true;
                else 
                    pay -= 5f;
            break;
            case 5:
                reputation -= 25;
            break;
            case 6:
                if (chance (5))
                    pay = 2.5f;
            break;
            case 7:
                wealth -= 10f;
                happiness += 15;
            break;
            case 8:
                wealth += 5f;
            break;
            case 9:
                if (chance(99))
                    health = 0;
            break;
            case 10:
                health = 0;
            break;
        }
        update();
    }

    public static void do2()
    {
        onEvent = false;
        switch(curEvent)
        {
            case 1:
                if (chance(90))
                    health = 0;
            break;
            case 2:
                if (chance(25))
                    pay -= 0.5f;
            break;
            case 3:
                wealth += 6f;
                reputation += 25;
            break;
            case 4:
                if (chance(50))
                    health = 0;
                else
                    wealth -= 5f;
            break;
            case 5:
                reputation += 25;
            break;
            case 6:
                happiness += 25;
                wealth -= 2f;
            break;
            case 7:
                wealth -= 20f;
                happiness += 30;
            break;
            case 8:
                wealth -= 3f;
                happiness += 40;
            break;
            case 9:
                happiness -= 5;
                reputation -= 5;
            break;
            case 10:
                happiness -= 75;
            break;
        }
        update();
    }

    public static void do3()
    {
        onEvent = false;
        switch(curEvent)
        {
            case 1:
                reputation += 10;
                happiness -= 10;
            break;
            case 2:
                if (chance(50))
                    health = 100;
                else
                    pay -= 1f;
            break;
            case 3:
                reputation -= 50;
            break;
            case 4:
                if (chance(25))
                    pay -= 1f;
            break;
            case 5:
                reputation -= 10;
                wealth += 2f;
            break;
            case 6:
                happiness -= 25;
                if (chance(25))
                    health -= 30;
            break;
            case 7:
                happiness -= 10;
            break;
            case 8:
                wealth -= 3f;
                reputation += 40;
                happiness += 5;
            break;
            case 9:
                wealth += 5f;
                if (chance(50))
                    health -= 30;
            break;
            case 10:
                happiness += 20;
            break;
        }
        update();
    }

    public static void update()
    {
        stats.text = "Health " + health + " | " + "Happiness: " + happiness + " | " + "Reputation: " + reputation + " | " + "Pay: $" + pay + " | " + "Wealth: $" + wealth;
    }

    private static bool chance(int percent)
    {
        int doThing = Random.Range(0,100);
        return doThing <= percent;
    }

    public static void payPerson()
    {
        wealth += pay;
        day++;
        if (health == 0)
        {
            fate = "You could not survive 7 days and died from health complications.";
            end();
        }
        else if (caught == true)
        {
            fate = "You were captured and brought back to the farm, where you continued on as a laborer for the rest of your childhood.";
            end();
        }
        else if (day == 7)
        {
            fate = "You were able to survive the week.";
            end();
        }
        else 
            farm();
    }

    public static void end()
    {
        dialogue.text = "";
        stats.text = "";
        opt1.text = "";
        opt2.text = "";
        opt3.text = "";
        Fate.text = fate;
        GameObject.FindWithTag("MainCamera").GetComponent<Transform>().position = new Vector3(0,-2,-10);
    }

}
