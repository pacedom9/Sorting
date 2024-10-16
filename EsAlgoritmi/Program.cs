
var percorsoFile = @"C:\Users\dpace\Desktop\Algoritmi.csv";
var listaContatti = File.ReadAllLines(percorsoFile).ToList();

selectionSort();

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
stampaContatti();

void stampaContatti()
{
    foreach (var linee in listaContatti)
    {
        Console.WriteLine(linee);
    }
}