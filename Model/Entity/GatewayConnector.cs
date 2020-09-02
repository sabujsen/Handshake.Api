using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Model.Entity
{
    /// <summary>
    /// Summary description for GatewayConnector.
    /// Copyright Web Active Corporation Pty Ltd  - All rights reserved. 1998-2004
    /// This code is for exclusive use with the eWAY payment gateway
    /// </summary>
    public class GatewayConnector
    {
        GatewayResponse _response;

        //change gateway in webconfig
        string _uri = ConfigurationManager.AppSettings["ewayGateway"];

        int _timeout = 36000;

        public GatewayConnector()
        {

        }

        /// <summary>
        /// The Uri of the Eway payment gateway
        /// </summary>
        public string Uri
        {
            get { return _uri; }
            set { _uri = value; }
        }

        public int ConnectionTimeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        public GatewayResponse Response
        {
            get { return _response; }
        }

        /// <summary>
        /// Do the post to the gateway and retrieve the response
        /// </summary>
        /// <param name="GatewayRequest"></param>
        /// <returns></returns>
        public bool ProcessRequest(GatewayRequest Request)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(_uri);
            request.Method = "POST";
            request.Timeout = _timeout;
            request.ContentType = "application/x-www-form-urlencoded";
            request.KeepAlive = false;

            byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(Request.ToXml());
            request.ContentLength = requestBytes.Length;

            // Send the data out over the wire
            try
            {
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(requestBytes, 0, requestBytes.Length);
                requestStream.Close();
            }

            catch
            {
                // Net connection failed
                return false;
            }

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException wex)
            {
                // for timeouts etc
                if (response == null)
                    return false;

                // try and get the error text
                response = (HttpWebResponse)wex.Response;
                StreamReader sr = null;
                sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.ASCII);
                string _wexBody = sr.ReadToEnd();
                sr.Close();
                return false;
            }

            catch
            {
                return false;
            }

            // get the response
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader sr = null;
                sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.ASCII);
                string _serverXml = sr.ReadToEnd();
                sr.Close();

                try
                {
                    _response = new GatewayResponse(_serverXml);
                    return true;
                }

                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}