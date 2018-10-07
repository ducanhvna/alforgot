using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace XamDataGridPercentField
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly ICollection<Project> _projects = new List<Project>()
        {
            new Project("Dig foundations"),
            new Project("Fill foundations"),
            new Project("Build foundations"),
            new Project("Build first floor"),
            new Project("Build second floor"),
            new Project("Build roof"),
            new Project("Install electrics"),
            new Project("Install plumbing"),
            new Project("Plaster walls"),
            new Project("Decorate")
        };

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _projects;
        }

        public void Animate()
        {
            foreach (var project in _projects)
            {
                project.PercentComplete = 0D;
                project.PercentCost = 0D;
            }

            var rand = new Random();
            foreach (var project in _projects)
            {
                foreach (var perc in Enumerable.Range(0, rand.Next(100)))
                {
                    project.PercentComplete = perc * 0.01D;
                    Thread.Sleep(TimeSpan.FromMilliseconds(1));
                }

                foreach (var perc in Enumerable.Range(0, rand.Next(50)))
                {
                    project.PercentCost = perc * 0.01D;
                }
            }
        }

        private void TrackProjects(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(Animate);
        }
    }
}
