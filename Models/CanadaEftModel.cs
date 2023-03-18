   public class CreateCustomerObj
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TransitNumber { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
    }

    public class TransactionObj
    {
        public string Email { get; set; }
        public int CustomerAccountId { get; set; }
        public string TransactionTypeCode { get; set; }
        public double Amount { get; set; }
    }

    public class SearchTransactionObj
    {
        public string TransactionNumber { get; set; }
    }

    public class CancelTransactionObj
    {
        public string TransactionNumber { get; set; }
        public string CustomerNumber { get; set; }
    }

    public class UpdateCustomerObj
    {
        public int CustomerAccountId { get; set; }
        public string CustomerNumber { get; set; }
        public string TransitNumber { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
    }


    