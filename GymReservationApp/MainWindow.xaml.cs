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
using System.Linq;
using System.Collections.Generic;

namespace GymReservationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string filePath = "foglalasok.txt";
        Gym gym = new Gym();
        public MainWindow()
        {
            InitializeComponent();

            for ( int i = 8; i <= 20; i++)
            {
                TimeBox.Items.Add(i);
            }
            TimeBox.SelectedIndex = 0;
            LoadReservations();
            RefreshReservationsList();
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text;

            if(string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Adja meg a nevet");
                return;
            }

            int time = (int)TimeBox.SelectedItem;

            GymReservation reservation;

            if(TypeBox.SelectedIndex == 0)
            {
                reservation = new SingleReservation(name, time);
            }
            else
            {
                reservation = new TeamReservation(name, new List<string>(), time);
            }

            if(gym.addReservation(reservation))
            {
                NameBox.Clear();
                SaveReservation(reservation);
                RefreshReservationsList();
            }
            else
            {
                MessageBox.Show("Erre az idopontra mar van foglalas");
            }
        }

        private void SaveReservation(GymReservation reservation)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                if (reservation is TeamReservation team)
                {
                    string members = string.Join(",", team.TeamMembers);
                    writer.WriteLine($"TEAM;{team.ContactName};{team.ReservationTime};{members}");
                }
                else if (reservation is SingleReservation single)
                {
                    writer.WriteLine($"SINGLE;{single.ContactName};{single.ReservationTime};{single.HasSeasonTicket}");
                }
            }
        }

        private void LoadReservations()
        {

            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] data = line.Split(';');

                string type = data[0];
                string name = data[1];
                int time = int.Parse(data[2]);

                if (type == "TEAM")
                {
                    List<string> members = data[3].Split(',').ToList();
                    gym.addReservation(new TeamReservation(name, members, time));
                }
                else if (type == "SINGLE")
                {
                    SingleReservation single = new SingleReservation(name, time);

                    if (bool.TryParse(data[3], out bool hasTicket) && hasTicket)
                    {
                        single.buySeasonTicket();
                    }

                    gym.addReservation(single);
                }
            }
        }

        private void RefreshReservationsList()
        {
            ReservationsList.Items.Clear();

            foreach (var reservation in gym.Reservations)
            {
                string type = reservation is TeamReservation ? "Csoportos" : "Egyéni";

                ReservationsList.Items.Add(
                    $"{reservation.GetReservationTime()}:00 - " +
                    $"{reservation.GetContactName()} - {type} - " +
                    $"{reservation.CalculatePriceToPay()} Ft");
            }
        }
    }
}
