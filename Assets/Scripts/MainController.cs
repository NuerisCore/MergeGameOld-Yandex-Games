using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.Audio;

public class MainController : MonoBehaviour
{
    public static MainController instance;

    public GameObject mainPrefab;
    public GameObject effectPrefab;

    public Image[] cells;

    public int Level;

    public Transform parent;

    public Color ClosedC;

    public Sprite closed;
    public Sprite closed2;

    public Image[] images1;
    public Image[] images2;

    public GameObject[] Loacks;
    public GameObject[] Plays;
    public GameObject[] Ticks;

    public int[] levelspawns1;
    public int[] levelspawns2;
    public int[] levelspawns3;
    public int[] levelspawns4;
    public int[] levelspawns5;
    public int[] levelspawns6;
    public int[] levelspawns7;
    public int[] levelspawns8;
    public int[] levelspawns9;
    public int[] levelspawns10;
    public int[] levelspawns11;

    private int queue;

    public OBJ objects;

    public int OpenedLastLevel;

    public AudioMixer mic;

    public void Sound(bool a)
    {
        YG.YandexGame.savesData.isSound = a;

        if (a) mic.SetFloat("Sounds", 0f);
        else mic.SetFloat("Sounds", -80f);
        YG.YandexGame.SaveCloud();
    }

    public void Music(bool a)
    {
        YG.YandexGame.savesData.isMusic = a;

        if (a) mic.SetFloat("Music", 0f);
        else mic.SetFloat("Music", -80f);
        YG.YandexGame.SaveCloud();
    }

    private void Awake()
    {
        levelspawns10 = levelspawns10.Concat(levelspawns11).ToArray();
        instance = this;
        Invoke("Start2", 0.05f);
    }

    public GameObject[] assd;
    public GameObject assd2;
    public Toggle toggleS;
    public Toggle toggleM;

    public void WIN()
    {
        assd2.SetActive(true);
        for (int i = 0; i < assd.Length; i++)
        {
            if (i == Level - 1) assd[i].SetActive(true);
            else assd[i].SetActive(false);
        }

        if (Level == YG.YandexGame.savesData.openLevels) YG.YandexGame.savesData.openLevels++;
        Start2();
        YG.YandexGame.SaveCloud();
    }

    public void asf()
    {
        YG.YandexGame.FullscreenShow();
    }

    private void Start2()
    {
        OpenedLastLevel = YG.YandexGame.savesData.openLevels;

        if (YG.YandexGame.savesData.isMusic)
        {
            mic.SetFloat("Music", 0f);
            toggleM.isOn = true;
        }
        else
        {
            mic.SetFloat("Music", -80f);
            toggleM.isOn = false;
        }

        if (YG.YandexGame.savesData.isSound)
        {
            mic.SetFloat("Sounds", 0f);
            toggleS.isOn = true;
        }
        else
        {
            mic.SetFloat("Sounds", -80f);
            toggleS.isOn = false;
        }

        for (int i = 0; i < Plays.Length; i++)
        {
            if (i == OpenedLastLevel - 1)
            {
                Plays[i].SetActive(true);
                images1[i].color = Color.white;
                Loacks[i].SetActive(false);
                images2[i].sprite = closed2;
            }
            else if (i > OpenedLastLevel - 1)
            {
                Loacks[i].SetActive(true);
                images1[i].color = ClosedC;
                images2[i].sprite = closed;
            }
            else if (i < OpenedLastLevel - 1)
            {
                Ticks[i].SetActive(true);
                images1[i].color = Color.white;
                Loacks[i].SetActive(false);
                Plays[i].SetActive(false);
                images2[i].sprite = closed2;
            }
        }
    }

    public void ShuffleIntArrayInGroups(int[] array, int groupSize)
    {
        // Перемешиваем массив по частям, каждые groupSize элементов
        for (int i = 0; i < array.Length; i += groupSize)
        {
            int endIndex = Mathf.Min(i + groupSize, array.Length); // Находим конечный индекс для текущей группы
            // Используем алгоритм "Fisher-Yates shuffle" для текущей группы
            for (int j = endIndex - 1; j > i; j--)
            {
                int randomIndex = Random.Range(i, j + 1); // Генерируем случайный индекс в текущей группе
                // Меняем элементы массива местами
                int temp = array[j];
                array[j] = array[randomIndex];
                array[randomIndex] = temp;
            }
        }
    }

    public GameObject[] game1;
    public GameObject[] game2;

    public void StartGame(int id)
    {
        if (id > OpenedLastLevel) return;

        Level = id;

        for (int i = 0; i < game1.Length; i++)
        {
            game1[i].SetActive(true);
        }
        for (int i = 0; i < game2.Length; i++)
        {
            game2[i].SetActive(false);
        }

        StartSpawnFull();

        if (Level == 1) palc.gameObject.SetActive(true);
    }

    public Transform palc;

    public void Back()
    {
        queue = 0;
        iis = false;
        Tutor.instance.target1 = null;
        Tutor.instance.target2 = null;
        Tutor.instance.quque = 0;
        objects.allFalse();

        GameObject[] a = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i].activeSelf) Destroy(a[i]);
        }

        for (int i = 0; i < game2.Length; i++)
        {
            game2[i].SetActive(true);
        }
        for (int i = 0; i < game1.Length; i++)
        {
            game1[i].SetActive(false);
        }
        asf();
    }

    public void StartSpawnFull()
    {
        objects.DoStart(Level);

        List<int> randomList = new List<int>();

        for (int i = 0; i < 8; i++)
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Range(0, 8);
            } while (randomList.Contains(randomNumber));

            randomList.Add(randomNumber);
        }

        //ShuffleIntArrayInGroups(levelspawns5, 20);

        // Конвертируем List<int> обратно в массив int[]
        int[] randomArray = randomList.ToArray();

        SpawnOne(GetFromQueue(), randomArray[0]);
        queue++;
        SpawnOne(GetFromQueue(), randomArray[1]);
        queue++;
        SpawnOne(GetFromQueue(), randomArray[2]);
        queue++;
        SpawnOne(GetFromQueue(), randomArray[3]);
        queue++;
        SpawnOne(GetFromQueue(), randomArray[4]);
        queue++;
        SpawnOne(GetFromQueue(), randomArray[5]);
        queue++;
        SpawnOne(GetFromQueue(), randomArray[6]);
        queue++;
        SpawnOne(GetFromQueue(), randomArray[7]);
        queue++;
    }

    bool iis;

    public void SpawnOne(int id, int cellid)
    {
        var a = Instantiate(mainPrefab, cells[cellid].transform.position, Quaternion.identity);
        a.GetComponent<IconAniController>().thisImage = cells[cellid];
        a.GetComponent<IconAniController>().ani = cells[cellid].GetComponent<Animator>();
        a.GetComponent<IconController>().id = id;
        a.GetComponent<IconController>().ids = cellid;
        a.transform.SetParent(parent.transform);
        a.SetActive(true);

        if (id > 33)
        {
            a.GetComponent<Image>().SetNativeSize();
            a.GetComponent<RectTransform>().sizeDelta = a.GetComponent<RectTransform>().sizeDelta / 3.7f;

            if (Level == 1 && !iis)
            {
                Tutor.instance.target1 = null;
                Tutor.instance.target2 = null;
                Tutor.instance.quque = 3;
                palc.gameObject.SetActive(true);
                iis = true;
            }
        }
    }

    public void Merged(int ids, int cellid, int seconscell, Transform mergable, GameObject merged, bool ifd = false)
    {
        var e = Instantiate(effectPrefab, mergable.position, Quaternion.identity);
        e.transform.SetParent(transform.transform);
        e.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0, 360));
        e.SetActive(true);
        Destroy(e, 2f);
        if (ifd) Destroy(e);

        if (!ifd) SpawnOne(inMerge(ids), cellid);

        if (levelR())
        {
            SpawnOne(GetFromQueue(), seconscell);
            queue++;
        }

        if (Level == 1 && queue == 10) palc.gameObject.SetActive(false);

        Destroy(merged.gameObject);
        if (!ifd) Destroy(mergable.gameObject);
    }

    public int GetFromQueue()
    {
        int result = 0;

        if (Level == 1) result = levelspawns1[queue];
        else if (Level == 2) result = levelspawns2[queue];
        else if (Level == 3) result = levelspawns3[queue];
        else if (Level == 4) result = levelspawns4[queue];
        else if (Level == 5) result = levelspawns5[queue];
        else if (Level == 6) result = levelspawns6[queue];
        else if (Level == 7) result = levelspawns7[queue];
        else if (Level == 8) result = levelspawns8[queue];
        else if (Level == 9) result = levelspawns9[queue];
        else if (Level == 10) result = levelspawns10[queue];

        return result;
    }

    public bool levelR()
    {
        bool result = false;

        if (Level == 1 && queue < levelspawns1.Length) result = true;
        else if (Level == 2 && queue < levelspawns2.Length) result = true;
        else if (Level == 3 && queue < levelspawns3.Length) result = true;
        else if (Level == 4 && queue < levelspawns4.Length) result = true;
        else if (Level == 5 && queue < levelspawns5.Length) result = true;
        else if (Level == 6 && queue < levelspawns6.Length) result = true;
        else if (Level == 7 && queue < levelspawns7.Length) result = true;
        else if (Level == 8 && queue < levelspawns8.Length) result = true;
        else if (Level == 9 && queue < levelspawns9.Length) result = true;
        else if (Level == 10 && queue < levelspawns10.Length) result = true;

        return result;
    }

    public int inMerge(int id)
    {
        int result = 0;

        if (Level == 1)
        {
            if (id == 13) result = 14;
            else if (id == 14) result = 18;
            else if (id == 18) result = 2;
            else if (id == 2) result = 24;
            else if (id == 24) result = 11;
            else if (id == 11) result = 1;
            else if (id == 1) result = 27;
            else if (id == 27) result = 46;

            else if (id == 3) result = 20;
            else if (id == 20) result = 22;
            else if (id == 22) result = 6;
            else if (id == 6) result = 45;

            else if (id == 12) result = 21;
            else if (id == 21) result = 16;
            else if (id == 16) result = 15;
            else if (id == 15) result = 7;
            else if (id == 7) result = 5;
            else if (id == 5) result = 44;
        }
        else if (Level == 2 || Level == 8)
        {
            if (id == 3) result = 22;
            else if (id == 22) result = 23;
            else if (id == 23) result = 25;
            else if (id == 25) result = 6;
            else if (id == 6) result = 10;
            else if (id == 10) result = 20;
            else if (id == 20) result = 49;

            else if (id == 2) result = 24;
            else if (id == 24) result = 11;
            else if (id == 11) result = 27;
            else if (id == 27) result = 1;
            else if (id == 1) result = 19;
            else if (id == 19) result = 48;

            else if (id == 21) result = 16;
            else if (id == 16) result = 7;
            else if (id == 7) result = 12;
            else if (id == 12) result = 15;
            else if (id == 15) result = 13;
            else if (id == 13) result = 14;
            else if (id == 14) result = 18;
            else if (id == 18) result = 5;
            else if (id == 5) result = 47;
        }
        else
        {
            if (id == 21) result = 16;
            else if (id == 16) result = 7;
            else if (id == 7) result = 5; //5 bread

            else if (id == 3) result = 22;
            else if (id == 22) result = 23;
            else if (id == 23) result = 25;
            else if (id == 25) result = 8;
            else if (id == 8) result = 6; //6 meat

            else if (id == 15) result = 13;
            else if (id == 13) result = 14;
            else if (id == 14) result = 18; //18 tomato

            else if (id == 2) result = 24;
            else if (id == 24) result = 11;
            else if (id == 11) result = 27;
            else if (id == 27) result = 1;
            else if (id == 1) result = 20; //20 cheese

            else if (id == 12) result = 9;
            else if (id == 9) result = 0; //0 salat

            if (Level == 3 || Level == 7 || Level == 9)
            {
                if (id == 5) result = 55;
                else if (id == 6) result = 56;
                else if (id == 18) result = 57;
                else if (id == 20) result = 58;
                else if (id == 0) result = 59;
            }
            else if (Level == 4)
            {
                if (id == 5) result = 50;
                else if (id == 6) result = 51;
                else if (id == 18) result = 54;
                else if (id == 20) result = 53;
                else if (id == 0) result = 52;
            }
            else if (Level == 5)
            {
                if (id == 5) result = 39;
                else if (id == 6) result = 43;
                else if (id == 18) result = 40;
                else if (id == 20) result = 42;
                else if (id == 0) result = 41;
            }
            else if (Level == 6 || Level == 10)
            {
                if (id == 5) result = 34;
                else if (id == 6) result = 38;
                else if (id == 18) result = 36;
                else if (id == 20) result = 35;
                else if (id == 0) result = 37;
            }
        }

        return result;
    }
}
