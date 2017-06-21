using System;
using System.Collections.Generic;

namespace SurveyApp.Models
{
    public class Survey
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Question { get; set; }
        public IEnumerable<string> Options { get; set; }
        public bool IsAnswered { get; set; }
        public string Answer { get; set; }



        public Survey()
        {
        }
    }
}
