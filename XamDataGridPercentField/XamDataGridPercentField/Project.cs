using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamDataGridPercentField
{
    class Project : INotifyPropertyChanged
    {
        public Project(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }

        private double _percentComplete;
        public double PercentComplete
        {
            get { return _percentComplete; }
            set
            {
                if (_percentComplete != value)
                {
                    _percentComplete = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double _percentCost;
        public double PercentCost
        {
            get { return _percentCost; }
            set
            {
                if (_percentCost != value)
                {
                    _percentCost = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
