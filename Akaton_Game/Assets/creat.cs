using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosswordPuzzle : MonoBehaviour
{
    public string[] words;
    public string[] clues;

    public Text clueText;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        int gridSize = 10; // Adjust the size of the grid as needed
        float buttonSize = 50f;
        float spacing = 5f;

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Button button = CreateButton(i, j, buttonSize);
                button.onClick.AddListener(() => OnButtonClick(i, j));
            }
        }
    }

    Button CreateButton(int row, int col, float size)
    {
        GameObject buttonObject = new GameObject("Button");
        buttonObject.transform.SetParent(transform);
        RectTransform rectTransform = buttonObject.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(size, size);
        rectTransform.anchoredPosition = new Vector2(col * size, -row * size);

        Button button = buttonObject.AddComponent<Button>();
        button.targetGraphic = button.GetComponent<Image>();

        return button;
    }

    void OnButtonClick(int row, int col)
    {
        // Handle button click, e.g., display the clue for the corresponding word
        int index = GetWordIndex(row, col);
        if (index != -1)
        {
            string clue = clues[index];
            clueText.text = "Clue: " + clue;
        }
    }

    int GetWordIndex(int row, int col)
    {
        for (int i = 0; i < words.Length; i++)
        {
            if (row < words[i].Length && col < words[i].Length)
            {
                return i;
            }
        }
        return -1;
    }
}
