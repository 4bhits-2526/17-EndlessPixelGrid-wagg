using UnityEngine;

public class Datamodel : MonoBehaviour
{
    public bool[,] Grid { get; private set; }       // 10x7 Grid
    public bool[] InputLine { get; private set; }   // 7 Spalten InputLine

    public const int Rows = 10;
    public const int Columns = 7;

    private void Awake()
    {
        Grid = new bool[Rows, Columns];
        InputLine = new bool[Columns];
    }


    public void ShiftGridAndInsertInput()
    {

        for (int r = 0; r < Rows - 1; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                Grid[r, c] = Grid[r + 1, c];
            }
        }

        for (int c = 0; c < Columns; c++)
        {
            Grid[Rows - 1, c] = InputLine[c];
        }

        for (int c = 0; c < Columns; c++)
        {
            InputLine[c] = false;
        }

        Debug.Log("Shift durchgeführt. Unterste Zeile nach Einfügen: " + Grid[Rows - 1, 0]);
    }
}
