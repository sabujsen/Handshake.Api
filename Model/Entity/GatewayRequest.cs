using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Entity
{
    /// <summary>
    /// Summary description for GatewayRequest.
    /// Copyright Web Active Corporation Pty Ltd  - All rights reserved. 1998-2004
    /// This code is for exclusive use with the eWAY payment gateway
    /// </summary>
    public class GatewayRequest
    {
        private string _txCustomerID = "";
        private int _txAmount = 0;
        private string _txCardholderName = "";
        private string _txCardNumber = "";
        private string _txCardExpiryMonth = "01";
        private string _txCardExpiryYear = "00";
        private string _txTransactionNumber = "";
        private string _txCardholderFirstName = "";
        private string _txCardholderLastName = "";
        private string _txCardholderEmailAddress = "";
        private string _txCardholderAddress = "";
        private string _txCardholderPostalCode = "";
        private string _txInvoiceReference = "";
        private string _txInvoiceDescription = "";
        private string _txCVN = "";
        private string _txOption1 = "";
        private string _txOption2 = "";
        private string _txOption3 = "";

        public GatewayRequest()
        {

        }

        public string EwayCustomerID
        {
            get
            {
                return _txCustomerID;
            }

            set
            {
                _txCustomerID = value;
            }
        }

        public int InvoiceAmount
        {
            get
            {
                return _txAmount;
            }

            set
            {
                _txAmount = value;
            }
        }

        public string CardHolderName
        {
            get
            {
                return _txCardholderName;
            }

            set
            {
                _txCardholderName = value;
            }
        }

        public string CardExpiryMonth
        {
            get
            {
                return _txCardExpiryMonth;
            }

            set
            {
                _txCardExpiryMonth = value;
            }
        }

        public string CardExpiryYear
        {
            get
            {
                return _txCardExpiryYear;
            }

            set
            {
                _txCardExpiryYear = value;
            }
        }

        public string TransactionNumber
        {
            get
            {
                return _txTransactionNumber;
            }

            set
            {
                _txTransactionNumber = value;
            }
        }
        public string PurchaserFirstName
        {
            get
            {
                return _txCardholderFirstName;
            }

            set
            {
                _txCardholderFirstName = value;
            }
        }

        public string PurchaserLastName
        {
            get
            {
                return _txCardholderLastName;
            }

            set
            {
                _txCardholderLastName = value;
            }
        }

        public string CardNumber
        {
            get
            {
                return _txCardNumber;
            }

            set
            {
                _txCardNumber = value;
            }
        }
        public string PurchaserAddress
        {
            get
            {
                return _txCardholderAddress;
            }

            set
            {
                _txCardholderAddress = value;
            }
        }
        public string PurchaserPostalCode
        {
            get
            {
                return _txCardholderPostalCode;
            }

            set
            {
                _txCardholderPostalCode = value;
            }
        }
        public string PurchaserEmailAddress
        {
            get
            {
                return _txCardholderEmailAddress;
            }

            set
            {
                _txCardholderEmailAddress = value;
            }
        }


        public string InvoiceReference
        {
            get { return _txInvoiceReference; }
            set { _txInvoiceReference = value; }
        }
        public string InvoiceDescription
        {
            get { return _txInvoiceDescription; }
            set { _txInvoiceDescription = value; }
        }
        public string CVN
        {
            get { return _txCVN; }
            set { _txCVN = value; }
        }
        public string EwayOption1
        {
            get { return _txOption1; }
            set { _txOption1 = value; }
        }
        public string EwayOption2
        {
            get { return _txOption2; }
            set { _txOption2 = value; }
        }
        public string EwayOption3
        {
            get { return _txOption3; }
            set { _txOption3 = value; }
        }


        public string ToXml()
        {
            // We don't really need the overhead of creating an XML DOM object
            // to really just concatenate a string together.

            string _xml = "<ewaygateway>";
            _xml += CreateNode("ewayCustomerID", _txCustomerID);
            _xml += CreateNode("ewayTotalAmount", _txAmount.ToString());
            _xml += CreateNode("ewayCardHoldersName", _txCardholderName);
            _xml += CreateNode("ewayCardNumber", _txCardNumber);
            _xml += CreateNode("ewayCardExpiryMonth", _txCardExpiryMonth.ToString());
            _xml += CreateNode("ewayCardExpiryYear", _txCardExpiryYear.ToString());
            _xml += CreateNode("ewayTrxnNumber", _txTransactionNumber);
            _xml += CreateNode("ewayCustomerInvoiceDescription", _txInvoiceDescription);
            _xml += CreateNode("ewayCustomerFirstName", _txCardholderFirstName);
            _xml += CreateNode("ewayCustomerLastName", _txCardholderLastName);
            _xml += CreateNode("ewayCustomerEmail", _txCardholderEmailAddress);
            _xml += CreateNode("ewayCustomerAddress", _txCardholderAddress);
            _xml += CreateNode("ewayCustomerPostcode", _txCardholderPostalCode);
            _xml += CreateNode("ewayCustomerInvoiceRef", _txInvoiceReference);
            _xml += CreateNode("ewayCVN", _txCVN);
            _xml += CreateNode("ewayOption1", _txOption1);
            _xml += CreateNode("ewayOption2", _txOption2);
            _xml += CreateNode("ewayOption3", _txOption3);
            _xml += "</ewaygateway>";

            return _xml;
        }

        /// <summary>
        /// Builds a simple XML node.
        /// </summary>
        /// <param name="NodeName">The name of the node being created.</param>
        /// <param name="NodeValue">The value of the node being created.</param>
        /// <returns>An XML node as a string.</returns>
        private string CreateNode(string NodeName, string NodeValue)
        {
            return "<" + NodeName + ">" + NodeValue + "</" + NodeName + ">";
        }
    }
}