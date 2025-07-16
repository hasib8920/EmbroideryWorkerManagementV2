using EmbroideryWorkerManagement.Models;
using System.Collections.Generic;

namespace EmbroideryWorkerManagement.ViewModels
{
    public class ReportFilterViewModel
    {
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int? WorkerId { get; set; }
        public List<Worker> Workers { get; set; }
    }
}
