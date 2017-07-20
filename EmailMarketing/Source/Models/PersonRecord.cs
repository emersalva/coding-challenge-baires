namespace EmailMarketing.Models
{
    /// <summary>
    /// Record to be processed
    /// </summary>
    public class PersonRecord
    {
        /// <summary>
        /// Person Id
        /// </summary>
        public int PersonId { get; set; }
        
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Current role
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string Industry { get; set; }
        
        /// <summary>
        /// Recomendations
        /// </summary>
        public int Recomendations { get; set; }

        /// <summary>
        /// Connections
        /// </summary>
        public int Connections { get; set; }
        

    }
}
