# ShortestRouteFinder

## Uppgift 3

**Mål**: 

Applikationen ska läsa in en lista över rutter från en JSON-fil, där varje rutt har en startpunkt, destination och avstånd. 
Den ska sortera listan efter avstånd (kortaste rutt först alt längsta först) med minst två olika sorteringsalgoritmer (t ex Bubble Sort och Quick Sort). 
Användaren ska kunna välja sorterings algoritm.

Resultatet visas sedan i GUI.

**Förbättringar (Nice to have)**:

Utvärdering: Utöka input data och visa beräkningstiden för varje vald algoritm.


**Komponenter**:

- **Model**: 

  Representerar en rutt och hanterar datan från JSON-filen.
  
- **ViewModel**: 

  Innehåller logiken för att sortera listan och uppdatera vyn.
  
- **View**: 

  WPF-gränssnittet som visar rutter i en lista och låter användaren välja en sorteringsmetod.


## Uppgift 3
15:41 2024-11-15
Godkänd. Klarat sorterings algoritmen.

## Anmärkningar

1. Följer inte MVVM
	View är enbart för användargränsnnitet. Ingen logik under View

	private void SortButton_Click(object sender, RoutedEventArgs e)
	{
		// Setting algorithm based on ComboBox
		viewModel.SelectedAlgorithm = ((ComboBoxItem)AlgorithmSelector.SelectedItem).Content.ToString();
		viewModel.SortRoutes();
		RoutesList.ItemsSource = viewModel.Routes;  // Refresh the ListView
	}

	Detta kan utföras utanför view.

2. Bra med felhantering under laddning av filen.

3. Saknar felhantering när man väljer "Sort Routes" utan att först ha valt sorterings algoritm.
   alternativ, knappen kan inaktiveras när ingen algoritm har valts i ComboBox:en.
   
4. Hårdkodad sökväg till routes.json filen.
   Gör det konfigurerbar. Förslag finns under tidigare labbar.


