using System;
using System.Linq;
using System.Collections.Generic;

Console.WriteLine("Masukkan kata atau kalimat:");
string userInput = Console.ReadLine();
string output = HitungHuruf(userInput);

Console.WriteLine(output);

static string HitungHuruf(string text)
{
    text = text.ToLower();
    Dictionary<char, int> jumlahHuruf = [];
    foreach (char karakter in text)
    {
        if (char.IsLetter(karakter))
        {
            if (jumlahHuruf.TryGetValue(karakter, out int value))
            {
                jumlahHuruf[karakter] = ++value;
            }
            else
            {
                jumlahHuruf[karakter] = 1;
            }
        }
    }

    string hasil = string.Join(", ", jumlahHuruf.Select(kvp => $"{kvp.Key}={kvp.Value}"));

    return hasil;
}