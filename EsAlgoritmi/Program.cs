using System.Diagnostics;

var percorsoRubricaCsv = @"C:\Users\dpace\Desktop\algoritmi.csv";
var rubricaContattiOriginali = File.ReadAllLines(percorsoRubricaCsv).ToList();
var rubricaInsertionSort = File.ReadAllLines(percorsoRubricaCsv).ToList();
var rubricaSelectionSort = File.ReadAllLines(percorsoRubricaCsv).ToList();
var rubricaMergeSort = File.ReadAllLines(percorsoRubricaCsv).ToList();

Stopwatch timer = new Stopwatch();






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
mergeSort(rubricaMergeSort);
timer.Stop();
TimeSpan trascorsoMerge = timer.Elapsed;
Console.WriteLine($"Il tempo impiegato dal Merge Sort è stato di: {trascorsoMerge}");

timer.Start();
bubbleSort();
timer.Stop();
TimeSpan trascorsoBubble = timer.Elapsed;
Console.WriteLine($"Il tempo impiegato dal Bubble Sort è stato di: {trascorsoBubble}");

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

File.WriteAllLines(fileNuovo, rubricaContattiOriginali);

Console.WriteLine("Lista ordinata salvata in un file");

void bubbleSort()
{


    for (int i = 0; i < rubricaContattiOriginali.Count; i++)
    {
        for (int j = 0; j < rubricaContattiOriginali.Count - i - 1; j++)
        {
            var nomi = rubricaContattiOriginali[j].Split(',');
            var nomiDue = rubricaContattiOriginali[j + 1].Split(',');


            var comparazione = string.Compare(nomi[0], nomiDue[0]);

            if (comparazione == 0)
            {
                comparazione = string.Compare(nomi[1], nomiDue[1]);
            }

            if (comparazione > 0)
            {
                var contattoTemporaneo = rubricaContattiOriginali[j];
                rubricaContattiOriginali[j] = rubricaContattiOriginali[j + 1];
                rubricaContattiOriginali[j + 1] = contattoTemporaneo;
            }


        }
    }
}

void selectionSort()
{
    for (int i = 0; i < rubricaSelectionSort.Count - 1; i++)
    {
        int minIndex = i;

        for (int j = i + 1; j < rubricaSelectionSort.Count; j++)
        {
            var contattoMin = rubricaSelectionSort[minIndex].Split(',');
            var contattoCorrente = rubricaSelectionSort[j].Split(',');

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
            var appoggio = rubricaSelectionSort[i];
            rubricaSelectionSort[i] = rubricaSelectionSort[minIndex];
            rubricaSelectionSort[minIndex] = appoggio;
        }
    }
}

void insertionSort()
{
    for (int i = 1; i < rubricaInsertionSort.Count; i++)
    {
        var indiceMigliorTempo = rubricaInsertionSort[i];
        int j = i - 1;


        while (j >= 0 && string.Compare(rubricaInsertionSort[j], indiceMigliorTempo) > 0)
        {
            rubricaInsertionSort[j + 1] = rubricaInsertionSort[j];
            j--;
        }

        rubricaInsertionSort[j + 1] = indiceMigliorTempo;
    }
}

void mergeSort(List<string> rubricaMergeSort)
{
    if (rubricaMergeSort.Count <= 1)
    {
        return; 
    }

    int metà = rubricaMergeSort.Count / 2;

    
    List<string> sinistra = rubricaMergeSort.GetRange(0, metà);  
    List<string> destra = rubricaMergeSort.GetRange(metà, rubricaMergeSort.Count - metà);  

    
    mergeSort(sinistra);
    mergeSort(destra);

    
    List<string> listaOrdinata = merge(sinistra, destra);

    
    for (int i = 0; i < rubricaMergeSort.Count; i++)
    {
        rubricaMergeSort[i] = listaOrdinata[i];
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


















