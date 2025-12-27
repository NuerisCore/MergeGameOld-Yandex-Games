using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ : MonoBehaviour
{
    public MeshRenderer[] levelFoodd;

    public GameObject[] Burger;
    public GameObject[] CheeseBurger;
    public GameObject[] DoubleCheeseBurger;
    public GameObject[] Sendwich;
    public GameObject[] SuperSendwich;

    public Material[] cheese_Mat;
    public Material[] bread_Mat;
    public Material[] meat_Mat;
    public Material[] tomato_Mat;
    public Material[] salat_Mat;
    public Material[] other_Mat;

    public Material Transparanted;
    public Material[] Transparanted1;
    public Material[] Transparanted2;
    public Material[] Transparanted3;

    public void allFalse()
    {
        np = 0;

        isDone = false;
        isDone2 = false;
        isDone3 = false;
        isDone4 = false;
        isDone5 = false;

        levelFoodd[0].gameObject.SetActive(false);
        levelFoodd[0].GetComponent<MeshRenderer>().materials = Transparanted1;
        levelFoodd[1].gameObject.SetActive(false);
        levelFoodd[1].GetComponent<MeshRenderer>().materials = Transparanted1;
        levelFoodd[3].gameObject.SetActive(false);
        levelFoodd[3].GetComponent<MeshRenderer>().materials = Transparanted2;
        levelFoodd[4].gameObject.SetActive(false);
        levelFoodd[4].GetComponent<MeshRenderer>().materials = Transparanted3;
        levelFoodd[7].gameObject.SetActive(false);
        levelFoodd[7].GetComponent<MeshRenderer>().materials = Transparanted1;
        for (int i = 0; i < Burger.Length; i++)
        {
            Burger[i].SetActive(false);
            Burger[i].GetComponent<MeshRenderer>().material = Transparanted;
        }
        for (int i = 0; i < Sendwich.Length; i++)
        {
            Sendwich[i].SetActive(false);
            Sendwich[i].GetComponent<MeshRenderer>().material = Transparanted;
        }
        for (int i = 0; i < CheeseBurger.Length; i++)
        {
            CheeseBurger[i].SetActive(false);
            CheeseBurger[i].GetComponent<MeshRenderer>().material = Transparanted;
        }
        for (int i = 0; i < DoubleCheeseBurger.Length; i++)
        {
            DoubleCheeseBurger[i].SetActive(false);
            DoubleCheeseBurger[i].GetComponent<MeshRenderer>().material = Transparanted;
        }
        for (int i = 0; i < SuperSendwich.Length; i++)
        {
            SuperSendwich[i].SetActive(false);
            SuperSendwich[i].GetComponent<MeshRenderer>().material = Transparanted;
        }
    }

    public void DoStart(int Level)
    {
        if (Level == 1)
        {
            levelFoodd[0].gameObject.SetActive(true);
        }
        else if (Level == 2)
        {
            levelFoodd[1].gameObject.SetActive(true);
        }
        else if (Level == 3)
        {
            for (int i = 0; i < Burger.Length; i++)
            {
                Burger[i].SetActive(true);
            }
        }
        else if (Level == 4)
        {
            levelFoodd[3].gameObject.SetActive(true);
        }
        else if (Level == 5)
        {
            levelFoodd[4].gameObject.SetActive(true);
        }
        else if (Level == 6)
        {
            for (int i = 0; i < Sendwich.Length; i++)
            {
                Sendwich[i].SetActive(true);
            }
        }
        else if (Level == 7)
        {
            for (int i = 0; i < CheeseBurger.Length; i++)
            {
                CheeseBurger[i].SetActive(true);
            }
        }
        else if (Level == 8)
        {
            levelFoodd[7].gameObject.SetActive(true);
        }
        else if (Level == 9)
        {
            for (int i = 0; i < DoubleCheeseBurger.Length; i++)
            {
                DoubleCheeseBurger[i].SetActive(true);
            }
        }
        else if (Level == 10)
        {
            for (int i = 0; i < SuperSendwich.Length; i++)
            {
                SuperSendwich[i].SetActive(true);
            }
        }
    }

    public int[] predels;
    int np;
    public GameObject[] particlesl;

    private void InvokeWin()
    {
        MainController.instance.WIN();
    }

    public void Entered(int Level, int id)
    {
        MainController.instance.palc.gameObject.SetActive(false);

        np++;
        particlesl[Level - 1].SetActive(false);
        particlesl[Level - 1].SetActive(true);
        if (predels[Level - 1] == np) Invoke("InvokeWin", 0.5f);

        if (Level == 1)
        {
            Material[] materials = levelFoodd[0].materials;
            if (id == 44) materials[1] = new Material(bread_Mat[0]);
            if (id == 45) materials[2] = new Material(meat_Mat[0]);
            if (id == 46) materials[0] = new Material(cheese_Mat[0]);
            if (id == 46) materials[3] = new Material(tomato_Mat[0]);
            levelFoodd[0].materials = materials;
        }
        else if (Level == 2)
        {
            Material[] materials = levelFoodd[1].materials;
            if (id == 47) materials[0] = new Material(bread_Mat[1]);
            if (id == 47) materials[1] = new Material(tomato_Mat[1]);
            if (id == 49) materials[2] = new Material(meat_Mat[1]);
            if (id == 48) materials[3] = new Material(cheese_Mat[1]);
            levelFoodd[1].materials = materials;
        }
        else if (Level == 3)
        {
            if (id == 55) Burger[1].GetComponent<MeshRenderer>().material = bread_Mat[2];
            if (id == 55) Burger[2].GetComponent<MeshRenderer>().material = bread_Mat[2];
            if (id == 56) Burger[7].GetComponent<MeshRenderer>().material = meat_Mat[2];
            if (id == 57) Burger[5].GetComponent<MeshRenderer>().material = tomato_Mat[2];
            if (id == 59) Burger[3].GetComponent<MeshRenderer>().material = salat_Mat[2];
            if (id == 59) Burger[4].GetComponent<MeshRenderer>().material = salat_Mat[2];

            Burger[0].SetActive(false);
            Burger[6].SetActive(false);
        }
        else if (Level == 4)
        {
            Material[] materials = levelFoodd[3].materials;
            if (id == 50) materials[1] = new Material(bread_Mat[3]);
            if (id == 51) materials[2] = new Material(meat_Mat[3]);
            if (id == 54) materials[4] = new Material(tomato_Mat[3]);
            if (id == 52) materials[0] = new Material(salat_Mat[3]);
            if (id == 53) materials[3] = new Material(cheese_Mat[3]);
            levelFoodd[3].materials = materials;
        }
        else if (Level == 5)
        {
            Material[] materials = levelFoodd[4].materials;
            if (id == 39) materials[5] = new Material(bread_Mat[4]);
            if (id == 39) materials[4] = new Material(other_Mat[4]);
            if (id == 43) materials[0] = new Material(meat_Mat[4]);
            if (id == 43) materials[6] = new Material(meat_Mat[4]);
            if (id == 40) materials[2] = new Material(tomato_Mat[4]);
            if (id == 41) materials[1] = new Material(salat_Mat[4]);
            if (id == 42) materials[3] = new Material(cheese_Mat[4]);
            levelFoodd[4].materials = materials;
        }
        else if (Level == 6)
        {
            if (id == 34) Sendwich[0].GetComponent<MeshRenderer>().material = bread_Mat[5];
            if (id == 34) Sendwich[1].GetComponent<MeshRenderer>().material = bread_Mat[5];

            if (id == 38) Sendwich[9].GetComponent<MeshRenderer>().material = meat_Mat[5];
            if (id == 38) Sendwich[10].GetComponent<MeshRenderer>().material = meat_Mat[5];
            if (id == 38) Sendwich[11].GetComponent<MeshRenderer>().material = meat_Mat[5];

            if (id == 36) Sendwich[5].GetComponent<MeshRenderer>().material = tomato_Mat[5];
            if (id == 36) Sendwich[6].GetComponent<MeshRenderer>().material = tomato_Mat[5];
            if (id == 36) Sendwich[7].GetComponent<MeshRenderer>().material = tomato_Mat[5];

            if (id == 35) Sendwich[2].GetComponent<MeshRenderer>().material = cheese_Mat[5];
            if (id == 35) Sendwich[3].GetComponent<MeshRenderer>().material = cheese_Mat[5];
            if (id == 35) Sendwich[4].GetComponent<MeshRenderer>().material = cheese_Mat[5];

            if (id == 37) Sendwich[8].GetComponent<MeshRenderer>().material = salat_Mat[5];
        }
        else if (Level == 7)
        {
            if (id == 55) CheeseBurger[1].GetComponent<MeshRenderer>().material = bread_Mat[6];
            if (id == 55) CheeseBurger[2].GetComponent<MeshRenderer>().material = bread_Mat[6];
            if (id == 56) CheeseBurger[7].GetComponent<MeshRenderer>().material = meat_Mat[6];
            if (id == 57) CheeseBurger[5].GetComponent<MeshRenderer>().material = tomato_Mat[6];
            if (id == 59) CheeseBurger[3].GetComponent<MeshRenderer>().material = salat_Mat[6];
            if (id == 59) CheeseBurger[4].GetComponent<MeshRenderer>().material = salat_Mat[6];
            if (id == 58 && isDone) CheeseBurger[6].GetComponent<MeshRenderer>().material = cheese_Mat[6];
            else if (id == 58)
            {
                CheeseBurger[0].GetComponent<MeshRenderer>().material = cheese_Mat[6];
                isDone = true;
            }
        }
        else if (Level == 8)
        {
            Material[] materials = levelFoodd[7].materials;
            if (id == 47) materials[0] = new Material(bread_Mat[7]);
            if (id == 47) materials[1] = new Material(tomato_Mat[7]);
            if (id == 49) materials[2] = new Material(meat_Mat[7]);
            if (id == 48) materials[3] = new Material(cheese_Mat[7]);
            levelFoodd[7].materials = materials;
        }
        else if (Level == 9)
        {
            if (id == 55) DoubleCheeseBurger[0].GetComponent<MeshRenderer>().material = bread_Mat[6];
            if (id == 55) DoubleCheeseBurger[1].GetComponent<MeshRenderer>().material = bread_Mat[6];

            if (id == 56 && isDone2) DoubleCheeseBurger[9].GetComponent<MeshRenderer>().material = meat_Mat[6];
            else if (id == 56)
            {
                DoubleCheeseBurger[8].GetComponent<MeshRenderer>().material = meat_Mat[6];
                isDone2 = true;
            }

            if (id == 57) DoubleCheeseBurger[7].GetComponent<MeshRenderer>().material = tomato_Mat[6];

            if (id == 59) DoubleCheeseBurger[5].GetComponent<MeshRenderer>().material = salat_Mat[6];
            if (id == 59) DoubleCheeseBurger[6].GetComponent<MeshRenderer>().material = salat_Mat[6];

            if (id == 58 && isDone) DoubleCheeseBurger[4].GetComponent<MeshRenderer>().material = cheese_Mat[6];
            else if (id == 58 && isDone3)
            {
                DoubleCheeseBurger[3].GetComponent<MeshRenderer>().material = cheese_Mat[6];
                isDone = true;
            }
            else if (id == 58)
            {
                DoubleCheeseBurger[2].GetComponent<MeshRenderer>().material = cheese_Mat[6];
                isDone3 = true;
            }
        }
        else if (Level == 10)
        {
            if (id == 34 && isDone) SuperSendwich[1].GetComponent<MeshRenderer>().material = bread_Mat[5];
            else if (id == 34)
            {
                SuperSendwich[2].GetComponent<MeshRenderer>().material = bread_Mat[5];
                SuperSendwich[0].GetComponent<MeshRenderer>().material = bread_Mat[5];
                isDone = true;
            }

            if (id == 35 && isDone2)
            {
                SuperSendwich[3].GetComponent<MeshRenderer>().material = cheese_Mat[5];
                SuperSendwich[4].GetComponent<MeshRenderer>().material = cheese_Mat[5];
                SuperSendwich[5].GetComponent<MeshRenderer>().material = cheese_Mat[5];
            }
            else if (id == 35)
            {
                SuperSendwich[6].GetComponent<MeshRenderer>().material = cheese_Mat[5];
                SuperSendwich[7].GetComponent<MeshRenderer>().material = cheese_Mat[5];
                SuperSendwich[8].GetComponent<MeshRenderer>().material = cheese_Mat[5];
                isDone2 = true;
            }

            if (id == 36 && isDone3)
            {
                SuperSendwich[9].GetComponent<MeshRenderer>().material = tomato_Mat[5];
                SuperSendwich[10].GetComponent<MeshRenderer>().material = tomato_Mat[5];
                SuperSendwich[11].GetComponent<MeshRenderer>().material = tomato_Mat[5];
            }
            else if (id == 36)
            {
                SuperSendwich[12].GetComponent<MeshRenderer>().material = tomato_Mat[5];
                SuperSendwich[13].GetComponent<MeshRenderer>().material = tomato_Mat[5];
                SuperSendwich[14].GetComponent<MeshRenderer>().material = tomato_Mat[5];
                isDone3 = true;
            }


            if (id == 37 && isDone4) SuperSendwich[15].GetComponent<MeshRenderer>().material = salat_Mat[5];
            else if (id == 37)
            {
                SuperSendwich[16].GetComponent<MeshRenderer>().material = salat_Mat[5];
                isDone4 = true;
            }

            if (id == 38 && isDone5)
            {
                SuperSendwich[17].GetComponent<MeshRenderer>().material = meat_Mat[5];
                SuperSendwich[18].GetComponent<MeshRenderer>().material = meat_Mat[5];
                SuperSendwich[19].GetComponent<MeshRenderer>().material = meat_Mat[5];
            }
            else if (id == 38)
            {
                SuperSendwich[20].GetComponent<MeshRenderer>().material = meat_Mat[5];
                SuperSendwich[21].GetComponent<MeshRenderer>().material = meat_Mat[5];
                SuperSendwich[22].GetComponent<MeshRenderer>().material = meat_Mat[5];
                isDone5 = true;
            }
        }
    }

    bool isDone = false;
    bool isDone2 = false;
    bool isDone3 = false;
    bool isDone4 = false;
    bool isDone5 = false;
}
