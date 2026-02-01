using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class InputM : MonoBehaviour
{
    [Header("Grid Panel (10x7)")]
    public Image[] gridImages;
    public Transform gridPanel;

    [Header("Input Line Panel (7)")]
    public Image[] inputLineImages = new Image[Datamodel.Columns];

    [Header("Key Bindings (Index = Spalte)")]
    public KeyCode[] inputKeys = new KeyCode[Datamodel.Columns];

    [Header("Colors")]
    public Color whiteColor = Color.white;
    public Color blackColor = Color.black;

    private Datamodel model;



    private void Awake()
    {
        gridImages = gridPanel.GetComponentsInChildren<Image>();
        //Debug.Log("Anzahl Grid Images: " + gridImages.Length);
        model = GetComponent<Datamodel>();
        if (model == null)
        {
           // Debug.LogError("Datamodel fehlt auf diesem GameObject!");
            return;
        }

        RefreshInputLine();
        RefreshGridUI();
    }

    private void Update()
    {
        HandleInput();

        
        if (Input.GetKeyDown(KeyCode.D))
        {
            model.ShiftGridAndInsertInput();
            RefreshGridUI();      
            RefreshInputLine();   
        }
    }

    private void HandleInput()
    {
        for (int i = 0; i < inputKeys.Length; i++)
        {
            if (Input.GetKeyDown(inputKeys[i]))
            {
                model.InputLine[i] = !model.InputLine[i];
                RefreshInputLine();
            }
        }
    }


    private void RefreshInputLine()
    {
        for (int c = 0; c < model.InputLine.Length; c++)
        {
            inputLineImages[c].color = model.InputLine[c] ? whiteColor : blackColor;
        }
    }

    private void RefreshGridUI()
    {
        for (int r = 0; r < Datamodel.Rows; r++)
        {
            for (int c = 0; c < Datamodel.Columns; c++)
            {
                int index = r * Datamodel.Columns + c;
                gridImages[index].color = model.Grid[r, c] ? whiteColor : blackColor;
            }
        }
    }
}
