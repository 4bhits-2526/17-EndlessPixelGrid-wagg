using UnityEngine;

public class Datamodel : MonoBehaviour
{
    public bool[,] Grid { get; private set; }
    public bool[] InputLine { get; private set; }

    public const int Rows = 10;
    public const int Columns = 7;

    private void Awake()
    {
        Grid = new bool[Rows, Columns];
        InputLine = new bool[Columns];

        ClearGrid();
        ClearInputLine();
    }

    public void ClearGrid()
    {
        for (int r = 0; r < Rows; r++)
            for (int c = 0; c < Columns; c++)
                Grid[r, c] = false;
    }

    public void ClearInputLine()
    {
        for (int i = 0; i < Columns; i++)
            InputLine[i] = false;
    }
}
