namespace BL.ClassesDTO
{
    public class CustomersDTO
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string address { get; set; }

        public int? codeCity { get; set; }      // ← הוספתי ?
        public int? codePayment { get; set; }   // ← הוספתי ?
        public int? numRents { get; set; }      // ← הוספתי ?
    }
}
