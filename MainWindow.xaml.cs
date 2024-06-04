using LadybugGame.Contracts;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LadybugGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAnimalWorld _insectWorld;
        Random random = new Random();

        
        public MainWindow()
        {
            InitializeComponent();

            _insectWorld = new AnimalWorld(gameCanvas);
            for (int i = 0; i < 100; i++)
            {
                _insectWorld.AddAnimal(new Aphid(6, Colors.GreenYellow));
            }
            for (int i = 0; i < 10; i++)
            {
                _insectWorld.AddAnimal(new LadyBug(16, Colors.Red));
            }
            foreach (IAnimal animal in _insectWorld.AllAnimals)
            {
                int randX = random.Next(0, 16);
                animal.Position.X = randX;
                int randY = random.Next(0, 16);
                animal.Position.Y = randY;
                animal.DisplayOn(gameCanvas);


            }
            DisplayStatistics();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _insectWorld.ProcessRound();
            
            DisplayStatistics();
            
        }

        private void DisplayStatistics()
        {
            Ladybugs.Content = _insectWorld.AllAnimals.Where(a => a is LadyBug).ToList().Count();
            Aphids.Content = _insectWorld.AllAnimals.Where(a => a is Aphid).ToList().Count();
            round.Content = _insectWorld.CurrentRoundNumber;
        }
    }
}