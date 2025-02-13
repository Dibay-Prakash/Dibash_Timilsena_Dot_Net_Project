namespace FitnessTracker.Models
{
    public class Track
    {
        public int Id { get; set; }  // Primary Key
        public string UserName { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public Track() { }

        public Track(string userName, string status)
        {
            UserName = userName;
            Status = status;
            Description = GetDescription(status); // Automatically set description
        }

        private string GetDescription(string status)
        {
            return status.ToLower() switch
            {
                "overweight" => "Focus on nutrient-dense, lower-calorie foods with adequate protein intake.",
                "normal weight" => "Balanced diet with appropriate macronutrient distribution.",
                "underweight" => "Focus on higher protein and calories to promote healthy weight gain.",
                _ => "Status not recognized. Please provide a valid weight status."
            };
        }
    }
}
