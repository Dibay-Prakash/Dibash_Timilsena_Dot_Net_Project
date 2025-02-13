namespace FitnessTracker.Models
{
    public class Fitness
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public double Weight { get; set; } = 0; // default value set to 0
        public double Height { get; set; } = 0; // default value set to 0

        // Computed property for BMI with validation
        public double Bmi
        {
            get
            {
                if (Weight <= 0 || Height <= 0)
                {
                    return 0; // Return 0 if the values are not valid
                }
                return Weight / (Height * Height);
            }
        }
    }
}
