using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    [SerializeField] private Image Belt;
    [SerializeField] private Image Boot;
    [SerializeField] private Image Glove;
    [SerializeField] private Image Ring;
    [SerializeField] private Image SoldOut;
    public static float TotalPoint = 0f;
    [SerializeField] private Text PointText;
    private Image[] items;

    void Start()
    {
        items = new Image[] { Belt, Boot, Glove, Ring };
        RandomItems();
    }

    void Update()
    {
        ShowPoint();
    }

    private void ShowPoint()
    {
        PointText.text = "P : " + TotalPoint;
    }

    public void RandomItems()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].transform.position = new Vector2(1323.68f, -187);
        }

        int[] randomInts = GetUniqueRandomNumbers(0, 3, 3);

        items[randomInts[0]].transform.position = new Vector2(1321.16f, 573);
        items[randomInts[1]].transform.position = new Vector2(1321.16f, 360);
        items[randomInts[2]].transform.position = new Vector2(1321.16f, 147);
    }

    // private void OnItemClick(Image clickedItem)
    // {
    //     clickedItem.sprite = SoldOut.sprite;
    //     for (int i = 0; i < items.Length; i++)
    //     {
    //         if (items[i] == clickedItem)
    //         {
    //             items[i] = SoldOut;
    //             break;
    //         }
    //     }
    // }

    int[] GetUniqueRandomNumbers(int min, int max, int count)
    {
        int[] numbers = new int[max - min + 1];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + min;
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            int randomIndex = Random.Range(i, numbers.Length);
            int temp = numbers[i];
            numbers[i] = numbers[randomIndex];
            numbers[randomIndex] = temp;
        }

        int[] result = new int[count];
        for (int i = 0; i < count; i++)
        {
            result[i] = numbers[i];
        }

        return result;
    }
}
