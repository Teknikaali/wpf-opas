using System;

namespace Kettunen.BMICalculator.WPFClient
{
    /// <summary>
    /// Provides a method to calculate a body mass index (BMI) value for a person.
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Calculates body mass index (BMI) derived from mass (weight) and height of a person.
        /// </summary>
        /// <param name="weight">Weight in kilograms</param>
        /// <param name="height">Height in meters</param>
        /// <returns>Body mass index value in units of kg/m²</returns>
        double Calculate(double weight, double height);
    }

    public class MaleCalculator : ICalculator
    {
        public double Calculate(double weight, double height) => weight / Math.Pow(height, 2);
    }

    public class FemaleCalculator : ICalculator
    {
        public double Calculate(double weight, double height) => 1.3 * weight / Math.Pow(height, 2.5);
    }
}
