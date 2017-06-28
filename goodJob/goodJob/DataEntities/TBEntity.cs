using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goodJob.DataEntities
{
    public class TBEntity
    {

        public string Title { get; set; }
        public string Info { get; set; }
        public string Level { get; set; }
        public string Creator { get; set; }
        public string Executor { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public bool Completed { get; set; }
        public string Tags { get; set; }
        public bool IsDelay { get; set; }
        public int DelayDays { get; set; }

    }
}
