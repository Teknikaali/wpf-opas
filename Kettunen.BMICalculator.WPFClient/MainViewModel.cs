using System.Windows.Input;
using Kettunen.BMICalculator.WPFClient.MVVM;

namespace Kettunen.BMICalculator.WPFClient
{
    public class MainViewModel : ViewModel
    {
        private readonly Calculator _calculator;
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

            _calculator = new Calculator();
            _resultViewModel = new ResultViewModel();
            _inputViewModel = new InputViewModel();

            CurrentViewModel = _inputViewModel;

            Navigate = new DelegateCommand(x =>
            {
                if (x is InputViewModel calculatorViewModel)
                {
                    _resultViewModel.Result = _calculator.Calculate(calculatorViewModel.Weight, calculatorViewModel.Height / 100);
                    CurrentViewModel = _resultViewModel;
                }
                else
                {
                    CurrentViewModel = _inputViewModel;
                }
            },
            x =>
            {
                if (x is InputViewModel calculatorViewModel)
                {
                    return calculatorViewModel.Height > 0 && calculatorViewModel.Weight > 0;
                }
                else
                {
                    return true;
                }
            });
        }
    }
}
