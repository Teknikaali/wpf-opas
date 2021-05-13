using Kettunen.BMICalculator.WPFClient.MVVM;

namespace Kettunen.BMICalculator.WPFClient
{
    public class ResultViewModel : ViewModel
    {
        private double _result;
        public double Result 
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }
    }
}
