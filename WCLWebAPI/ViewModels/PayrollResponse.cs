using System.Net;
using System.Numerics;
using WCLWebAPI.Server.Enums;

namespace WCLWebAPI.Server.ViewModels
{
    public class PayrollResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CCCD { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public bool IsManager { get; set; }
        public string? DepartmentName { get; set; }
        public decimal Salary { get; set; }
        public DateTime? StartWorking { get; set; }
        public DateTime? EndWorking { get; set; }
        public DateTime? BreakStart { get; set; }
        public DateTime? BreakEnd { get; set; }
    }
}

