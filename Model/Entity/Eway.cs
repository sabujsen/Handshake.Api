using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Model.Entity
{
    public class ewayRequest
    {
        /// <summary>
        /// Your unique eWAY customer ID assigned to you when you join eWAY. eg 11438715
        /// </summary>
        [Required]
        public string CustomerID { get; set; } //required
        /// <summary>
        /// The total amount in cents for the transaction, eg $1.00 = 100
        /// </summary>
        [Required]
        public string TotalAmount { get; set; } //required
        /// <summary>
        /// The first name of your customer making a purchase at your site.
        /// </summary>
        public string CustomerFirstName { get; set; }
        /// <summary>
        /// The last name of your customer making a purchase at your site.
        /// </summary>
        public string CustomerLastName { get; set; }
        /// <summary>
        /// The email address of your customer making a purchase at your site.
        /// </summary>
        public string CustomerEmail { get; set; }
        /// <summary>
        /// The address of your customer making a purchase at your site including state, city and country.
        /// </summary>
        public string CustomerAddress { get; set; }
        /// <summary>
        /// The postcode of your customer making a purchase at your site.
        /// </summary>
        public string CustomerPostcode { get; set; }
        /// <summary>
        /// A description of the products or services purchased.
        /// </summary>
        public string CustomerInvoiceDescription { get; set; }
        /// <summary>
        /// A reference to your own invoice system for the purchase.
        /// </summary>
        public string CustomerInvoiceRef { get; set; }
        /// <summary>
        /// Your unique eWAY customer ID assigned to you when you join eWAY. eg 11438715
        /// </summary>
        [Required]
        public string CardHoldersName { get; set; } //required
        /// <summary>
        /// Your unique eWAY customer ID assigned to you when you join eWAY. eg 11438715
        /// </summary>
        [Required]
        public string CardNumber { get; set; } //required
        /// <summary>
        /// Your unique eWAY customer ID assigned to you when you join eWAY. eg 11438715
        /// </summary>
        [Required]
        public string CardExpiryMonth { get; set; } //required
        /// <summary>
        /// Your unique eWAY customer ID assigned to you when you join eWAY. eg 11438715
        /// </summary>
        [Required]
        public string CardExpiryYear { get; set; } //required
        /// <summary>
        /// This value is returned to your website. You can pass a unique transaction number from your site.
        /// </summary>
        public string TrxnNumber { get; set; }
        /// <summary>
        /// This value is returned to your website. An additional field for you to pass and receive information from .
        /// </summary>
        public string Option1 { get; set; }
        /// <summary>
        /// This value is returned to your website. An additional field for you to pass and receive information from .
        /// </summary>
        public string Option2 { get; set; }
        /// <summary>
        /// This value is returned to your website. An additional field for you to pass and receive information from .
        /// </summary>
        public string Option3 { get; set; }
        /// <summary>
        /// This is the 3 digit security code found on the back of VISA and MasterCard credit cards, or 4 digit security code found on the front of AMEX cards.
        /// </summary>
        public string CVN { get; set; }

        /// <summary>
        /// process the information in the eway request
        /// </summary>
        /// <param name="ewayRequest">Contains the eway request information</param>
        /// <returns>ewayResponse object</returns>
        public static ewayResponse handleEwayRequest(string ewayCustomerID,ewayRequest ewayRequest)
        {
            ewayResponse theResponse = new ewayResponse();
            //create eWAY gateway object
            GatewayConnector eWAYgateway = new GatewayConnector();
            GatewayRequest eWAYRequest = new GatewayRequest();

            // Set the payment details

            //get eWAYcustomerID from web config
            eWAYRequest.EwayCustomerID = ewayCustomerID; // ConfigurationManager.AppSettings["ewayCustomerID"];

            //get values input by user on form, or set to database values
            eWAYRequest.CardNumber = ewayRequest.CardNumber;
            eWAYRequest.CardExpiryMonth = ewayRequest.CardExpiryMonth;
            eWAYRequest.CardExpiryYear = ewayRequest.CardExpiryYear;
            eWAYRequest.CardHolderName = ewayRequest.CardHoldersName;
            eWAYRequest.InvoiceAmount = Convert.ToInt32(ewayRequest.TotalAmount); //int
            eWAYRequest.PurchaserFirstName =ewayRequest.CustomerFirstName;
            eWAYRequest.PurchaserLastName =ewayRequest.CustomerLastName;
            eWAYRequest.PurchaserEmailAddress =ewayRequest.CustomerEmail;
            eWAYRequest.PurchaserAddress = ewayRequest.CustomerAddress;
            eWAYRequest.PurchaserPostalCode = ewayRequest.CustomerPostcode;
            eWAYRequest.InvoiceReference = ewayRequest.CustomerInvoiceRef;
            eWAYRequest.InvoiceDescription =ewayRequest.CustomerInvoiceDescription;
            eWAYRequest.TransactionNumber =ewayRequest.TrxnNumber;
            eWAYRequest.CVN = ewayRequest.CVN;
            eWAYRequest.EwayOption1 =ewayRequest.Option1;
            eWAYRequest.EwayOption2 =ewayRequest.Option2;
            eWAYRequest.EwayOption3 =ewayRequest.Option3;

            // Do the payment, send XML doc containing information gathered
            if (eWAYgateway.ProcessRequest(eWAYRequest))
            {
                // payment succesfully sent to gateway
                GatewayResponse eWAYResponse = eWAYgateway.Response;

                if (eWAYResponse != null)
                {
                    // Payment succeeded get values returned
                    //retVal = eWAYResponse.Status + ":" + eWAYResponse.AuthorisationCode + ":" + eWAYResponse.Error;
                    theResponse.ewayTrxnStatus=eWAYResponse.Status.ToString();
                    theResponse.ewayAuthCode=eWAYResponse.AuthorisationCode;
                    theResponse.ewayTrxnError=eWAYResponse.Error;
                    theResponse.ewayTrxnNumber= eWAYResponse.TransactionNumber;
                    theResponse.ewayReturnAmount=eWAYResponse.Amount.ToString();
                    theResponse.ewayTrxnReference=eWAYResponse.InvoiceReference;
                    theResponse.ewayTrxnOption1=eWAYResponse.Option1;
                    theResponse.ewayTrxnOption2=eWAYResponse.Option2;
                    theResponse.ewayTrxnOption3=eWAYResponse.Option3;
                }
                else
                {
                    // invalid response recieved from server.
                    theResponse.ewayTrxnError = "Error: An invalid response was recieved from the payment gateway.";
                }
            }
            else
            {
                // gateway connection failed
                theResponse.ewayTrxnError = "Error: Connection to the payment gateway failed. Check gateway URL or XML sent." + HttpContext.Current.Server.UrlEncode(eWAYRequest.ToXml().ToString());
            }
            return theResponse;
        }
    }
    public class ewayResponse
    {
        /// <summary>
        ///For a successful transaction "True" is passed and for a failed transaction "False" is passed. 
        /// </summary>
        public string ewayTrxnStatus { get; set; }
        /// <summary>
        ///This value is returned to your website. You can pass a unique transaction number from your site
        /// </summary>
        public string ewayTrxnNumber { get; set; }
        /// <summary>
        ///This value is returned to your website. You can pass a unique transaction number from your site
        /// </summary>
        public string ewayTrxnReference { get; set; }
        public string ewayTrxnOption1 { get; set; }
        public string ewayTrxnOption2 { get; set; }
        public string ewayTrxnOption3 { get; set; }
        /// <summary>
        ///If the transaction is successful, this is the bank authorisation number. This is also sent in the email receipt.
        /// </summary>
        public string ewayAuthCode { get; set; }
        /// <summary>
        ///Can be used a check that the transaction is processed for the same amount as you request from your website.
        /// </summary>
        public string ewayReturnAmount { get; set; }
        /// <summary>
        ///This is the response returned by the bank, and can be related to both successful and failed transactions.
        /// </summary>
        public string ewayTrxnError { get; set; }
    }
}