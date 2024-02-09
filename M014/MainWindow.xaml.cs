using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.IO;
using Microsoft.Win32;

namespace M014;

public partial class MainWindow : Window
{
	public int Counter { get; set; }

	public MainWindow()
	{
		InitializeComponent();

		//ItemsSource: In Komponenten mehrere Elemente anzeigen sollen, kann hier eine Liste zugewiesen werden
		CB.ItemsSource = new List<string>() { "Item1", "Item2", "Item3" };
		LB.ItemsSource = new List<string>() { "Item1", "Item2", "Item3" };
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		//Events
		//Zweigeteilte Codegestaltung
		//Entwicklerseite, Anwenderseite

		//z.B. Button Click
		//Entwicklerseite: Die Bedingungen wann ein Button als geklickt gilt (Maus im Button, keine UI Elemente darüber, wenn Button enabled, ...)
		//Anwenderseite: Anbindung des Events, hier kann der User festlegen, was beim Click passiert

		Counter++;
		TB.Text = Counter.ToString();

		//Window2 w2 = new Window2();
		////w2.Show();
		//w2.ShowDialog();

		//using Microsoft.Win32;
		OpenFileDialog dialog = new();
		dialog.Title = "Datei öffnen";
		dialog.Filter = ".txt";
		//...
		bool b = dialog.ShowDialog().Value;
		if (b) //User hat OK gedrückt
		{
			File.ReadAllText(dialog.FileName);
		}
	}

	private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		TB.Text = CB.SelectedItem.ToString();
	}

	private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		TB.Text = string.Join(", ", LB.SelectedItems.OfType<string>());
	}

	private void CheckBox_Checked(object sender, RoutedEventArgs e)
	{
		if (IsInitialized)
		{
			TB.Text = "Checkbox gecheckt";
		}
	}

	private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
	{
		TB.Text = "Checkbox unchecked";
	}

	private void MenuItem_Click(object sender, RoutedEventArgs e)
	{
		MessageBoxResult mbr = MessageBox.Show("Möchtest du beenden?", "Beenden?", MessageBoxButton.YesNo, MessageBoxImage.Question);
		if (mbr == MessageBoxResult.Yes)
			Close();
	}
}