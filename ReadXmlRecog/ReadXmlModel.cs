using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReadXmlRecog
{
    class ReadXmlModel
    {
        List<double> w12;
        List<double> bias2;
        List<double> w23;
        List<double> bias3;
        XmlDocument doc;

        int numInput ;
        int numHidden;
        int numOutput;
        public ReadXmlModel()
        {
            doc = new XmlDocument();
            numInput = 784;
            numHidden = 200;
            numOutput = 14;
            bias2 = new List<double>();
            w12 = new List<double>();
            bias3 = new List<double>();
            w23 = new List<double>();
        }
        private string xPathValue(string xPath)
        {

            XmlNode node = doc.SelectSingleNode(xPath);
            if (node == null)
            {
                throw new ArgumentException("Cannot find spacified node", xPath);
            }
            return node.InnerText;
        }
        public List<double> GetW12() { return w12; }
        public List<double> GetW23() { return w23; }
        public List<double> GetBias2() { return bias2; }
        public List<double> GetBias3() { return bias3; }
        public void Get(out List<double> w12, out List<double> bias2, out List<double> w23, out List<double> bias3) {
            w12 = this.w12;
            bias2 = this.bias2;
            w23 = this.w23;
            bias3 = this.bias3;
        }
        public void LoadXml(String FilePath)
        {

            doc.Load(FilePath);
            double value;

            string BasePath = "NeuralNetwork/Weight/layer[@Index='0']/";
            //bias 2
            

            for (int i = 0; i < numHidden; i++)
            {
                string Nodepath = "Node[@Index='" + i.ToString() + "']/@Bias";
                double.TryParse(xPathValue(BasePath + Nodepath), out value);

                bias2.Add(value);
            }
            //w12
            
            for (int j = 0; j < numHidden; j++)
            {
                for (int k = 0; k < numInput; k++)
                {
                    string Nodepath = "Node[@Index='" + j.ToString() + "']/Axon[@Index='" + k.ToString() + "']";
                    double.TryParse(xPathValue(BasePath + Nodepath), out value);
                    w12.Add(value);
                }

            }

            
            //bias3
            
            BasePath = "NeuralNetwork/Weight/layer[@Index='1']/";
            for (int i = 0; i < numOutput; i++)
            {
                string Nodepath = "Node[@Index='" + i.ToString() + "']/@Bias";
                double.TryParse(xPathValue(BasePath + Nodepath), out value);

                bias3.Add(value);
            }
            //w23
            
            for (int j = 0; j < numOutput; j++)
            {
                for (int k = 0; k < numHidden; k++)
                {
                    string Nodepath = "Node[@Index='" + j.ToString() + "']/Axon[@Index='" + k.ToString() + "']";
                    double.TryParse(xPathValue(BasePath + Nodepath), out value);

                    w23.Add(value);
                }

            }


        }

    }
}
