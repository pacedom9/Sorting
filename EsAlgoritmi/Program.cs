﻿using System.Diagnostics;

var percorsoFile = @"C:\Users\dpace\Desktop\algoritmi.csv";
var listaContatti = File.ReadAllLines(percorsoFile).ToList();
Stopwatch timer = new Stopwatch();


timer.Start();
bubbleSort();
timer.Stop();
TimeSpan trascorsoBubble = timer.Elapsed;
Console.WriteLine($"Il tempo impiegato dal Bubble Sort è stato di: {trascorsoBubble}");

timer.Restart();
selectionSort();
timer.Stop();
TimeSpan trascorsoSelection = timer.Elapsed;
Console.WriteLine($"Il tempo impiegato dal Selection Sort è stato di: {trascorsoSelection}");

timer.Restart();
insertionSort();
timer.Stop();
TimeSpan trascorsoInsertion = timer.Elapsed;
Console.WriteLine($"Il tempo impiegato dall'Insertion Sort è stato di: {trascorsoInsertion}");

timer.Restart();
mergeSort(listaContatti);
timer.Stop();
TimeSpan trascorsoMerge = timer.Elapsed;
Console.WriteLine($"Il tempo impiegato dal Merge Sort è stato di: {trascorsoMerge}");

TimeSpan[] tempi = { trascorsoBubble, trascorsoSelection, trascorsoInsertion, trascorsoMerge };
string[] nomiMetodi = { "il Bubble Sort", "il Selection Sort", "l'Insertion Sort", "il Merge Sort" };
var appoggio = 0;
for (int i = 1; i < tempi.Length; i++)
{
    if (tempi[i] < tempi[appoggio])
    {
        appoggio = i;
    }
}


Console.WriteLine($"L'algoritmo più performante è {nomiMetodi[appoggio]}, con un tempo di: {tempi[appoggio]}");
string fileNuovo = @"C:\Users\dpace\Desktop\rubricaOrdinata.csv";

File.WriteAllLines(fileNuovo, listaContatti);

Console.WriteLine("Lista ordinata salvata in un file");

void bubbleSort()
{


    for (int i = 0; i < listaContatti.Count; i++)
    {
        for (int j = 0; j < listaContatti.Count - i - 1; j++)
        {
            var nomi = listaContatti[j].Split(',');
            var nomiDue = listaContatti[j + 1].Split(',');


            var comparazione = string.Compare(nomi[0], nomiDue[0]);

            if (comparazione == 0)
            {
                comparazione = string.Compare(nomi[1], nomiDue[1]);
            }

            if (comparazione > 0)
            {
                var appoggio = listaContatti[j];
                listaContatti[j] = listaContatti[j + 1];
                listaContatti[j + 1] = appoggio;
            }


        }
    }
}

void selectionSort()
{
    for (int i = 0; i < listaContatti.Count - 1; i++)
    {
        int minIndex = i;

        for (int j = i + 1; j < listaContatti.Count; j++)
        {
            var contattoMin = listaContatti[minIndex].Split(',');
            var contattoCorrente = listaContatti[j].Split(',');

            var comparazione = string.Compare(contattoCorrente[0], contattoMin[0]);

            if (comparazione == 0)
            {
                comparazione = string.Compare(contattoCorrente[1], contattoMin[1]);
            }

            if (comparazione < 0)
            {
                minIndex = j;
            }
        }


        if (minIndex != i)
        {
            var appoggio = listaContatti[i];
            listaContatti[i] = listaContatti[minIndex];
            listaContatti[minIndex] = appoggio;
        }
    }
}

void insertionSort()
{
    for (int i = 1; i < listaContatti.Count; i++)
    {
        var appoggio = listaContatti[i];
        int j = i - 1;


        while (j >= 0 && string.Compare(listaContatti[j], appoggio) > 0)
        {
            listaContatti[j + 1] = listaContatti[j];
            j--;
        }

        listaContatti[j + 1] = appoggio;
    }
}

void mergeSort(List<string> listaContatti)
{
    if (listaContatti.Count <= 1)
    {
        return; 
    }

    int metà = listaContatti.Count / 2;

    
    List<string> sinistra = listaContatti.GetRange(0, metà);  
    List<string> destra = listaContatti.GetRange(metà, listaContatti.Count - metà);  

    
    mergeSort(sinistra);
    mergeSort(destra);

    
    List<string> listaOrdinata = merge(sinistra, destra);

    
    for (int i = 0; i < listaContatti.Count; i++)
    {
        listaContatti[i] = listaOrdinata[i];
    }
}

List<string> merge(List<string> sinistra, List<string> destra)
{
    List<string> risultato = new List<string>();
    int i = 0, j = 0;

    
    while (i < sinistra.Count && j < destra.Count)
    {
        if (string.Compare(sinistra[i], destra[j]) <= 0)
        {
            risultato.Add(sinistra[i]);
            i++;
        }
        else
        {
            risultato.Add(destra[j]);
            j++;
        }
    }

    
    while (i < sinistra.Count)
    {
        risultato.Add(sinistra[i]);
        i++;
    }

    
    while (j < destra.Count)
    {
        risultato.Add(destra[j]);
        j++;
    }

    return risultato;  

}


















