using System.Collections;
using System.Collections.Generic;
using PixelSpriteGenerator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ProblemSet
{
    public string question;
    public List<string> answer;
}
public class MatrixManager : MonoBehaviour
{
    public List<ProblemSet> questions;
    public Text start_text;
    public Text end_text;
    public Text question_text;

    public List<string> list;
    public void StartTest()
    {
        index = 0;
        start_text.enabled = false;
        start_button.SetActive(false);
        list = new List<string>();
        Present();
    }
    public Transform grid;
    public GameObject answer_button;
    public GameObject replay_button;
    public GameObject start_button;

    void Present()
    {
        ProblemSet q = questions[index];
        question_text.text = q.question;
        grid.ClearChild();
        for (int i = 0; i < q.answer.Count; i++)
        {
            int idx = i;
            GameObject go = Instantiate(answer_button, grid);
            go.GetComponentInChildren<Text>().text = q.answer[i];
            go.GetComponent<Button>().onClick.AddListener(() => { GoNext(idx.ToString()); });
        }
    }
    int index = 0;
    public void GoNext(string res)
    {
        list.Add(res);
        index++;
        if (index >= questions.Count)
            EndTest();
        else
            Present();
    }
    public void Replay()
    {
        end_text.enabled = false;
        start_text.enabled = true;
        replay_button.SetActive(false);
        start_button.SetActive(true);
        sp.SetActive(false);
    }
    public GameObject sp;
    public void EndTest()
    {
        grid.ClearChild();
        question_text.text = "";
        end_text.enabled = true;
        // Visualize();
        string lst = "";
        for (int i = 0; i < list.Count; i++)
        {
            lst += list[i];
        }
        int seed = lst.ToInt();
        System.Random rad = new System.Random(seed);
        generator.DemoButtonPressed(rad.Next(0, 7), rad);
        replay_button.SetActive(true);
        sp.SetActive(true);

    }
    public Material material;
    public Color solid;
    public Color empty;
    public Color outline;
    public Color avoid;
    public Color head;

    void Visualize()
    {
        string lst = "";
        for (int i = 0; i < list.Count; i++)
        {
            lst += list[i];
        }
        int seed = lst.ToInt();
        System.Random rad = new System.Random(seed);

        Texture2D tex = new Texture2D(12, 12);
        tex.filterMode = FilterMode.Point;

        int[] map = new int[6 * 12]{
            0,0,0,0,0,0,
            0,0,0,0,1,1,
            0,0,0,0,1,2,
            0,0,0,1,1,2,
            0,0,0,1,1,2,
            0,0,1,1,1,2,
            0,1,1,1,3,3,
            0,1,1,1,3,3,
            0,1,1,1,3,3,
            0,1,1,1,1,2,
            0,0,0,1,1,1,
            0,0,0,0,0,0
        };
        bool cockpit = rad.Next(1, 100) > 50;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                int reference = map[i + 6 * j];
                if (reference == 1)
                {
                    bool solid = rad.Next(1, 100) > 50;
                    if (solid)
                        //empty
                        map[i + 6 * j] = 10;
                    else
                        //avoid
                        map[i + 6 * j] = 11;
                }
                else if (reference == 3)
                {
                    //empty
                    if (cockpit)
                        map[i + 6 * j] = 12;
                    //solid
                    else
                        map[i + 6 * j] = 13;
                }
            }
        }
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                AddEdge(map, i, j);
            }
        }
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                if (map[i + 6 * j] == 12)
                    tex.SetPixel(i, j, head);
                else if (map[i + 6 * j] == 11)
                {
                    tex.SetPixel(i, j, avoid);
                }
                else if (map[i + 6 * j] == 10 || map[i + 6 * j] == 0)
                    tex.SetPixel(i, j, empty);
                else if (map[i + 6 * j] == 14)
                    tex.SetPixel(i, j, outline);
                else
                    tex.SetPixel(i, j, solid);
            }
        }
        for (int i = 6; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                tex.SetPixel(i, j, tex.GetPixel(11 - i, j));
            }
        }
        tex.Apply();
        material.mainTexture = tex;
    }
    void AddEdge(int[] map, int x, int y)
    {
        if (map[x + 6 * y] == 0 || map[x + 6 * y] == 10 || map[x + 6 * y] == 12)
        {
            if (x < 5 && (map[x + 1 + y * 6] == 11 || map[x + 1 + y * 6] == 10))
                map[x + 6 * y] = 14;
            if (x > 0 && (map[x - 1 + y * 6] == 11 || map[x - 1 + y * 6] == 10))
                map[x + 6 * y] = 14;
            if (y < 11 && (map[x + (y + 1) * 6] == 11 || map[x + (y + 1) * 6] == 10))
                map[x + 6 * y] = 14;
            if (y > 0 && (map[x + (y - 1) * 6] == 11 || map[x + (y - 1) * 6] == 10))
                map[x + 6 * y] = 14;
        }
    }
    public DemoSpriteGenerator generator;
}
