using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AlphabetLogic
{
    public string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
    public string FindLetter = "", PreviousLetters = "*";
    public int CurretLevelDifficulty;
    public int[] LevelDifficulty;
    public string[] arrLetter;

    public AlphabetLogic()
    {
        const int Easy = 3, Medium = 6, Hard = 9;
        EditDifficultyCountCell(Easy, Medium, Hard);
    }

    public AlphabetLogic(int ValueDifficultyEasy, int ValuedifficultyMedium, int ValuedifficultyHard)
    {
        EditDifficultyCountCell(ValueDifficultyEasy, ValuedifficultyMedium, ValuedifficultyHard);
    }

    public void EditDifficultyCountCell(int EasyDifficulty, int MediumDifficulty, int HardDifficulty)
    {
        arrLetter = new string[HardDifficulty+1];
        LevelDifficulty = new int[4];
        LevelDifficulty[0] = EasyDifficulty;
        LevelDifficulty[1] = MediumDifficulty;
        LevelDifficulty[2] = HardDifficulty;
    }

    public void FillArray()
    {
        Random rnd = new Random();

        for (int i = 0; i < LevelDifficulty[2]; i++)
        {
            arrLetter[i] = Char.ToString(Alphabet[rnd.Next(0, Alphabet.Count())]);
            for (int j = 0; j < i; j++)
            {
                if (arrLetter[j] == arrLetter[i])
                {
                    arrLetter[i] = Char.ToString(Alphabet[rnd.Next(0, Alphabet.Count())]);
                    j = 0;
                }
            }
        }
        FindLetter = arrLetter[0];
    }

    public void GetRandomLetter(int LevelDifficulty)
    {
        Random rnd = new Random();
        FindLetter = arrLetter[rnd.Next(0, LevelDifficulty)];
        for (int i = 0; i < PreviousLetters.Count(); i++)
        {
            if (Char.ToString(PreviousLetters[i]) == FindLetter)
            {
                FindLetter = arrLetter[rnd.Next(0, LevelDifficulty)];
                i = 0;

            }
        }
        PreviousLetters += FindLetter;
    }
}
