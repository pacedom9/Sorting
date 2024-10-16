



var percorsoFile = @"C:\Users\dpace\Desktop\Algoritmi.csv"; //Definizione percorso file
var listaContatti = File.ReadAllLines(percorsoFile).ToList(); //Leggere il file e convertirlo in lista

selectionSort();

void bubbleSort()
{
    

    for (int i = 0; i < listaContatti.Count; i++)
    {
        for (int j = 0; j < listaContatti.Count - i - 1; j++)
        {
            var nomi = listaContatti[j].Split(','); //Abbiamo diviso i contatti con la virgola
            var nomiDue = listaContatti[j + 1].Split(',');

            int comparazione = string.Compare(nomi[0], nomiDue[0]);

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



    stampaContatti();
}

void stampaContatti()
{
    foreach (var linee in listaContatti)
    {
        Console.WriteLine(linee);
    }
}