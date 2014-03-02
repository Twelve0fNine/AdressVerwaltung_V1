using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AdressVerwaltung_V1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsNeu = true;
        private bool IsBearbeiten = false;
        private int Anzahl = 0;
        private int Position = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            AdressenLaden();
            Inaktiv();
            //DummyErzeugen();
            SetReadOnly(true);
            LBUpdate();
            listBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (IsNeu == true)
            {
                SetEmpty();
                SetReadOnly(false);
                button1.Content = "_Sichern";
                IsNeu = false;
                button2.IsEnabled = false;
                listBox1.IsEnabled = false;
                button3.IsEnabled = false;
                button4.IsEnabled = false;
                button5.IsEnabled = false;
            }
            else
            {
                Eingabe2Adresse();
                SetReadOnly(true);
                button1.Content = "_Neu";
                IsNeu = true;
                LBUpdate();
                button2.IsEnabled = true;
                listBox1.IsEnabled = true;
                button3.IsEnabled = true;
                button4.IsEnabled = true;
                button5.IsEnabled = true;
            }
        }

        private void SetReadOnly(bool bWert)
        {
            tb1.IsReadOnly = bWert;
            tb2.IsReadOnly = bWert;
            tb3.IsReadOnly = bWert;
            tb4.IsReadOnly = bWert;
            tb5.IsReadOnly = bWert;
            tb6.IsReadOnly = bWert;
            tb7.IsReadOnly = bWert;
            tb8.IsReadOnly = bWert;
        }

        private void SetEmpty()
        {
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";
            tb7.Text = "";
            tb8.Text = "";
        }

        private void Eingabe2Adresse()
        {
            Adresse a1 = new Adresse(tb1.Text, tb2.Text, tb3.Text, tb4.Text, tb5.Text, tb6.Text, tb7.Text, tb8.Text);
        }

        private void LBUpdate()
        {
            listBox1.Items.Clear();
            Anzahl = 0;
            statusBar1.Items.RemoveAt(1);
            foreach  (Adresse item in Adresse.LAdresse)
            {
                listBox1.Items.Add(item);
                Anzahl++;
            }
            //statusBar1.Items.Add(Anzahl);
            statusBar1.Items.Insert(1, Anzahl);
        }

        private void DummyErzeugen()
        {

            Adresse a1 = new Adresse("Vader", "Hans", "Am Toedestern", "2", "12345", "Endor", "hans.vader@imperium.uni", "1234567890");
            Adresse a2 = new Adresse("Vader", "Hans", "Am Toedestern", "2", "12345", "Endor", "hans.vader@imperium.uni", "1234567890");
            Adresse a3 = new Adresse("Vader", "Hans", "Am Toedestern", "2", "12345", "Endor", "hans.vader@imperium.uni", "1234567890");
            Adresse a4 = new Adresse("Vader", "Hans", "Am Toedestern", "2", "12345", "Endor", "hans.vader@imperium.uni", "1234567890");

        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                tb1.Text = Adresse.LAdresse[listBox1.SelectedIndex].StrNachname;
                tb2.Text = Adresse.LAdresse[listBox1.SelectedIndex].StrVorname;
                tb3.Text = Adresse.LAdresse[listBox1.SelectedIndex].StrStrasse;
                tb4.Text = Adresse.LAdresse[listBox1.SelectedIndex].StrHausnummer;
                tb5.Text = Adresse.LAdresse[listBox1.SelectedIndex].StrPostleitzahl;
                tb6.Text = Adresse.LAdresse[listBox1.SelectedIndex].StrOrt;
                tb7.Text = Adresse.LAdresse[listBox1.SelectedIndex].EMail;
                tb8.Text = Adresse.LAdresse[listBox1.SelectedIndex].ICQ;

                statusBar1.Items.RemoveAt(3);
                Position = (listBox1.SelectedIndex+1);
                statusBar1.Items.Insert(3, Position);
            }
            button2.IsEnabled = true;
            button5.IsEnabled = true;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (IsBearbeiten == false)
            {
                SetReadOnly(false);
                button2.Content = "_Übernehmen";
                IsBearbeiten = true;
                button1.IsEnabled = false;
                listBox1.IsEnabled = false;
                button3.IsEnabled = false;
                button4.IsEnabled = false;

            }
            else
            {
                SetReadOnly(true);
                button2.Content = "_Bearbeiten";
                IsBearbeiten = false;
                button1.IsEnabled = true;
                listBox1.IsEnabled = true;
                button3.IsEnabled = true;
                button4.IsEnabled = true;

                Adresse.LAdresse[listBox1.SelectedIndex].StrNachname = tb1.Text;
                Adresse.LAdresse[listBox1.SelectedIndex].StrVorname = tb2.Text;
                Adresse.LAdresse[listBox1.SelectedIndex].StrStrasse = tb3.Text;
                Adresse.LAdresse[listBox1.SelectedIndex].StrHausnummer = tb4.Text;
                Adresse.LAdresse[listBox1.SelectedIndex].StrPostleitzahl = tb5.Text;
                Adresse.LAdresse[listBox1.SelectedIndex].StrOrt = tb6.Text;
                Adresse.LAdresse[listBox1.SelectedIndex].EMail = tb7.Text;
                Adresse.LAdresse[listBox1.SelectedIndex].ICQ = tb8.Text;

                LBUpdate();
            }
        }

        private void Inaktiv()
        {
            if (Adresse.LAdresse.Count < 1)
            {
                button2.IsEnabled = false;
                button5.IsEnabled = false;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.Items.Count > 0 && listBox1.SelectedIndex < (listBox1.Items.Count-1))
            {
                listBox1.SelectedIndex++;
            }
            else if (listBox1.Items.Count > 0 && listBox1.SelectedIndex == (listBox1.Items.Count-1))
            {
                listBox1.SelectedIndex = 0;
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.Items.Count > 0 && listBox1.SelectedIndex > 0)
            {
                listBox1.SelectedIndex--;
            }
            else if (listBox1.Items.Count > 0 && listBox1.SelectedIndex == 0)
            {
                listBox1.SelectedIndex = (listBox1.Items.Count -1);
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Adresse.LAdresse.RemoveAt(listBox1.SelectedIndex);
                LBUpdate();
                listBox1.SelectedIndex = 0;
            }
        }

        private void AdressenSpeichern(List<Adresse> la)
        {
            try
            {
                FileStream fstream = new FileStream(@"Adressen.obj", FileMode.Create);
                BinaryFormatter formater = new BinaryFormatter();
                foreach (Adresse item in Adresse.LAdresse)
                {
                    formater.Serialize(fstream, item);
                }
                fstream.Close();
            }
            catch (Exception){}
        }

        private void AdressenLaden()
        {
            try
            {
                FileStream fstream = new FileStream(@"Adressen.obj", FileMode.Open);
                BinaryFormatter formater = new BinaryFormatter();
                while (fstream.Length > fstream.Position)
                {
                    Adresse.LAdresse.Add((Adresse)formater.Deserialize(fstream));
                }
                fstream.Close();
            }
            catch (Exception){}
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AdressenSpeichern(Adresse.LAdresse);
        }

        
        
    }
}
