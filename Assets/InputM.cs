using UnityEngine;
using UnityEngine.UI;

public class InputM : MonoBehaviour
{
    [Header("Input Line")]
    public Image[] inputLineImages = new Image[7];

    [Header("Key Bindings (Index = Pixel)")]
    public KeyCode[] inputKeys = new KeyCode[7];

    [Header("Colors")]
    public Color whiteColor = Color.white;
    public Color blackColor = Color.black;

    private Datamodel model;

    void Awake()
{
    model = GetComponent<Datamodel>();

    if (model == null)
    {
        Debug.LogError("Datamodel fehlt auf diesem GameObject!");
        return;
    }

    RefreshInputLine();
}


    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        for (int i = 0; i < inputKeys.Length; i++)
        {
            if (Input.GetKeyDown(inputKeys[i]))
            {
                ToggleInputPixel(i);
            }
        }
    }

    private void ToggleInputPixel(int index)
    {
        model.InputLine[index] = !model.InputLine[index];
        RefreshInputLine();
    }

    private void RefreshInputLine()
    {
        for (int i = 0; i < model.InputLine.Length; i++)
        {
            inputLineImages[i].color =
                model.InputLine[i] ? whiteColor : blackColor;
        }
    }
}
