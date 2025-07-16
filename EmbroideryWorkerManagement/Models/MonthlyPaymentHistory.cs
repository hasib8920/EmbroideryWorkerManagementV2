namespace EmbroideryWorkerManagement.Models
{
    public class MonthlyPaymentHistory
    {
        public int Id { get; set; }
        public int MonthlyPaymentId { get; set; }
        public MonthlyPayment MonthlyPayment { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaidAmount { get; set; }
    }

}
