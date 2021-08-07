using System.Collections.Generic;
using System.Windows.Input;
using Kettunen.BMICalculator.WPFClient.MVVM;

namespace Kettunen.BMICalculator.WPFClient
{
    public class MainViewModel : ViewModel
    {
        private readonly IDictionary<Gender, ICalculator> _calculators;
        private readonly InputViewModel _inputViewModel;
        private readonly ResultViewModel _resultViewModel;

        private ViewModel _currentViewModel;
        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                if (SetProperty(ref _currentViewModel, value))
                {
                    OnPropertyChanged(nameof(NavigateText));
                }
            }
        }

        public ICommand Navigate { get; }

        public string NavigateText => CurrentViewModel is InputViewModel
            ? "CALCULATE"
            : "BACK";

        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                CurrentViewModel = new InputViewModel();
                return;
            }

            _calculators = new Dictionary<Gender, ICalculator>
            {
                { Gender.Female, new FemaleCalculator() },
                { Gender.Male, new MaleCalculator() }
            };
            _resultViewModel = new ResultViewModel();
            _inputViewModel = new InputViewModel();

            CurrentViewModel = _inputViewModel;

            Navigate = new DelegateCommand(x =>
            {
                if (x is InputViewModel input)
                {
                    _resultViewModel.Result = _calculators[input.Gender].Calculate(input.Weight, input.Height / 100);
                    CurrentViewModel = _resultViewModel;
                }
                else
                {
                    CurrentViewModel = _inputViewModel;
                }
            },
            x =>
            {
                if (x is InputViewModel input)
                {
                    return input.Height > 0 && input.Weight > 0;
                }
                else
                {
                    return true;
                }
            });
        }
    }
}
