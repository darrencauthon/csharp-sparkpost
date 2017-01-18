using System;

namespace SparkPost
{
    public class Suppression
    {
        public bool Transactional { get; set; }
        public bool NonTransactional { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}