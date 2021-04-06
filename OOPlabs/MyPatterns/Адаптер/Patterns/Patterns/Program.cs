using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Patterns
{
    class JsonObj
    {}

    interface IJsonServise
    {
        JsonObj GetData(JsonObj qData);
    }

    class JsonServise : IJsonServise
    {
        public JsonObj GetData(JsonObj qData)
        {
            return qData;
        }
    }

    class Client
    {
        public void DoWork(IJsonServise serv)
        {
            var q = new JsonObj();
            var res = serv.GetData(q);
        }
    }

    class XmlObj
    {
    }

    interface IXmlServ
    {
        XmlObj GetParam(XmlObj obj);
    }

    class XmxServ : IXmlServ
    {
        public XmlObj GetParam(XmlObj obj)
        {
            return obj;
        }
    }

    class XmltoJsonAdapter : IJsonServise
    {
        protected IXmlServ _ser;
        public XmltoJsonAdapter(IXmlServ s)
        {
            _ser = s;
        }

        public JsonObj XmlToJson(XmlObj obj)
        {
            return new JsonObj();
        }

        public XmlObj JsontoXml(JsonObj obj)
        {
            return new XmlObj();
        }

        public JsonObj GetData(JsonObj qData)
        {
            var xml = JsontoXml(qData);
            var json = _ser.GetParam(xml);
            return XmlToJson(json);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client cli = new Client();
            var s = new JsonServise();
            cli.DoWork(s);

            var xml = new XmxServ();
            var adapter = new XmltoJsonAdapter(xml);
            cli.DoWork(adapter);
        }
    }
}
