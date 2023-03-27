using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using UnityEngine.UI;
using TMPro;

public class MainScript : MonoBehaviour
{
    [SerializeField] int xCount = 16;
    [SerializeField] int yCount = 10;
    [SerializeField] int bombCount = 8;
    [SerializeField] GameObject field;
    List<Transform> bombs = new List<Transform>();
    int[,] values;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(xCount / 2 - 0.5f, -6, yCount / 2 - 0.5f);
        transform.localScale = new Vector3(xCount * 0.2f, 0.1f, yCount * 0.2f);
        values = new int[xCount, yCount];
        for (int i = 0; i < xCount; i++)
        {
            for (int j = 0; j < yCount; j++)
            {
                values[i, j] = 0;
            }
        }
        
        int k = bombCount;
        while (k > 0)
        {
            int i = Random.Range(0, xCount);
            int j = Random.Range(0, yCount);

            if (values[i, j] >= 0)
            {
                values[i, j] = -10;

                if (i > 0) values[i - 1, j]++;
                if (j > 0) values[i, j - 1]++;
                if (i < xCount - 1) values[i + 1, j]++;
                if (j < yCount - 1) values[i, j + 1]++;
                if ((i > 0) && (j > 0))values[i - 1, j - 1]++;
                if ((i > 0) && (j < yCount - 1)) values[i - 1, j + 1]++;
                if ((i < xCount - 1) && (j > 0)) values[i + 1, j - 1]++;
                if ((i < xCount - 1) && (j < yCount - 1)) values[i + 1, j + 1]++;
                k--;
            }
        }

        for (int i = 0; i < xCount; i++)
        {
            for (int j = 0; j < yCount; j++)
            {
                GameObject gb = Instantiate(field, new Vector3(i, 1f, j), Quaternion.identity);
                GameObject child = gb.transform.GetChild(0).gameObject;
                TextMeshPro textX = child.GetComponent<TextMeshPro>();
                textX.gameObject.SetActive(false);
                 if (values[i,j] == 0)
                 {
                     textX.text = "+";
                 }
                 if (values[i,j] < 0)
                 {
                     textX.text = "*";
                    gb.tag = "Bomb";
                    bombs.Add(gb.transform);
                 }
                 if (values[i,j] > 0)
                 {
                     textX.text = values[i,j].ToString();
                 }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
