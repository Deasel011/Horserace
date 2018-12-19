namespace HorseRace14.Models
{
    /// <summary>
    /// Horse
    /// </summary>
    public class Horse
    {
        /// <summary>
        /// Horse id
        /// </summary>
        public int HorseId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Start time in milliseconds
        /// </summary>
        public int StartTimeInMillis { get; set; }

        /// <summary>
        /// End time in milliseconds
        /// </summary>
        public int EndTimeInMillis { get; set; }

        /// <summary>
        /// Total time in milliseconds
        /// </summary>
        public int TotalTimeInMillis { get; set; }

        /// <summary>
        /// Current position
        /// </summary>
        public Position Position { get; set; }
    }
}
