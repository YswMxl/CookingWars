using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientScript : MonoBehaviour
{
    List<string> isViablePlate = new List<string> { "Smoothie", "Pizza" };
    List<string> isViableIngridient = new List<string> { "NutNBolt", "Fuse", "Antifreeze", "Oil", "Gear" };

    List<string> selectOrderIngridients;
    string selectOrderPlate;
    int timeTaken;

    bool showorder;//Call through animation!!!!!!!

    // Start is called before the first frame update
    void Start()
    {
        MakePlate();
    }

    // Update is called once per frame
    void MakePlate()
    {
        int plate = Random.RandomRange(0, 2);
        int difficulty = Random.RandomRange(0, 5);
        List<string> ingridients;
        for(int i= 0; i < difficulty; i++)
        {
            int j = Random.RandomRange(0, 5);
            selectOrderIngridients.Add(isViableIngridient[j]);
        }
    }
    public List<string> GiveOrderIngridients()
    {
        return selectOrderIngridients;
    }
    public string GiveOrderPlate()
    {
        return selectOrderPlate;
    }
    public int GiveTimeTaken()
    {
        return timeTaken;
    }
    void Timer()//LLamar a traves de animacion!!!!!!
    {
        float counter = 0; 
        counter += Time.deltaTime;
        if (counter >= 5f) 
        {
            timeTaken = -1;
            //Irritated -1 RankPLate()
        }
        else if (counter >= 10f)
        {
            timeTaken = -3;
        }
        else if (counter >= 15f)
        {
            AbandonShop();
        }
    }
    public void AbandonShop()
    {
        /*
         * Animacion de abandonar tieda
         */
    }
    void DestroyClient()
    {
        /*
         * Llamar a traves de animacion
         */
        Destroy(this.gameObject);
    }
}
