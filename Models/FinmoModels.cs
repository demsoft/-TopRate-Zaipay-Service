using System;

public class Individual
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string dob { get; set; }
        public string email { get; set; }
        public string identification_type { get; set; }
        public string identification_custom_type { get; set; }
        public string identification_value { get; set; }
        public string country_of_residence { get; set; }
        public string nationality { get; set; }
        public string address_line1 { get; set; }
        public string address_line2 { get; set; }
        public string address_city { get; set; }
        public string address_state { get; set; }
        public string address_zip_code { get; set; }
        public string address_country { get; set; }
        public string phone_country_code { get; set; }
        public string phone_number { get; set; }
    }

    public class FinmoCustomerObj
    {
        public string type { get; set; }
        public string organization_reference_id { get; set; }
        public Individual individual { get; set; }
    }

    public class CustomerResponseData
    {
        public string customer_id { get; set; }
        public string org_id { get; set; }
        public string type { get; set; }
        public object description { get; set; }
        public object webhook_url { get; set; }
        public object metadata { get; set; }
        public bool is_active { get; set; }
        public bool is_wallet_ready { get; set; }
        public string organization_reference_id { get; set; }
        public Individual individual { get; set; }
        public string created_by { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class CustomerResponseObject
    {
        public string request_id { get; set; }
        public DateTime request_time { get; set; }
        public bool success { get; set; }
        public int status_code { get; set; }
        public string status_text { get; set; }
        public CustomerResponseData data { get; set; }
    }

    public class WalletAccountObj
    {
        public string wallet_account_id { get; set; }
        public string wallet_id { get; set; }
        public string org_id { get; set; }
        public string currency { get; set; }
        public int actual_balance { get; set; }
        public int available_balance { get; set; }
        public bool is_active { get; set; }
        public bool is_settlement_allowed { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object deleted_at { get; set; }
    }

        public class WalletResponseObj
    {
        public string wallet_id { get; set; }
        public string org_id { get; set; }
        public string description { get; set; }
        public object metadata { get; set; }
        public string category { get; set; }
        public string scope { get; set; }
        public string created_by { get; set; }
        public string wallet_alias { get; set; }
        public string customer_id { get; set; }
        public object raw_data { get; set; }
        public object webhook_url { get; set; }
        public object deleted_at { get; set; }
        public bool is_active { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<WalletAccountObj> wallet_account { get; set; }
    }

    public class WalletResponseObj
    {
        public string request_id { get; set; }
        public DateTime request_time { get; set; }
        public bool success { get; set; }
        public int status_code { get; set; }
        public string status_text { get; set; }
        public WalletAccountData data { get; set; }
    }

    public class WalletRequestObj
    {
        public string customer_id { get; set; }
        public string currency { get; set; }
    }
