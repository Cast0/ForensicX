using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookContents : MonoBehaviour
{
    [TextArea(10, 20)]
    [SerializeField] private string content;

    [Space]
    [SerializeField] private TMP_Text leftSide;
    [SerializeField] private TMP_Text rightSide;

    [Space]
    [SerializeField] private TMP_Text leftPagination;
    [SerializeField] private TMP_Text rightPagination;

    private int currentPage = 0; // Tracks the current page
    private int charactersPerPage = 600; // Number of characters to display per page

    private void OnValidate()
    {
        UpdatePagination();

        if (leftSide.text == content)
            return;

        SetUpContent();
    }

    private void Awake()
    {
        UpdatePagination(); // Set initial page numbers

        SetUpContent();
    }

    private void SetUpContent()
    {
        int startIndex = currentPage * charactersPerPage;
        int endIndex = Mathf.Min(startIndex + charactersPerPage, content.Length);

        if (currentPage == Mathf.CeilToInt((float)content.Length / charactersPerPage) - 1)
        {
            leftSide.text = "<page=" + (currentPage * 2 + 1) + ">" + content.Substring(startIndex, endIndex - startIndex) + "</page>";
        }
        else
        {
            leftSide.text = "<page=" + (currentPage * 2 + 1) + ">" + content.Substring(startIndex, endIndex - startIndex) + "</page>";
        }

        if (endIndex < content.Length)
        {
            int remainingChars = content.Length - endIndex;
            if (remainingChars > charactersPerPage)
            {
                remainingChars = charactersPerPage;
            }

            // Instead of using `content.Substring`, we can calculate the right side content dynamically.
            int rightSideStartIndex = endIndex;
            int rightSideEndIndex = Mathf.Min(rightSideStartIndex + charactersPerPage, content.Length);

            if (rightSideStartIndex < content.Length)
            {
                rightSide.text = "<page=" + (currentPage * 2 + 2) + ">" + content.Substring(rightSideStartIndex, rightSideEndIndex - rightSideStartIndex) + "</page>";
            }
            else
            {
                rightSide.text = string.Empty;
            }
        }
        else
        {
            rightSide.text = string.Empty;
        }
    }

    private void UpdatePagination()
    {
        // Calculate the page numbers based on currentPage
        leftPagination.text = (currentPage * 2 + 1).ToString();
        rightPagination.text = (currentPage * 2 + 2).ToString();
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            SetUpContent();
            UpdatePagination();
        }
    }

    public void NextPage()
    {
        int pageCount = Mathf.CeilToInt((float)content.Length / charactersPerPage);

        if (currentPage < pageCount - 1)
        {
            currentPage++;
            SetUpContent();
            UpdatePagination();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad4)) // Numpad 4 for previous page
        {
            PreviousPage();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6)) // Numpad 6 for next page
        {
            NextPage();
        }
    }
}
