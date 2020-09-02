using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace Model.Entity
{
    /// <summary>
    /// Summary description for GatewayResponse.
    /// Copyright Web Active Corporation Pty Ltd  - All rights reserved. 1998-2004
    /// This code is for exclusive use with the eWAY payment gateway
    /// </summary>
    public class GatewayResponse
    {

        private int _txAmount = 0;
        private string _txTransactionNumber = "";
        private string _txInvoiceReference = "";
        private string _txOption1 = "";
        private string _txOption2 = "";
        private string _txOption3 = "";
        private bool _txStatus = false;
        private string _txAuthCode = "";
        private string _txError = "";

        public GatewayResponse(string Xml)
        {
            string _currentField = "";
            StringReader _sr = new StringReader(Xml);
            XmlTextReader _xtr = new XmlTextReader(_sr);
            _xtr.XmlResolver = null;
            _xtr.WhitespaceHandling = WhitespaceHandling.None;

            // get the root node
            _xtr.Read();

            if ((_xtr.NodeType == XmlNodeType.Element) && (_xtr.Name == "ewayResponse"))
            {
                while (_xtr.Read())
                {
                    if ((_xtr.NodeType == XmlNodeType.Element) && (!_xtr.IsEmptyElement))
                    {
                        _currentField = _xtr.Name;
                        _xtr.Read();
                        if (_xtr.NodeType == XmlNodeType.Text)
                        {
                            switch (_currentField)
                            {
                                case "ewayTrxnError":
                                    _txError = _xtr.Value;
                                    break;

                                case "ewayTrxnStatus":
                                    if (_xtr.Value.ToLower().IndexOf("true") != -1)
                                        _txStatus = true;
                                    break;

                                case "ewayTrxnNumber":
                                    _txTransactionNumber = _xtr.Value;
                                    break;

                                case "ewayTrxnOption1":
                                    _txOption1 = _xtr.Value;
                                    break;

                                case "ewayTrxnOption2":
                                    _txOption2 = _xtr.Value;
                                    break;

                                case "ewayTrxnOption3":
                                    _txOption3 = _xtr.Value;
                                    break;

                                case "ewayReturnAmount":
                                    _txAmount = Int32.Parse(_xtr.Value);
                                    break;

                                case "ewayAuthCode":
                                    _txAuthCode = _xtr.Value;
                                    break;

                                case "ewayTrxnReference":
                                    _txInvoiceReference = _xtr.Value;
                                    break;

                                default:
                                    // unknown field
                                    throw new Exception("Unknown field in response.");
                            }
                        }
                    }
                }
            }
        }


        public string TransactionNumber
        {
            get { return _txTransactionNumber; }
        }

        public string InvoiceReference
        {
            get { return _txInvoiceReference; }
        }

        public string Option1
        {
            get { return _txOption1; }
        }

        public string Option2
        {
            get { return _txOption2; }
        }

        public string Option3
        {
            get { return _txOption3; }
        }

        public string AuthorisationCode
        {
            get { return _txAuthCode; }
        }

        public string Error
        {
            get { return _txError; }
        }

        public int Amount
        {
            get { return _txAmount; }
        }
        public bool Status
        {
            get { return _txStatus; }
        }
    }
}