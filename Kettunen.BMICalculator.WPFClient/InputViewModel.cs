using Kettunen.BMICalculator.WPFClient.MVVM;

namespace Kettunen.BMICalculator.WPFClient
{
    public class InputViewModel : ViewModel
    {
        private Gender _gender;
        public Gender Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }

        private double _weight;
        public double Weight
        {
            get => _weight;
            set => SetProperty(ref _weight, value);
        }

        private double _height;
        public double Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }
    }
}
